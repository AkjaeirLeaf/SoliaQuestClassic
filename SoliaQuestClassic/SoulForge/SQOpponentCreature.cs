using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public class SQOpponentCreature : SQCreature
    {
        public SQOpponentCreature(SQSpecies species)
        {
            m_species = species;
            m_speciesInternal = species.InternalName;

            stat_Health = species.BaseStatHealth;
            stat_Defense = species.BaseStatDefense;
            stat_Attack = species.BaseStatAttack;
            stat_Stamina = species.BaseStatStamina;
            stat_Evade = species.BaseStatEvade;
            stat_Control = species.BaseStatControl;

            stat_advanceHealth = stat_Health;
            stat_advanceDefense = stat_Defense;
            stat_advanceAttack = stat_Attack;
            stat_advanceStamina = stat_Stamina;
            stat_advanceEvade = stat_Evade;
            stat_advanceControl = stat_Control;

            //TODO add stat mods and color mods, implement stat changes fetching.

            //get stat modifier?
            SQStatMod[] statModList = new SQStatMod[SQWorld.SQWorldStatModList.Count];
            SQWorld.SQWorldStatModList.Values.CopyTo(statModList, 0);
            int selectedHighest = 0;
            int highestStatPower = 0;
            for (int statmodcyc = 0; statmodcyc < statModList.Length; statmodcyc++)
            {
                if (Kirali.Framework.Random.Double(0, 1) < statModList[statmodcyc].BaseProbability
                    && statModList[statmodcyc].StatModPower >= highestStatPower)
                {
                    selectedHighest = statmodcyc;
                    highestStatPower = statModList[statmodcyc].StatModPower;
                }
            }
            statMod = statModList[selectedHighest].InternalID;
            initialStatMod = statMod; upgraded = false;

            //set new stat values
            stat_advanceHealth = statModList[selectedHighest].GetStatHealth(stat_Health);
            stat_advanceDefense = statModList[selectedHighest].GetStatDefense(stat_Defense);
            stat_advanceAttack = statModList[selectedHighest].GetStatAttack(stat_Attack);
            stat_advanceStamina = statModList[selectedHighest].GetStatStamina(stat_Stamina);
            stat_advanceEvade = statModList[selectedHighest].GetStatEvade(stat_Evade);
            stat_advanceControl = statModList[selectedHighest].GetStatControl(stat_Control);
            UpdateAllStatRanks();

            //add color mods?
            SQColorMod[] colorModList = new SQColorMod[SQWorld.SQWorldColorModList.Count];
            SQWorld.SQWorldColorModList.Values.CopyTo(colorModList, 0);
            int maxColorPow = -3;
            bool stop = false;
            for (int colorModCyc = 0; colorModCyc < colorModList.Length; colorModCyc++)
            {
                if (Kirali.Framework.Random.Double(0, 1) < colorModList[colorModCyc].BaseProbability)
                {
                    switch (colorModList[colorModCyc].OverrideType)
                    {
                        case SQColorModOverridesType.useArray:

                            //loop shit

                            break;
                        case SQColorModOverridesType.overrideLower:

                            //loop colorMods to check

                            break;
                        case SQColorModOverridesType.overrideHigher:

                            //loop colorMods to check

                            break;
                        case SQColorModOverridesType.overrideAll:
                            colorMods = new string[1] { colorModList[colorModCyc].InternalID };
                            stop = true;
                            break;
                        case SQColorModOverridesType.overrideNone:

                            break;
                        case SQColorModOverridesType.attemptAdd:
                            colorMods = ArrayHandler.append(colorMods, colorModList[colorModCyc].InternalID);

                            break;
                    }
                    if (stop) { break; }
                }
            }


            //set full stats
            FullHeal();
            LearnDefaultAbilities();
            SetupInventory();
            AddTag("isTrainingDummy", false);
        }

        public SQOpponentCreature()
        {
            if(!SQWorld.SQWorldSpeciesList.TryGetValue("dummy1", out m_species))
            {
                m_species = new SoulForge.Species.TrainingDummy();
            }

            m_speciesInternal = m_species.InternalName;

            stat_Health  = m_species.BaseStatHealth;
            stat_Defense = m_species.BaseStatDefense;
            stat_Attack  = m_species.BaseStatAttack;
            stat_Stamina = m_species.BaseStatStamina;
            stat_Evade   = m_species.BaseStatEvade;
            stat_Control = m_species.BaseStatControl;

            stat_advanceHealth  = stat_Health;
            stat_advanceDefense = stat_Defense;
            stat_advanceAttack  = stat_Attack;
            stat_advanceStamina = stat_Stamina;
            stat_advanceEvade   = stat_Evade;
            stat_advanceControl = stat_Control;

            //TODO add stat mods and color mods, implement stat changes fetching.

            statMod = "ordinary";
            initialStatMod = statMod; upgraded = false;
            UpdateAllStatRanks();

            //set full stats
            FullHeal();
            LearnDefaultAbilities();
            SetupInventory();
            AddTag("isTrainingDummy", true);
        }

        private int turn = 0;
        public string GetAbilityUse(SQCreature target)
        {
            object isDummy = false;
            TryGetTag("isTrainingDummy", out isDummy);
            if (!(bool)isDummy)
            {
                //Basic AI for enemy, pick which ability to use.

                if (turn == 0)
                {
                    int ind = -1;
                    ind = FindAbilityType(SQAbilityPurpose.APPLY_DAMAGE_EFFECT);
                    if (ind != -1) { return Abilities[ind].InternalName; }
                    ind = FindAbilityType(SQAbilityPurpose.STAT_HIT);
                    if (ind != -1) { return Abilities[ind].InternalName; }
                    ind = FindAbilityType(SQAbilityPurpose.STAT_BOOST);
                    if (ind != -1) { return Abilities[ind].InternalName; }
                }
                //If under 50% health, will begin using defensive measures
                else if (dynamic_Health < stat_advanceHealth * 0.5)
                {
                    int healind = -1;
                    healind = FindAbilityType(SQAbilityPurpose.HEAL_ONLY);
                    if (healind != -1) { return Abilities[healind].InternalName; }
                    healind = FindAbilityType(SQAbilityPurpose.HEAL_DAMAGE);
                    if (healind != -1) { return Abilities[healind].InternalName; }
                    healind = FindAbilityType(SQAbilityPurpose.STAT_BOOST);
                    if (healind != -1) { return Abilities[healind].InternalName; }
                    healind = FindAbilityType(SQAbilityPurpose.DAMAGE_REFLECT);
                    if (healind != -1) { return Abilities[healind].InternalName; }
                }
                //if under 20% health, will begin using very defensive measures
                else if (dynamic_Health < stat_advanceHealth * 0.2)
                {
                    int healind = -1;
                    if (Kirali.Framework.Random.Int(0, 100) < 33)
                    {
                        healind = FindAbilityType(SQAbilityPurpose.USE_ITEM);
                        if (healind != -1) { return Abilities[healind].InternalName; }
                    } //using up all the heals would be a bit much.....
                    healind = FindAbilityType(SQAbilityPurpose.HEAL_ONLY);
                    if (healind != -1) { return Abilities[healind].InternalName; }
                    healind = FindAbilityType(SQAbilityPurpose.STAT_BOOST);
                    if (healind != -1) { return Abilities[healind].InternalName; }
                    healind = FindAbilityType(SQAbilityPurpose.DAMAGE_REFLECT);
                    if (healind != -1) { return Abilities[healind].InternalName; }
                }
                if (Abilities.Length > 0) { return Abilities[0].InternalName; }
                return "";
            }
            else
            {
                return "blankStare";
            }
        }

        private int FindAbilityType(SQAbilityPurpose purpose)
        {
            for(int i = 0; i < Abilities.Length; i++)
            {
                if (Abilities[i].Purpose == purpose)
                    return i;
            }
            return -1;
        }
    }
}

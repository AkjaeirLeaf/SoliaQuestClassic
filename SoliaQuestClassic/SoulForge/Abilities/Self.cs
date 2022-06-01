using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Self : SQAbility
    {
        public Self(string[] creatureTypes)
        {
            ModifyAbilityReference("Self", "self");
            for(int i = 0; i < creatureTypes.Length; i++)
            {
                addTypeOf(creatureTypes[i], 1.0);
            }
            description = "A costly attack most effective when facing off against your own kind.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 0.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.0;

            //stamina usage
            m_doBaseStaminaCost = 45.0;
            m_baseExperienceUse = 666;

            //I will use the base ability damage info here :)
        }

        private SQCreature user;
        public override void OnAbilityUse(SQCreature sender)
        {
            user = sender;
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            if(user != null)
            {
                double damageModifier = 0;
                int abil_user = user.CreatureSpecies.UseSpeciesTypes.Length;
                int abil_target = target.CreatureSpecies.UseSpeciesTypes.Length;

                for(int i = 0; i < abil_user; i++)
                {
                    for (int u = 0; u < abil_target; u++)
                    {
                        if(user.CreatureSpecies.UseSpeciesTypes[i] == target.CreatureSpecies.UseSpeciesTypes[u])
                        {
                            damageModifier++;
                        }
                    }
                }

                damageModifier /= (abil_user + abil_target);
                double basedamage = 50;

                SQType[] typesList = new SQType[abil_user];
                bool allPass = true;
                for(int t = 0; t < abil_user; t++)
                {
                    if(!SQWorld.SQWorldTypeList.TryGetValue(user.CreatureSpecies.UseSpeciesTypes[t], out typesList[t]))
                    { allPass = false; }
                }
                SQAbilityInfo sqai = new SQAbilityInfo();
                if (allPass) { sqai.abilityType = typesList; }
                else { sqai.abilityType = new SQType[] { new Types.Typeless() }; }
                sqai.abilityDisplay = "Self";
                sqai.doDamageTarget = basedamage * damageModifier * user.DynamicAttack;
                sqai.senderLevel = user.Level;

                target.DoDamage(sqai);
            }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Scratch());
            return 1;
        }
    }
}

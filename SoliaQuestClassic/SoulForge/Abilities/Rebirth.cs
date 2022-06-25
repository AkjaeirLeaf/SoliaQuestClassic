using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Rebirth : SQAbility
    {
        private enum rebirthType
        {
            rebirth,
            rebirthV
        }
        private rebirthType thisType = rebirthType.rebirth;

        public Rebirth()
        {
            ModifyAbilityReference("Rebirth", "rebirth");
            addTypeOf("spirit", 1.0);
            description = "The husk of your formal self fades with all its negative status effects. You feel renewed.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 24.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     = 27.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.08;
            m_controlMod         = 0.90;

            //stamina usage
            m_doBaseStaminaCost  = 11.0;

            //I will use the base ability damage info here :)
        }

        public Rebirth(string doModifyAbility)
        {
            switch (doModifyAbility)
            {
                case "V":
                    thisType = rebirthType.rebirthV;
                    abilityOverwritePriority = 5;
                    ModifyAbilityReference("Rebirth V", "rebirth");
                    addTypeOf("light",   1.2);
                    addTypeOf("spirit", 1.2);
                    description = "GENESIS REBIRTH V: The husk of your former self blasts from your essense, You feel relieved of all your ailments.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.STAT_BOOST;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 35.0;
                    m_doBaseDamageSelf   =  0.0;
                    m_doBaseHealTarget   =  0.0;
                    m_doBaseHealSelf     = 35.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance = 0.05;

                    //stamina usage
                    m_doBaseStaminaCost = 32.0;
                    break;
                default:
                    thisType = rebirthType.rebirthV;
                    abilityOverwritePriority = 0;
                    ModifyAbilityReference("Rebirth", "rebirth");
                    addTypeOf("spirit", 1.0);
                    description = "The husk of your formal self fades with all its negative status effects. You feel renewed.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.STAT_BOOST;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 24.0;
                    m_doBaseDamageSelf   =  0.0;
                    m_doBaseHealTarget   =  0.0;
                    m_doBaseHealSelf     = 27.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance = 0.08;

                    //stamina usage
                    m_doBaseStaminaCost = 25.0;
                    break;
            }
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            if(thisType == rebirthType.rebirthV)
            {
                //sender.AddEffect(new Effects.RebornEffect("genesis"));
            }
            else
            {
                //sender.AddEffect(new Effects.RebornEffect("rebirth"));    
            }
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            target.AddEffect(new Effects.BlindedEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Rebirth());
            return 1;
        }
    }
}

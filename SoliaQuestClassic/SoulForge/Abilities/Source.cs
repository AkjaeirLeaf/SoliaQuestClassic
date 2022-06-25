using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Source : SQAbility
    {
        private enum sourceType
        {
            defaultT,
            advancedTechniqueEV
        }
        private sourceType thisType = sourceType.defaultT;

        public Source()
        {
            ModifyAbilityReference("Source", "source");
            addTypeOf("light", 1.0);
            addTypeOf("spirit", 1.0);
            description = "The infinite power of Kiraveal smites your opponent down.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 170.0;
            m_doBaseDamageSelf   =  25.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.0;
            m_controlMod         = 0.3;

            //stamina usage
            m_doBaseStaminaCost  = 35.0;

            //I will use the base ability damage info here :)
        }

        public Source(string doModifyAbility)
        {
            switch (doModifyAbility)
            {
                case "EV": //slightly more efficient technique
                    thisType = sourceType.advancedTechniqueEV;
                    abilityOverwritePriority = 5;
                    ModifyAbilityReference("Source EV", "source");
                    addTypeOf("light", 1.0);
                    addTypeOf("spirit", 1.0);
                    description = "The infinite power of Kiraveal smites your opponent down.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 170.0;
                    m_doBaseDamageSelf   =  22.0;
                    m_doBaseHealTarget   =  0.0;
                    m_doBaseHealSelf     =  0.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance   = 0.0;
                    m_controlMod         = 0.5;

                    //stamina usage
                    m_doBaseStaminaCost  = 25.0;

                    //I will use the base ability damage info here :)
                    break;
                default:
                    thisType = sourceType.defaultT;
                    ModifyAbilityReference("Source", "source");
                    addTypeOf("light", 1.0);
                    addTypeOf("spirit", 1.0);
                    description = "The infinite power of Kiraveal smites your opponent down.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 170.0;
                    m_doBaseDamageSelf   =  25.0;
                    m_doBaseHealTarget   =   0.0;
                    m_doBaseHealSelf     =   0.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance   =   0.0;
                    m_controlMod         =   0.4;

                    //stamina usage
                    m_doBaseStaminaCost  = 35.0;

                    //I will use the base ability damage info here :)
                    break;
            }
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            double defN = target.DynamicDefense * 0.5;
            target.DoModifyDefense(defN);
            
            //target.AddEffect(new Effects.OverwhelmedEffect());
            target.AddEffect(new Effects.BlindedEffect());

        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Source());
            return 1;
        }
    }
}

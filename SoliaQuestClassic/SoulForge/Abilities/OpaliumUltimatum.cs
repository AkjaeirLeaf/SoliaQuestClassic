using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class OpaliumUltimatum : SQAbility
    {
        private enum opaliumType
        {
            defaultT,
            advancedTechniqueX
        }
        private opaliumType thisType = opaliumType.defaultT;

        public OpaliumUltimatum()
        {
            ModifyAbilityReference("Opalium Ultimatum", "opaliumUltimatum");
            addTypeOf("crystal", 1.3);
            addTypeOf("light"  , 1.3);
            addTypeOf("spirit" , 1.3);
            description = "A storm of crystal shards erupt from beyond this dimension.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 85.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     = 34.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.004;

            //stamina usage
            m_doBaseStaminaCost = 26.0;

            //I will use the base ability damage info here :)
        }

        public OpaliumUltimatum(string doModifyAbility)
        {
            switch (doModifyAbility)
            {
                case "X":
                    thisType = opaliumType.advancedTechniqueX;
                    ModifyAbilityReference("Opalium Ultimatum", "opaliumUltimatum");
                    abilityOverwritePriority = 10;
                    addTypeOf("crystal", 1.45);
                    addTypeOf("light"  , 1.45);
                    description = "ADVANCED TECHNIQUE OPALIUM ULTIMATUM\nA storm of crystal shards erupt from beyond this dimension.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 125.0;
                    m_doBaseDamageSelf   =   0.0;
                    m_doBaseHealTarget   =   0.0;
                    m_doBaseHealSelf     =  53.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance = 0.002;

                    //stamina usage
                    m_doBaseStaminaCost = 43.0;
                    break;
                default:
                    ModifyAbilityReference("Opalium Ultimatum", "opaliumUltimatum");
                    abilityOverwritePriority = 0;
                    addTypeOf("crystal", 1.3);
                    addTypeOf("light"  , 1.3);
                    description = "A storm of crystal shards erupt from beyond this dimension.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 85.0;
                    m_doBaseDamageSelf   =  0.0;
                    m_doBaseHealTarget   =  0.0;
                    m_doBaseHealSelf     = 34.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance = 0.004;

                    //stamina usage
                    m_doBaseStaminaCost = 26.0;
                    break;
            }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Opalescence());
            return 1;
        }
    }
}

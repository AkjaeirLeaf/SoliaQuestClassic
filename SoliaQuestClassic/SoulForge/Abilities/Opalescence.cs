using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Opalescence : SQAbility
    {
        private enum opaliumType
        {
            defaultT,
            advancedTechniqueX
        }
        private opaliumType thisType = opaliumType.defaultT;

        public Opalescence()
        {
            ModifyAbilityReference("Opalescence", "opalescence");
            addTypeOf("crystal", 1.1);
            addTypeOf("light", 1.1);
            description = "A fury of blinding light erupts from the void.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 46.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     = 18.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.006;

            //stamina usage
            m_doBaseStaminaCost = 18.0;

            //I will use the base ability damage info here :)
        }

        public Opalescence(string doModifyAbility)
        {
            switch (doModifyAbility)
            {
                case "X":
                    thisType = opaliumType.advancedTechniqueX;
                    abilityOverwritePriority = 10;
                    ModifyAbilityReference("Opalescence X", "opalescence");
                    addTypeOf("crystal", 1.3);
                    addTypeOf("light"  , 1.3);
                    addTypeOf("spirit" , 1.3);
                    description = "ADVANCED TECHNIQUE OPALESCENCE\nA fury of blinding light erupts from the void.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 64.0;
                    m_doBaseDamageSelf   =  0.0;
                    m_doBaseHealTarget   =  0.0;
                    m_doBaseHealSelf     = 25.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance = 0.003;

                    //stamina usage
                    m_doBaseStaminaCost = 22.0;
                    break;
                default:
                    ModifyAbilityReference("Opalescence", "opalescence");
                    abilityOverwritePriority = 0;
                    addTypeOf("crystal", 1.1);
                    addTypeOf("light"  , 1.1);
                    description = "A fury of blinding light erupts from the void.";
                    doShowAbility = true;
                    abilityCategory = SQAbilityCategory.ENERGY;
                    abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

                    //set base damage / heal stuff
                    m_doBaseDamageTarget = 46.0;
                    m_doBaseDamageSelf   =  0.0;
                    m_doBaseHealTarget   =  0.0;
                    m_doBaseHealSelf     = 18.0;

                    //how possible is evading this attack?
                    m_dodgeCompdChance = 0.006;

                    //stamina usage
                    m_doBaseStaminaCost = 18.0;

                    //I will use the base ability damage info here :)
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

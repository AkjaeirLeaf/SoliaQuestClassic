using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class ScratchII : SQAbility
    {
        public ScratchII()
        {
            ModifyAbilityReference("Scratch II", "scratchII");
            addTypeOf("typeless", 1.0);
            description = "A a claw attack imbued with your own affinity.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 15.0;
            m_doBaseDamageSelf = 0.2;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.08;
            m_controlMod = 0.70;

            //stamina usage
            m_doBaseStaminaCost = 4.3;

            //I will use the base ability damage info here :)
        }

        public ScratchII(string[] creatureTypes)
        {
            ModifyAbilityReference("Scratch II", "scratchII");
            for(int i = 0; i < creatureTypes.Length; i++)
            {
                addTypeOf(creatureTypes[i], 1.0);
            }
            description = "A a claw attack imbued with your own affinity.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 15.0;
            m_doBaseDamageSelf   =  0.2;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.08;
            m_controlMod       = 0.70;

            //stamina usage
            m_doBaseStaminaCost = 4.3;

            //I will use the base ability damage info here :)
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new ScratchII());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Scratch : SQAbility
    {
        public Scratch()
        {
            ModifyAbilityReference("Scratch", "scratchbasic");
            addTypeOf("typeless", 1.0);
            description = "A basic claw attack";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.DAMAGE_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 9.0;
            m_doBaseDamageSelf   = 0.0;
            m_doBaseHealTarget   = 0.0;
            m_doBaseHealSelf     = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.2;

            //stamina usage
            m_doBaseStaminaCost = 2.0;

            //I will use the base ability damage info here :)
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Scratch());
            return 1;
        }
    }
}

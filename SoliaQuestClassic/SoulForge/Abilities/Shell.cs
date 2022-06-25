using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Shell : SQAbility
    {
        public Shell()
        {
            ModifyAbilityReference("Shell", "shell");
            addTypeOf("spirit", 1.0);
            description = "The husk of your formal self fades with all its negative status effects. You feel renewed.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.HEAL_ONLY;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  0.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     = 17.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.00;
            m_controlMod         = 0.90;

            //stamina usage
            m_doBaseStaminaCost  = 11.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            //sender.AddEffect(new Effects.RebornEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Shell());
            return 1;
        }
    }
}

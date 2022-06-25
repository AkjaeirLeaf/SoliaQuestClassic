using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class StarPath : SQAbility
    {
        public StarPath()
        {
            ModifyAbilityReference("StarPath", "starPath");
            addTypeOf("plasma", 1.0);
            addTypeOf("spirit", 1.0);
            description = "You call upon the homeworld to increase your strength.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  0.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     = 21.0; //after implementing teams and target selection, switch heal self to heal target

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.00;
            m_controlMod         = 0.80;

            //stamina usage
            m_doBaseStaminaCost  = 23.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.AddEffect(new Effects.ConnectionEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new StarPath());
            return 1;
        }
    }
}

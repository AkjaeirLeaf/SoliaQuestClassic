using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class SharedFate : SQAbility
    {
        public SharedFate()
        {
            ModifyAbilityReference("SharedFate", "sharedFate");
            addTypeOf("spirit", 1.0);
            description = "You and your target share health until the ability is deactivated.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 16.0;
            m_doBaseDamageSelf   = 16.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.00;
            m_controlMod         = 0.50;

            //stamina usage
            m_doBaseStaminaCost  = 13.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            //Implement shared fate tags and effects
            //target.AddEffect(new Effects.CursedEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new SharedFate());
            return 1;
        }
    }
}

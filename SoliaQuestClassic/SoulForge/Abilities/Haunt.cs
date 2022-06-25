using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Haunt : SQAbility
    {
        public Haunt()
        {
            ModifyAbilityReference("Haunt", "haunt");
            addTypeOf("spirit", 1.0);
            description = "You haunt your opponent, making them lose focus.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 6.0;
            m_doBaseDamageSelf   = 0.0;
            m_doBaseHealTarget   = 0.0;
            m_doBaseHealSelf     = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.00;
            m_controlMod         = 0.70;

            //stamina usage
            m_doBaseStaminaCost  = 10.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            double evaN = target.DynamicEvade   * 0.85;
            double conN = target.DynamicControl * 0.85;
            target.DoModifyEvade(evaN);
            target.DoModifyControl(conN);

            //target.AddEffect(new Effects.HauntedEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Haunt());
            return 1;
        }
    }
}

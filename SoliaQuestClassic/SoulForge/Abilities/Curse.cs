using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Curse : SQAbility
    {
        public Curse()
        {
            ModifyAbilityReference("Curse", "curse");
            addTypeOf("spirit", 1.0);
            description = "You curse your opponent to be hurt a little each turn.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 18.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.03;
            m_controlMod         = 0.70;

            //stamina usage
            m_doBaseStaminaCost  = 10.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            Effects.CursedEffect effectCurse = new Effects.CursedEffect();
            effectCurse.SetUseAbility(this, target);
            target.AddEffect(effectCurse);
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Curse());
            return 1;
        }
    }
}

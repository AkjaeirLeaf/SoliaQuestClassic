using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class PrismTrap : SQAbility
    {
        public PrismTrap()
        {
            ModifyAbilityReference("PrismTrap", "prismTrap");
            addTypeOf("crystal", 1.0);
            addTypeOf("spirit", 1.0);
            description = "You trap your opponent in a mirror space where part of their damage is reflected.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 15.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.04;
            m_controlMod         = 0.60;

            //stamina usage
            m_doBaseStaminaCost  = 14.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            //target.AddEffect(new Effects.PrismTrapEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new PrismTrap());
            return 1;
        }
    }
}

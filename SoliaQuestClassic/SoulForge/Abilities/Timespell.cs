using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Timespell : SQAbility
    {
        public Timespell()
        {
            ModifyAbilityReference("Timespell", "timespell");
            addTypeOf("spirit", 1.0);
            description = "Forms a cocoon of energy that slows incoming damage.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.UNKNOWN;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 0.0;
            m_doBaseDamageSelf   = 0.0;
            m_doBaseHealTarget   = 0.0;
            m_doBaseHealSelf     = 10.0; //after implementing teams and target selection, make this ability able to be applied to a target

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.00;
            m_controlMod = 0.73;

            //stamina usage
            m_doBaseStaminaCost = 33.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.AddEffect(new Effects.TimespellEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Timespell());
            return 1;
        }
    }
}

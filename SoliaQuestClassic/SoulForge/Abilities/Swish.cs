using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Swish : SQAbility
    {
        public Swish()
        {
            ModifyAbilityReference("Swish", "swish");
            addTypeOf("air", 1.0);
            description = "A basic wind attack. Reduces next hit damage by .1, stacks up to 10.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 5.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.2;

            //stamina usage
            m_doBaseStaminaCost = 3.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.AddEffect(new Effects.SwishEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Swish());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class RiverDance : SQAbility
    {
        public RiverDance()
        {
            ModifyAbilityReference("River Dance", "riverDance");
            addTypeOf("spirit", 1.0);
            addTypeOf("water", 1.0);
            description = "You synchronize your motion with the forest stream. Your EVADE and CONTROL stat increase.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  0.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   = 10.0;
            m_doBaseHealSelf     =  0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.0;

            //stamina usage
            m_doBaseStaminaCost = 13.5;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new RiverDance());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Shatter : SQAbility
    {
        public Shatter()
        {
            ModifyAbilityReference("Shatter", "shatter");
            addTypeOf("crystal", 1.0);
            description = "A burst of shards fly off your opponent, their defense is greatly reduced.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.STAT_HIT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 16.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.05;

            //stamina usage
            m_doBaseStaminaCost = 17.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            double defN = target.DynamicDefense * 0.47;
            target.DoModifyDefense(defN);
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Shatter());
            return 1;
        }
    }
}

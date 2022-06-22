using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Infinity : SQAbility
    {
        public Infinity()
        {
            ModifyAbilityReference("Infinity", "infinity");
            addTypeOf("crystal", 1.0);
            addTypeOf("dark",    1.0);
            addTypeOf("spirit",  1.0);
            description = "Your opponent will be lost to the void.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.APPLY_DAMAGE_EFFECT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 21.0;
            m_doBaseDamageSelf =   0.0;
            m_doBaseHealTarget =   0.0;
            m_doBaseHealSelf =     0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.003;

            //stamina usage
            m_doBaseStaminaCost = 21.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            double defN = target.DynamicDefense * 0.4;
            target.DoModifyDefense(defN);
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Infinity());
            return 1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class PrismSlash : SQAbility
    {
        public PrismSlash()
        {
            ModifyAbilityReference("Prism Slash", "prismSlashI");
            addTypeOf("crystal", 1.0);
            description = "A single powerful strike to your opponent leaves their defenses weakened.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 28.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.04;

            //stamina usage
            m_doBaseStaminaCost = 10.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            double defN = target.DynamicDefense * 0.7;
            target.DoModifyDefense(defN);
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new PrismSlash());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Exsanguinate : SQAbility
    {
        public Exsanguinate()
        {
            ModifyAbilityReference("Exsanguinate", "exsanguinate");
            addTypeOf("dark", 1.0);
            description = "Causes your enemy to bleed.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 33.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.2;

            //stamina usage
            m_doBaseStaminaCost = 23.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            target.AddEffect(new Effects.ExsanguinateEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Exsanguinate());
            return 1;
        }
    }
}

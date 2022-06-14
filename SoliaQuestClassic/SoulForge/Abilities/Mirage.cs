using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Mirage : SQAbility
    {
        public Mirage()
        {
            ModifyAbilityReference("Mirage", "mirage");
            addTypeOf("light", 1.0);
            description = "A trick of light confuses your opponent. Your EVADE stat increases.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 15.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.12;

            //stamina usage
            m_doBaseStaminaCost = 9.5;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.AddEffect(new Effects.MirageEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Mirage());
            return 1;
        }
    }
}

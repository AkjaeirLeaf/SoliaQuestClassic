using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Whisper : SQAbility
    {
        public Whisper()
        {
            ModifyAbilityReference("Whisper", "whisper");
            addTypeOf("spirit", 1.0);
            description = "A trick of light confuses your opponent. Your EVADE stat increases.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 21.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 8.0;

            //id like to add another bonus tho

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.01;

            //stamina usage
            m_doBaseStaminaCost = 15;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.DoModifyEvade(sender.Evade * 1.15);
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Whisper());
            return 1;
        }
    }
}

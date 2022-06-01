using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Mirror : SQAbility
    {
        public Mirror()
        {
            ModifyAbilityReference("Mirror", "mirror");
            addTypeOf("light", 0.0);
            description = "The next attack on your creature will be partially reflected.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 0.0;
            m_doBaseDamageSelf   = 0.0;
            m_doBaseHealTarget   = 0.0;
            m_doBaseHealSelf     = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.00;

            //stamina usage
            m_doBaseStaminaCost = 8.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            sender.AddEffect(new Effects.MirrorEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Mirror());
            return 1;
        }
    }
}

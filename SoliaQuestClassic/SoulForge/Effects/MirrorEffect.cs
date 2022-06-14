using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class MirrorEffect : SQEffect
    {
        public MirrorEffect()
        {
            ModifyEffectReference("Mirror", "mirrorEffect");
            tooltip = "The next attack that hits you will be partially reflected.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        private bool didReflect = false;
        public override int EffectEvent_DoAbilityUsedOn(SQAbility ability, SQCreature effected, SQCreature sender)
        {
            //for  MIRROR we want the ability used on by opponent/attacker to be reflected.
            SQAbilityInfo abilityUsed = sender.GetAbilityInfo(ability.InternalName);
            abilityUsed.doDamageTarget *= 0.5;

            sender.DoDamage(abilityUsed);
            didReflect = true;
            if (didReflect && didBlock) { effected.RemoveEffect(this.InternalName); }
            return 0;
        }

        private bool didBlock = false;
        public override SQAbilityInfo PreDoDamage(SQAbilityInfo incoming, SQCreature effected, bool dodged = false)
        {
            didBlock = true;
            if (didReflect && didBlock) { effected.RemoveEffect(this.InternalName); }
            SQAbilityInfo incAbility = incoming;
            incAbility.doDamageTarget *= 0.5;
            return incAbility;
        }
    }
}

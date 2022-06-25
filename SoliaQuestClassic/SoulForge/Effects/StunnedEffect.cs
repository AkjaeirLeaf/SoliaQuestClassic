using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class StunnedEffect : SQEffect
    {
        public StunnedEffect()
        {
            ModifyEffectReference("Stunned", "stunnedEffect");
            tooltip = "You\'re stunned, the next ability is likely to fail.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        public override SQAbilityInfo EffectEvent_OnUseAbility(SQAbilityInfo ability, SQCreature effected, SQCreature target)
        {
            //stall ability with updated PostUseAbility event
            effected.RemoveEffect(InternalName);
            return ability;
        }
    }
}

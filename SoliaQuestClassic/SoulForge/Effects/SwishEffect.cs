using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class SwishEffect : SQEffect
    {
        public SwishEffect()
        {
            ModifyEffectReference("Swish", "swishEffect");
            tooltip = "Your defense has been increased against the next attack.";
            stackMax = 10;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        public override SQAbilityInfo PreDoDamage(SQAbilityInfo incoming, SQCreature effected, bool dodged = false)
        {
            if (!dodged)
            {
                int stack = 1;
                for (int i = 0; i < effected.ActiveEffects.Length; i++)
                {
                    if (effected.ActiveEffects[i].InternalName == this.InternalName) { stack = effected.EffectsStack[i]; }
                }

                SQAbilityInfo incAbility = incoming;
                incAbility.doDamageTarget *= 1 - (0.1 * stack);
                effected.RemoveEffect(this.InternalName);
                return incAbility;
            }
            return incoming;
        }
    }
}

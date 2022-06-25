using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class SatisfiedEffect : SQEffect
    {
        private int timeRemainingCustom = 5;

        public SatisfiedEffect()
        {
            ModifyEffectReference("Satisfied", "satisfiedEffect");
            tooltip = "The food tasted so good that your stats increase and incoming damage is slightly reduced.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
            
        }

        public override SQAbilityInfo PreDoDamage(SQAbilityInfo incoming, SQCreature effected, bool dodged = false)
        {
            double block = timeRemainingCustom * 0.2 * 0.4;
            SQAbilityInfo incAbility = incoming;
            incAbility.doDamageTarget *= (1 - block);
            timeRemainingCustom--;
            if(timeRemainingCustom == 0) { effected.RemoveEffect(this.InternalName); }
            return incAbility;
        }
    }
}

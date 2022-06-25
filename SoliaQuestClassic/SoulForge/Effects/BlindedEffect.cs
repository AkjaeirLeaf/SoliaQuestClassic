using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class BlindedEffect : SQEffect
    {
        private int timeRemainingCustom = 4;

        public BlindedEffect()
        {
            ModifyEffectReference("Blinded", "blinded");
            tooltip = "It\'s hard to see your opponent.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        public override int EffectEvent_DoTick(SQCreature effected)
        {
            timeRemainingCustom--;
            if(timeRemainingCustom <= 0)
            {
                effected.RemoveEffect(InternalName);    
            }
            return 0;
        }

        public override SQAbilityInfo EffectEvent_OnUseAbility(SQAbilityInfo ability, SQCreature effected, SQCreature target)
        {
            //switch from int to SQAbilityInfo, 
            ability.abilityDodgeChance *= 2.3;
            return ability;
        }
    }
}

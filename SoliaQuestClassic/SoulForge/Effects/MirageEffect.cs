using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class MirageEffect : SQEffect
    {
        public MirageEffect()
        {
            ModifyEffectReference("Mirage", "mirageEffect");
            tooltip = "Your opponent cannot easily distinguish your position.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        public override int EffectEvent_Activated(SQCreature effected)
        {
            effected.DoModifyEvade(1.5 * effected.DynamicEvade);
            return 1;
        }
    }
}

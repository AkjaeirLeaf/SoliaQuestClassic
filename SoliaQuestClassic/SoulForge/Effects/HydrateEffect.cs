using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class HydrateEffect : SQEffect
    {
        public HydrateEffect()
        {
            ModifyEffectReference("Hydrated", "hydrateEffect");
            tooltip = "You're fully saturated!";
            stackMax = 1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        public override int EffectEvent_Activated(SQCreature effected)
        {
            effected.AddDynamicTyping("water");

            return base.EffectEvent_Activated(effected);
        }

        public override int EffectEvent_RemoveEffect(SQCreature effected)
        {
            effected.RemoveDynamicTyping("water");
            effected.DoModifyDefense(effected.DynamicDefense + effected.DefaultDefense / 2);
            effected.DoModifyEvade(effected.DynamicEvade * 0.82);

            return base.EffectEvent_RemoveEffect(effected);
        }

    }
}

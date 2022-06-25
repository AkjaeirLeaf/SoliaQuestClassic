using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class RawMushroomEffect : SQEffect
    {
        public RawMushroomEffect()
        {
            ModifyEffectReference("Mushroom Poisoning", "rawMushroomEffect");
            tooltip = "That mushroom you ate had some interesting side effects.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
            m_tickBaseDamageTarget = 13;
        }

        private int timeRemainingCustom = 5;
        public override int EffectEvent_DoTick(SQCreature effected)
        {
            //add poison damage maybe...
            SQType dark;
            if(SQWorld.SQWorldTypeList.TryGetValue("dark", out dark))
            {
                SQAbilityInfo info = new SQAbilityInfo();
                info.abilityDisplay = "Mushroom Poisoning";
                info.abilityType = new SQType[] { dark };
                info.doDamageTarget = this.m_tickBaseDamageTarget * (timeRemainingCustom * 0.1);
                double oldDefense = effected.DynamicDefense;

                effected.DoDamage(info);
                timeRemainingCustom--;
                if (timeRemainingCustom <= 0)
                {
                    effected.RemoveEffect(this.InternalName);
                }
                return 1;
            }
            return -1;
        }
    }
}

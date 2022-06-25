using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class OnFireEffect : SQEffect
    {
        public OnFireEffect()
        {
            ModifyEffectReference("On Fire", "onFireEffect");
            tooltip = "The fire remains.";
            stackMax = 3;
            doShowEffect = true;
            m_timeLeft = -1;
            m_tickBaseDamageTarget = 15;
        }

        int timeRemainingCustom = 5;
        public override int EffectEvent_DoTick(SQCreature effected)
        {
            SQType fireType;
            if(SQWorld.SQWorldTypeList.TryGetValue("fire", out fireType))
            {
                SQAbilityInfo info = new SQAbilityInfo();
                info.abilityDisplay = "On Fire";
                info.abilityType = new SQType[] { fireType };
                info.doDamageTarget = this.m_tickBaseDamageTarget * (timeRemainingCustom * 0.1);

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

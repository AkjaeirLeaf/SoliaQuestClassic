using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class ExsanguinateEffect : SQEffect
    {
        private int timeRemainingCustom = 4;

        public ExsanguinateEffect()
        {
            ModifyEffectReference("Exsanguinate", "exsanguinate");
            tooltip = "You're slowly bleeding out.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
            m_tickBaseDamageTarget = 13;
        }

        public override int EffectEvent_DoTick(SQCreature effected)
        {
            SQType darkType;
            if(SQWorld.SQWorldTypeList.TryGetValue("dark", out darkType))
            {
                SQAbilityInfo info = new SQAbilityInfo();
                info.abilityDisplay = "Exsanguinate";
                info.abilityType = new SQType[] { darkType };
                info.doDamageTarget = this.m_tickBaseDamageTarget;

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

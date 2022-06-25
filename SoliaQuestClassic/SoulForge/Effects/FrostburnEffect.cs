using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class FrostburnEffect : SQEffect
    {
        public FrostburnEffect()
        {
            ModifyEffectReference("Frostburn", "frostburnEffect");
            tooltip = "The ice burns as hot as fire.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
            m_tickBaseDamageTarget = 12;
        }

        private int timeRemainingCustom = 5;
        public override int EffectEvent_DoTick(SQCreature effected)
        {
            SQType fireType;
            SQType iceType;
            if(SQWorld.SQWorldTypeList.TryGetValue("fire", out fireType)
                &&  SQWorld.SQWorldTypeList.TryGetValue("ice", out iceType))
            {
                SQAbilityInfo info = new SQAbilityInfo();
                info.abilityDisplay = "Frostburn";
                info.abilityType = new SQType[] { fireType, iceType };
                info.doDamageTarget = this.m_tickBaseDamageTarget * (timeRemainingCustom * 0.1);
                double oldDefense = effected.DynamicDefense;
                effected.DoModifyDefense(oldDefense *= .97);

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

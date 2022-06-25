using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class BlossomEffect : SQEffect
    {
        public BlossomEffect()
        {
            ModifyEffectReference("Blossom", "blossomEffect");
            tooltip = "A defensive garden grows around you.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        int timeRemainingCustom = 5;
        public override int EffectEvent_DoTick(SQCreature effected)
        {
            SQType lightType;
            SQType plantType;
            if(SQWorld.SQWorldTypeList.TryGetValue("light", out lightType)
                && SQWorld.SQWorldTypeList.TryGetValue("plant", out plantType))
            {
                SQAbilityInfo info = new SQAbilityInfo();
                info.abilityDisplay = "Blossom";
                info.abilityType = new SQType[] { lightType, plantType };
                info.doHealTarget = 18 * (timeRemainingCustom * 0.2);

                effected.DoHeal(info);
                timeRemainingCustom--;
                if (timeRemainingCustom <= 0)
                {
                    effected.RemoveEffect(this.InternalName);
                }
                return 1;
            }
            return -1;
        }

        public override SQAbilityInfo PreDoDamage(SQAbilityInfo incoming, SQCreature effected, bool dodged = false)
        {
            //didBlock = true;
            //if (didReflect && didBlock) { effected.RemoveEffect(this.InternalName); }
            //SQAbilityInfo incAbility = incoming;
            //incAbility.doDamageTarget *= (1 - (0.2 * timeRemainingCustom));
            return incoming;
        }
    }
}

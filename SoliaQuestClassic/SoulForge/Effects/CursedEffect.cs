using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class CursedEffect : SQEffect
    {
        private int timeRemainingCustom = 4;
        private SQAbility usedOnAbility = new Abilities.BlankStare();

        public CursedEffect()
        {
            ModifyEffectReference("Cursed", "cursedEffect");
            tooltip = "You're still being hurt from this.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
            
        }

        public void SetUseAbility(SQAbility usedAbility, SQCreature target)
        {
            usedOnAbility = usedAbility;
            m_tickBaseDamageTarget = usedAbility.GetDealDamageTarget(target);
        }

        public override int EffectEvent_DoTick(SQCreature effected)
        {
            string[] types = usedOnAbility.AbilityType;
            SQType[] trueTypes = new SQType[types.Length];
            for(int t = 0; t < types.Length; t++)
            {
                SQWorld.SQWorldTypeList.TryGetValue(types[t], out trueTypes[t]);
            }

            SQAbilityInfo info = new SQAbilityInfo();
            info.abilityDisplay = "Cursed";
            info.abilityType = trueTypes;
            info.targetDodges = false;
            info.doDamageTarget = this.m_tickBaseDamageTarget * (timeRemainingCustom * 0.2);

            effected.DoDamage(info);
            timeRemainingCustom--;
            if (timeRemainingCustom <= 0)
            {
                effected.RemoveEffect(this.InternalName);
            }
            return 1;
        }
    }
}

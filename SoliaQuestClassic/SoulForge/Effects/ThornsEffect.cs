using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class ThornsEffect : SQEffect
    {
        public ThornsEffect()
        {
            ModifyEffectReference("Thorns", "thornsEffect");
            tooltip = "Your body is covered in spiky thorns, attacks on you deal damage back to the attacker.";
            stackMax = 1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        public override int EffectEvent_DoAbilityUsedOn(SQAbility ability, SQCreature effected, SQCreature sender)
        {
            if(ability.Category == SQAbilityCategory.PHYSICAL) //true is for test only remove after
            {
                string[] types = new string[] { "plant", "toxic" };
                SQType[] trueTypes = new SQType[types.Length];
                for (int t = 0; t < types.Length; t++)
                {
                    SQWorld.SQWorldTypeList.TryGetValue(types[t], out trueTypes[t]);
                }

                SQAbilityInfo info = new SQAbilityInfo();
                info.abilityDisplay = "Thorned";
                info.abilityType = trueTypes;
                info.targetDodges = false;
                info.doDamageTarget = 13; //flat

                effected.DoDamage(info);
            }

            
            return base.EffectEvent_DoAbilityUsedOn(ability, effected, sender);
        }
    }
}

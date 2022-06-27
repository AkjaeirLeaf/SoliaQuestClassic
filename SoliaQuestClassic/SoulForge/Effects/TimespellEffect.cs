using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class TimespellEffect : SQEffect
    {
        public TimespellEffect()
        {
            ModifyEffectReference("Timespell", "timespellEffect");
            tooltip = "A strange shell of energy causes the opponents\' attacks to be slowed down, however you cannot dodge them once they come through.";
            stackMax = -1;
            doShowEffect = true;
            removePostCombat = true;
            m_timeLeft = -1;
        }

        int timeRemainingCustom = 7;
        public override int EffectEvent_DoTick(SQCreature effected)
        {
            if (abilitiesStorage.Length >= 1)
            {
                for (int a = 0; a < abilitiesStorage.Length; a++)
                {
                    //do some of the damage
                    SQAbilityInfo ab = new SQAbilityInfo();
                    ab.abilityType = abilitiesStorage[a].abilityType;
                    ab.doDamageTarget = abilitiesStorage[a].doDamageTarget * .125;

                    ab.abilityDisplay = abilitiesStorage[a].abilityDisplay;
                    ab.criticalHit = abilitiesStorage[a].criticalHit;
                    ab.flavorText = abilitiesStorage[a].flavorText;
                    ab.senderControl = abilitiesStorage[a].senderControl;
                    ab.source = SQDamageSource.Effect;

                    effected.DoDamage(ab, true);
                }
            }
            timeRemainingCustom--;
            if(timeRemainingCustom <= 0) { effected.RemoveEffect(this.InternalName); }
            return 1;
        }

        private SQAbilityInfo[] abilitiesStorage = new SQAbilityInfo[0];
        public override SQAbilityInfo PreDoDamage(SQAbilityInfo incoming, SQCreature effected, bool dodged = false)
        {
            if (!incoming.targetDodges && incoming.source == SQDamageSource.Ability)
            {
                if (abilitiesStorage.Length >= 1)
                {
                    SQAbilityInfo[] sqt = new SQAbilityInfo[abilitiesStorage.Length + 1];
                    for (int i = 0; i < abilitiesStorage.Length; i++)
                    {
                        SQAbilityInfo sv = abilitiesStorage[i];
                        sv.source = SQDamageSource.Effect;
                        sqt[i] = sv;
                    }
                    sqt[abilitiesStorage.Length] = incoming;
                    abilitiesStorage = sqt;
                }
                else
                {
                    SQAbilityInfo sv = incoming;
                    sv.source = SQDamageSource.Effect;
                    abilitiesStorage = new SQAbilityInfo[] { sv };
                }


                SQAbilityInfo ab = new SQAbilityInfo();
                ab.abilityType    = incoming.abilityType;
                ab.doDamageTarget = incoming.doDamageTarget * .125;

                ab.abilityDisplay = incoming.abilityDisplay;
                ab.criticalHit    = incoming.criticalHit;
                ab.flavorText     = incoming.flavorText;
                ab.senderControl  = incoming.senderControl;

                return ab;
            }

            return incoming;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class BlessingEffect : SQEffect
    {
        public BlessingEffect()
        {
            ModifyEffectReference("Blessed", "blessing");
            tooltip = "The spirits of Kiravael defend you.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
        }

        //add preDamage
        private double controlIncreased = 0;
        private double lastControlValue = 0;

        public override int EffectEvent_Activated(SQCreature effected)
        {
            double controlStat = effected.DynamicControl;
            controlIncreased = controlStat;
            effected.AddTag("blessedIncreaseControl", controlStat);
            effected.DoModifyControl(controlStat * 2);
            lastControlValue = effected.DynamicControl;
            return 0;
        }

        public override int EffectEvent_DoTick(SQCreature effected)
        {
            double updatedCStat = effected.DynamicControl;
            if(controlIncreased != (updatedCStat / 2))
            {
                double newValue = (updatedCStat - controlIncreased) * 2;
                controlIncreased = newValue / 2;
                effected.DoModifyControl(newValue);
                lastControlValue = effected.DynamicControl;
            }
            return 0;
        }

        private void EffectEvent_Deactivated(SQCreature effected)
        {
            lastControlValue = effected.DynamicControl;
            effected.DoModifyControl(lastControlValue - controlIncreased);
            effected.RemoveEffect(InternalName);
        }

        public virtual SQAbilityInfo PreDoDamage(SQAbilityInfo incoming, SQCreature effected, bool dodged = false)
        {
            if(!dodged)
            {
                double initialDamage = incoming.doDamageTarget;
                if(initialDamage >= effected.DynamicHealth + effected.DynamicDefense)
                {
                    incoming.doDamageTarget = 0;
                    //impl deactivateEvent
                    EffectEvent_Deactivated(effected);
                }
            }
            return incoming;
        }

        //add event Deactivated event
    }
}

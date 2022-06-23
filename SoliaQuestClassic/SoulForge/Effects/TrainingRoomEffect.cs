using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class TrainingRoomEffect : SQEffect
    {
        public TrainingRoomEffect()
        {
            ModifyEffectReference("Training Room", "trainingRoomEffect");
            tooltip = "Upon using an ability, your STAMINA is restored.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
            removePostCombat = true;
        }

        public override int EffectEvent_PostUseAbility(SQAbility ability, SQCreature effected)
        {
            if (effected.DynamicStamina < effected.Stamina)
            {
                effected.DoModifyStamina(effected.Stamina);
            }
            return 0;
        }
    }
}

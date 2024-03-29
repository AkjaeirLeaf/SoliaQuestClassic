﻿using System;
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

        public override SQAbilityInfo EffectEvent_OnUseAbility(SQAbilityInfo ability, SQCreature effected, SQCreature target)
        {
            if (effected.DynamicStamina < effected.Stamina)
            {
                effected.DoModifyStamina(effected.Stamina);
            }
            return ability;
        }
    }
}

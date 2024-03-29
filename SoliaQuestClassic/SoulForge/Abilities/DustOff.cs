﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class DustOff : SQAbility
    {
        public DustOff()
        {
            ModifyAbilityReference("Dust off", "dustOff");
            addTypeOf("air", 1.0);
            addTypeOf("stone", 1.0);
            description = "A cloud of sand makes it hard to see, your opponent's control and evade decrease.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.STAT_HIT;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 9.0;
            m_doBaseDamageSelf   = 0.0;
            m_doBaseHealTarget   = 0.0;
            m_doBaseHealSelf     = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.04;
            m_controlMod         = 0.65;

            //stamina usage
            m_doBaseStaminaCost  = 10.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {//maybe switch this to an effect?
            double evaN = target.DynamicEvade * 0.8;
            double conN = target.DynamicControl * 0.85;
            target.DoModifyEvade(evaN);
            target.DoModifyControl(conN);
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new DustOff());
            return 1;
        }
    }
}

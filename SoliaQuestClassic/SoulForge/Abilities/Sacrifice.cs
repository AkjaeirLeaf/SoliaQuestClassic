using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Sacrifice : SQAbility
    {
        public Sacrifice()
        {
            ModifyAbilityReference("Sacrifice", "sacrifice");
            addTypeOf("dark", 1.0);
            addTypeOf("spirit", 1.0);
            description = "You sacrifice half your own health to half the health of your opponent.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.ENERGY;
            abilityPurpose = SQAbilityPurpose.UNKNOWN;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  0.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     = 17.0; //after implementing teams and target selection, switch heal self to heal target

            //how possible is evading this attack?
            m_dodgeCompdChance   = 0.00;
            m_controlMod         = 0.60;

            //stamina usage
            m_doBaseStaminaCost  = 17.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            //sender.AddEffect(new Effects.SacrificeEffect());
        }

        public override void OnAbilityUsedOn(SQCreature target)
        {
            //target.AddEffect(new Effects.SacrificeEffect());
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Sacrifice());
            return 1;
        }
    }
}

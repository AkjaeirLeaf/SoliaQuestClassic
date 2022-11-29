using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class Sunbathe : SQAbility
    {
        public Sunbathe()
        {
            ModifyAbilityReference("Sunbathe", "sunbathe");
            addTypeOf("typeless", 1.0);
            description = "Spend the turn basking in the light; Stamina replenishes and Attack increases.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 0.0;
            m_doBaseDamageSelf   = 0.0;
            m_doBaseHealTarget   = 0.0;
            m_doBaseHealSelf     = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.00;
            m_controlMod = 0.70;

            //stamina usage
            m_doBaseStaminaCost = 2.0;

            //I will use the base ability damage info here :)
        }

        public Sunbathe(string specifyType)
        {
            ModifyAbilityReference("Sunbathe", "sunbathe");
            addTypeOf(specifyType, 1.0);
            description = "Spend the turn basking in the light; Stamina replenishes and Attack increases.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;
            abilityPurpose = SQAbilityPurpose.STAT_BOOST;

            //set base damage / heal stuff
            m_doBaseDamageTarget =  0.0;
            m_doBaseDamageSelf   =  0.0;
            m_doBaseHealTarget   =  0.0;
            m_doBaseHealSelf     =  0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.00;
            m_controlMod       = 0.70;

            //stamina usage
            m_doBaseStaminaCost = 2.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            //boost attack, replenish stams
            sender.DoModifyStamina(sender.DefaultStamina); //fill stamina meter
            sender.DoModifyAttack(sender.DynamicAttack * 1.1);


            base.OnAbilityUse(sender);
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new Sunbathe());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Abilities
{
    public class UseItem : SQAbility
    {
        public UseItem()
        {
            ModifyAbilityReference("Use Item", "useItem");
            addTypeOf("typeless", 1.0);
            description = "Allows you to use an item in a fight.";
            doShowAbility = true;
            abilityCategory = SQAbilityCategory.PHYSICAL;

            //set base damage / heal stuff
            m_doBaseDamageTarget = 0.0;
            m_doBaseDamageSelf = 0.0;
            m_doBaseHealTarget = 0.0;
            m_doBaseHealSelf = 0.0;

            //how possible is evading this attack?
            m_dodgeCompdChance = 0.0;

            //stamina usage
            m_doBaseStaminaCost = 0.0;

            //I will use the base ability damage info here :)
        }

        public override void OnAbilityUse(SQCreature sender)
        {
            object isactive;
            if(sender.TryGetTag("tag_isActiveUser", out isactive))
            {
                if ((bool)isactive)
                {//creature verified to be the player, show item selection UI.
                    UseItemPopupSelect uips = new UseItemPopupSelect(sender);
                    uips.ShowDialog();
                }
                else
                {//creature verified to be an automated entity.

                }
            }
            else
            {

            }
        }

        public static int RegisterAbility()
        {
            SQWorld.Register(new UseItem());
            return 1;
        }
    }
}

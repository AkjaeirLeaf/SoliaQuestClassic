using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Items.FoodItems
{
    public class Carrot : SQItem
    {
        public Carrot()
        {
            familyID = 2;
            subFamilyID = 1;
            displayName = "Carrot";
            description = "Replenishes your stats a small amount.";
            itemRarityID = 0;
            maxStackSize = 999;
            canUseItem = true;
            canUseCombat = true;
            removeWhenZero = true;
        }

        public override int UseItem(SQCreature sender, SQItemStack itemStack)
        {
            if (itemStack.canDecr(1))
            {
                SQAbilityInfo sqai = new SQAbilityInfo();
                sqai.doHealSelf = 20;
                sqai.doHealTarget = 20;
                sqai.doStaminaSelf = 10;
                sqai.doStaminaTarget = 10;
                sender.DoHeal(sqai);
                itemStack.Decrease(1);
            }
            return 0;
        }

        public override int[] GetImages()
        {
            return new int[] { 1 };
        }

        public override object GetItemProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "useInfo":
                    return "Use this item to heal and replenish stats.";
                default:
                    return base.GetItemProperty(propertyName);
            }
        }
    }
}

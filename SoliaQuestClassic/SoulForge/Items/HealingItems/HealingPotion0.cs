using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Items.HealingItems
{
    public class HealingPotion0 : SQItem
    {
        public HealingPotion0()
        {
            familyID = 1;
            subFamilyID = 0;
            displayName = "Minor Healing Potion";
            description = "Heals 50 health instantly.";
            itemRarityID = 0;
            maxStackSize = 16;
            canUseItem = true;
            canUseCombat = true;
            removeWhenZero = true;
        }

        public override int UseItem(SQCreature sender, SQItemStack itemStack)
        {
            if (itemStack.canDecr(1))
            {
                SQAbilityInfo sqai = new SQAbilityInfo();
                sqai.doHealSelf = 50;
                sqai.doHealTarget = 50;
                sender.DoHeal(sqai);
                itemStack.Decrease(1);
            }
            return 0;
        }

        public override int[] GetImages()
        {
            return new int[] { 0 };
        }

        public override object GetItemProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "useInfo":
                    return "Use this item to heal your creature 50 hp.";
                default:
                    return base.GetItemProperty(propertyName);
            }
        }
    }
}

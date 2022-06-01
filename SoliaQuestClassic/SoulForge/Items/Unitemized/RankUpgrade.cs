using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Items.Unitemized
{
    public class RankUpgrade : SQItem
    {
        public RankUpgrade()
        {
            familyID = 0;
            subFamilyID = 5;
            displayName = "Rank Upgrade Token";
            description = "Use this to upgrade your creature\'s rank.\nOnly usable when all stats have been upgraded.";
            itemRarityID = 3;
            maxStackSize = 1;
            canUseItem = true;
            removeWhenZero = true;
        }

        public override int UseItem(SQCreature sender, SQItemStack itemStack)
        {
            if (itemStack.canDecr(1))
            {
                SQStatUpgradeInfo sui = sender.CanUpgradeStats();
                if (sui.canUpgrade)
                {
                    sender.UpgradeRank(sui);
                    itemStack.Decrease(1);
                }
            }
            return 0;
        }

        public override int[] GetImages()
        {
            return new int[] { 5 };
        }

        public override object GetItemProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "useInfo":
                    return "Your creature\'s primary rank will be upgraded if you have high enough stats.";
                default:
                    return base.GetItemProperty(propertyName);
            }
        }
    }
}

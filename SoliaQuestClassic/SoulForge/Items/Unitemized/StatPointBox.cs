using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Items.Unitemized
{
    public class StatPointBox : SQItem
    {
        private int pointValue = 0;

        public StatPointBox(int pointCt)
        {
            pointValue = pointCt;

            familyID = 0;
            subFamilyID = 4;
            displayName = "Box of Stat Points";
            description = "Contains " + pointCt + " points to use on upgrading your creatures!";
            itemRarityID = 3;
            maxStackSize = 1;
            canUseItem = true;
            removeWhenZero = true;
        }

        public override int UseItem(SQCreature sender, SQItemStack itemStack)
        {
            if (itemStack.canDecr(1))
            {
                sender.GrantStatPoints(pointValue);
                itemStack.Decrease(1);
            }
            return 0;
        }

        public override int[] GetImages()
        {
            return new int[] { 4 };
        }

        public override object GetItemProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "useInfo":
                    return "Grant " + pointValue + " points to your creature.";
                default:
                    return base.GetItemProperty(propertyName);
            }
        }
    }
}

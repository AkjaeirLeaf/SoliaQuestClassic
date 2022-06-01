using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ItemFamilies
{
    class HealingItems : SQItemFamily
    {
        public HealingItems() : base(1, "healingItems")
        {
            //add images
            AddItemImage(0, "SoliaQuestClassic.Resources.Families.r001healing.00health0.png");

            //add items
            LinkItemTo(new Items.HealingItems.HealingPotion0());

            LoadImages();
        }

        public static int Register()
        {
            SQWorld.Register(new HealingItems());
            return 0;
        }
    }
}

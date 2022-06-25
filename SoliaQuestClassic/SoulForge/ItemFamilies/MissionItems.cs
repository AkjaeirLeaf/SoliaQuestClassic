using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ItemFamilies
{
    class MissionItems : SQItemFamily
    {
        public MissionItems() : base(16, "missionItems")
        {
            //add images
            //AddItemImage(0, "SoliaQuestClassic.Resources.Families.r001healing.00health0.png");

            //add items
            //LinkItemTo(new Items.HealingItems.HealingPotion0());

            LoadImages();
        }

        public static int Register()
        {
            SQWorld.Register(new MissionItems());
            return 0;
        }
    }
}

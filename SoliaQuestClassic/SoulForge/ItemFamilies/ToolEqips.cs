using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ItemFamilies
{
    public class ToolEquips : SQItemFamily
    {
        public ToolEquips() : base(10, "toolEquips")
        {
            //add images
            //AddItemImage(1, "SoliaQuestClassic.Resources.Families.r002foodItems.01carrot.png");

            //add items
            //LinkItemTo(new Items.FoodItems.Carrot());

            LoadImages();
        }

        public static int Register()
        {
            SQWorld.Register(new ToolEquips());
            return 0;
        }

    }
}

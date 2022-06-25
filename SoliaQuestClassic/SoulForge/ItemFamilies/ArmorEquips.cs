using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ItemFamilies
{
    public class ArmorEquips : SQItemFamily
    {
        public ArmorEquips() : base(13, "armorEquips")
        {
            //add images
            //AddItemImage(1, "SoliaQuestClassic.Resources.Families.r002foodItems.01carrot.png");

            //add items
            //LinkItemTo(new Items.FoodItems.Carrot());

            LoadImages();
        }

        public static int Register()
        {
            SQWorld.Register(new ArmorEquips());
            return 0;
        }

    }
}

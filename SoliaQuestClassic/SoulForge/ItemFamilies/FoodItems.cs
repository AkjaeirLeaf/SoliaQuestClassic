using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ItemFamilies
{
    public class FoodItems : SQItemFamily
    {
        public FoodItems() : base(2, "foodItems")
        {
            //add images
            AddItemImage(1, "SoliaQuestClassic.Resources.Families.r002foodItems.01carrot.png");
            AddItemImage(2, "SoliaQuestClassic.Resources.Families.r002foodItems.02caramelizedCarrot.png");
            AddItemImage(3, "SoliaQuestClassic.Resources.Families.r002foodItems.03potato.png");
            AddItemImage(4, "SoliaQuestClassic.Resources.Families.r002foodItems.04bakedPotato.png");

            //add items
            LinkItemTo(new Items.FoodItems.Carrot());

            LinkItemTo(new Items.FoodItems.BakedPotato());

            LoadImages();
        }

        public static int Register()
        {
            SQWorld.Register(new FoodItems());
            return 0;
        }

    }
}

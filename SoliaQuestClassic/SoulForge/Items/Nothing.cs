using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Items
{
    public class Nothing : SQItem
    {
        public Nothing()
        {
            familyID = 0;
            subFamilyID = 0;

            displayName = "";
            description = "";

            itemRarityID = 0;
            maxStackSize = -1;
            canUseItem = false;
            removeWhenZero = false;
        }
    }
}

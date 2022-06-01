using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ColorMods
{
    public class Prismatic : SQColorMod
    {
        public Prismatic()
        {
            internalID = "prismatic";
            displayName = "Prismatic";
            probability = 1.0 / 710000;
            overtype = SQColorModOverridesType.attemptAdd;
            power = 1;
        }

        public static int RegisterColorMod()
        {
            SQWorld.Register(new Prismatic());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ColorMods
{
    public class Vibrant : SQColorMod
    {
        public Vibrant()
        {
            internalID = "vibrant";
            displayName = "Vibrant";
            probability = 1.0 / 11000;
            overtype = SQColorModOverridesType.attemptAdd;
            power = 1;
        }

        public static int RegisterColorMod()
        {
            SQWorld.Register(new Vibrant());
            return 1;
        }
    }
}

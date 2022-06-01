using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ColorMods
{
    public class Negative : SQColorMod
    {
        public Negative()
        {
            internalID = "negative";
            displayName = "Negative";
            probability = 1.0 / 55500;
            overtype = SQColorModOverridesType.attemptAdd;
            power = 1;
        }

        public static int RegisterColorMod()
        {
            SQWorld.Register(new Negative());
            return 1;
        }
    }
}

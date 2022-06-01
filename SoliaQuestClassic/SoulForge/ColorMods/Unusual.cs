using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ColorMods
{
    public class Unusual : SQColorMod
    {
        public Unusual()
        {
            internalID = "unusual";
            displayName = "Unusual";
            probability = 1.0 / 620;
            overtype = SQColorModOverridesType.attemptAdd;
            power = 1;
        }

        public static int RegisterColorMod()
        {
            SQWorld.Register(new Unusual());
            return 1;
        }
    }
}

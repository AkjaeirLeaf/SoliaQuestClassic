using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ColorMods
{
    public class Leucistic : SQColorMod
    {
        public Leucistic()
        {
            internalID = "leucistic";
            displayName = "Leucistic";
            probability = 1.0 / 33000;
            overtype = SQColorModOverridesType.attemptAdd;
            power = 1;
        }

        public static int RegisterColorMod()
        {
            SQWorld.Register(new Leucistic());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ColorMods
{
    public class Default : SQColorMod
    {
        public Default()
        {
            doDisplayName = false;
            internalID = "default";
            displayName = ""; // no need to display!
            probability = 1.0 / 1;
            overtype = SQColorModOverridesType.overrideNone;
            power = 0;
        }

        public static int RegisterColorMod()
        {
            SQWorld.Register(new Default());
            return 1;
        }
    }
}

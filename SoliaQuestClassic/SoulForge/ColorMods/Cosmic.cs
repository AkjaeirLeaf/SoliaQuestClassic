using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.ColorMods
{
    public class Cosmic : SQColorMod
    {
        public Cosmic()
        {
            internalID = "cosmic";
            displayName = "Cosmic";
            probability = 1.0 / 1111111;
            overtype = SQColorModOverridesType.attemptAdd;
            power = 1;
        }

        public static int RegisterColorMod()
        {
            SQWorld.Register(new Cosmic());
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQColorMod
    {
        protected bool doDisplayName = true;
        public bool DoDisplayName { get { return doDisplayName; } }
        //internal id must be unique
        protected string internalID = "";
        public string InternalID { get { return internalID; } }

        //display name does not need to be unique
        protected string displayName = "";
        public string Display { get { return displayName; } }

        //what's the base probablility of this mod appearing?
        protected double probability = 0;
        public double BaseProbability { get { return probability; } }

        //which other stat modifiers does this mod override?
        private string[] overrides = new string[0];
        public string[] ModOverridesList { get { return overrides; } }
        //or you can just use a general override without a special array.
        protected SQColorModOverridesType overtype = SQColorModOverridesType.attemptAdd;
        public SQColorModOverridesType OverrideType { get { return overtype; } }
        protected int power = 0;
        public int ColorModPower { get { return power; } }
        public SQColorMod()
        {

        }

    }

    public enum SQColorModOverridesType
    {
        useArray,
        overrideLower,
        overrideHigher,
        overrideAll,
        overrideNone,
        attemptAdd
    }
}

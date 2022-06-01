using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQStatMod
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
        protected SQStatModOverridesType overtype = SQStatModOverridesType.overrideNone;
        public SQStatModOverridesType OverrideType { get { return overtype; } }
        protected int power = 0;
        public int StatModPower { get { return power; } }
        public SQStatMod()
        {
            
        }

        bool UseDefaultFunction = true;
        public virtual double defaultFunction(double x, double input = -1)
        {
            return 0;
        }

        public virtual double GetStatHealth(double baseHealth)
        {
            return baseHealth;

        }
        public virtual double GetStatDefense(double baseDefense)
        {
            return baseDefense;

        }
        public virtual double GetStatAttack(double baseAttack)
        {
            return baseAttack;

        }
        public virtual double GetStatStamina(double baseStamina)
        {
            return baseStamina;

        }
        public virtual double GetStatEvade(double baseEvade)
        {
            return baseEvade;

        }
        public virtual double GetStatControl(double baseControl)
        {
            return baseControl;

        }
    }

    public enum SQStatModOverridesType
    {
        useArray,
        overrideLower,
        overrideHigher,
        overrideAll,
        overrideNone
    }
}

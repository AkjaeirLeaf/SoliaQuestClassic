using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge.StatMods
{
    public class Deadly : SQStatMod
    {
        public Deadly()
        {
            internalID = "deadly";
            displayName = "Deadly";
            probability = 1.0/130;
            overtype = SQStatModOverridesType.overrideLower;
            power = 3;
        }

        public static int RegisterStatMod()
        {
            SQWorld.Register(new Deadly());
            return 1;
        }

        //do stat overrides
        public const double STAT_WAVER = 0.42;
        public const double STAT_INCREASE = 1.3;
        public static double StatFunction(double baseStat, double input)
        {
            Deadly statMod = new Deadly();
            return statMod.defaultFunction(baseStat, input);
        }
        public override double defaultFunction(double x, double input = -1)
        {
            if (input == -1)
            {
                return x * (1 + STAT_INCREASE + STAT_WAVER * 2 * (Kirali.Framework.Random.Double(0, 1) - 0.5));
            }
            else
            {
                return x * (1 + STAT_INCREASE + STAT_WAVER * 2 * (input - 0.5));
            }
        }

        public override double GetStatHealth(double baseHealth)
        {
            return defaultFunction(baseHealth);
        }
        public override double GetStatDefense(double baseDefense)
        {
            return defaultFunction(baseDefense);
        }
        public override double GetStatAttack(double baseAttack)
        {
            return defaultFunction(baseAttack);
        }
        public override double GetStatStamina(double baseStamina)
        {
            return defaultFunction(baseStamina);
        }
        public override double GetStatEvade(double baseEvade)
        {
            return defaultFunction(baseEvade);
        }
        public override double GetStatControl(double baseControl)
        {
            return defaultFunction(baseControl);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQItemPool
    {
        //Item Pools are used for reward pooling, mission rewards, and treasures.

        protected int rarity = 0;
        private SQItem[] Items = new SQItem[0];
        private double[] appearChance = new double[0];
        private int[] itemMinCount = new int[0];
        private int[] itemMaxCount = new int[0];

        public SQItemPool()
        {

        }

        public int AddReward(SQItem item, double probability, int minCount, int maxCount)
        {
            if(Items.Length == 0)
            {
                Items = new SQItem[] { item };
                appearChance = new double[] { probability };
                itemMinCount = new int[] { minCount };
                itemMaxCount = new int[] { maxCount };
                return 0;
            }
            else
            {
                Items = ArrayHandler.append(Items, item);
                appearChance = ArrayHandler.append(appearChance, probability);
                itemMinCount = ArrayHandler.append(itemMinCount, minCount);
                itemMaxCount = ArrayHandler.append(itemMaxCount, maxCount);
                return 0;
            }
        }
        //maybe add a remove reward? but im lazy

        public SQItemStack[] GetRewards()
        {
            int includeCount = 0;
            //first calculate if the items are added or not.
            bool[] includeItem = new bool[Items.Length];
            for(int ix = 0; ix < Items.Length; ix++)
            {
                double roll = Kirali.Framework.Random.Double(0,1);
                if(roll < appearChance[ix]) { includeItem[ix] = true; includeCount++; }
                else { includeItem[ix] = false; }
            }
            int place = 0;
            SQItemStack[] rewards = new SQItemStack[includeCount];
            for(int px = 0; px < Items.Length; px++)
            {
                if(includeItem[px])
                {
                    //SQItemStack(SQItem item, int count, out SQItemStack extra, bool floating = false)
                    int stackCount = Kirali.Framework.Random.Int(itemMinCount[place], itemMaxCount[place]);
                    SQItemStack newStack = new SQItemStack(Items[place], stackCount, out _, true);
                    rewards[place] = newStack;
                    place++;
                }
            }
            return rewards;
        }


    }

    public enum SQItemPoolType
    {
        misc,
        enemyCreature,
        missionReward,
        treasureBox,
        pillar,
        planetReward
    }
}
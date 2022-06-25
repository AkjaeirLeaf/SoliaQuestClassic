using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQMission
    {
        protected string missionDisplay = "";
        public string MissionDisplay { get {return missionDisplay; } }

        protected string missionInternalID = "";
        public string MissionInternalID { get {return missionInternalID; } }

        protected SQItemPool reward;
        public SQItemPool RewardPool { get { return reward; } }

        public SQMission(string missionID, string missionDisplayName, SQItemPool rewardPool)
        {
            missionDisplay = missionDisplayName;
            missionInternalID = missionID;
            reward = rewardPool;
            
        }   
    }
}
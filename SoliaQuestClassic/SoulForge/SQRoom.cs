using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQRoom
    {   
        protected string internalID = "";
        public string InternalID { get { return internalID; } }

        protected string displayName = "";
        public string DisplayName { get { return displayName; } }

        public SQRoom()
        {
            
        }
    }
}
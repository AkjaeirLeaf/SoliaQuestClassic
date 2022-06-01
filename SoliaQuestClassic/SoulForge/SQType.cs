using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQType
    {
        protected string internalName = "";
        protected string displayName = "";
        protected Bitmap typeImage;

        public string Internal { get { return internalName; } }
        public string Title { get { return displayName; } }

        private Dictionary<string, double> damageModifyIncoming = new Dictionary<string, double>();
        private Dictionary<string, double> damageModifyOutgoing = new Dictionary<string, double>();

        protected void AddIncomingDamageModify(string typeInternal, double modify) { damageModifyIncoming.Add(typeInternal, modify); }
        protected void AddOutgoingDamageModify(string typeInternal, double modify) { damageModifyOutgoing.Add(typeInternal, modify); }

        public SQType()
        {

        }

        public virtual double GetModifyDamageIncoming(string typeInternal)
        {
            double modify = 1.0;
            if (damageModifyIncoming.TryGetValue(typeInternal, out modify))
                return modify;
            else
                return 1.0;
        }

        public virtual double GetModifyDamageOutgoing(string typeInternal)
        {
            double modify = 1.0;
            if (damageModifyOutgoing.TryGetValue(typeInternal, out modify))
                return modify;
            else
                return 1.0;
        }

        protected virtual void LoadResourceImage(string resourcePath)
        {
            try
            {
                typeImage = SQWorld.LoadResourceImage(resourcePath);
            }
            catch { }
        }

        public virtual Bitmap Image()
        {
            if(typeImage != null)
            { return typeImage; }
            else
            { return new Bitmap(512, 512); }
        }
    }
}

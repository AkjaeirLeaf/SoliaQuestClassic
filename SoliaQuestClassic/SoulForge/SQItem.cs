using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SoliaQuestClassic.SoulForge
{
    public partial class SQItem
    {
        protected int familyID = 0;
        public int Family { get { return familyID; } }
        protected int subFamilyID = 0;
        public int ItemID { get { return subFamilyID; } }
        public int FullItemID { get { return (1000 * familyID) + subFamilyID; } }


        protected string displayName = "";
        protected string description = "";
        public string DisplayName { get { return displayName; } }
        public string Description { get { return description; } }

        protected int itemRarityID = 0;
        protected int maxStackSize = -1;
        protected bool canUseItem = false;
        public bool CanUse { get { return canUseItem; } }
        protected bool canUseCombat = false;
        public bool CanUseInCombat { get { return canUseCombat; } }
        protected bool removeWhenZero = true;


        public int MaxStackSize { get { return maxStackSize; } }

        public SQItem()
        {

        }

        public SQItem Self()
        {
            return (SQItem)this.MemberwiseClone();
        }

        public virtual bool IsEqual(SQItem item)
        {
            if (item.familyID == this.familyID
                && item.subFamilyID == this.subFamilyID
                && item.displayName == this.displayName
                && item.canUseItem == this.canUseItem
                && item.itemRarityID == this.itemRarityID
                && item.description == this.description
                && item.maxStackSize == this.maxStackSize
                && item.removeWhenZero == this.removeWhenZero)
                return true;
            else
                return false;
        }

        public virtual int UseItem(SQCreature sender, SQItemStack itemStack)
        {

            return 0;
        }

        public virtual object GetItemProperty(string propertyName)
        {
            switch (propertyName) //add more default stuff
            {
                case "displayName":
                    return this.displayName;
                case "fullID":
                    return this.FullItemID;
                default:
                    return null;
            }
        }

        public virtual int[] GetImages()
        {
            return new int[] { 0 };
        }

        
        public Bitmap Image()
        {
            SQItemFamily thisFamily;
            if(SQWorld.SQWorlditemFamilyList.TryGetValue(familyID, out thisFamily))
            {
                return thisFamily.GetItemImage(GetImages()[0]);
            }
            return new Bitmap(32, 32);
        }
        
    }
}

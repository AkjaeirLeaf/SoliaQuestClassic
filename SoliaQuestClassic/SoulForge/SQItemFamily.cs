using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.Framework;

namespace SoliaQuestClassic.SoulForge
{
    /// <summary>
    /// <tooltip></tooltip>
    /// </summary>
    public partial class SQItemFamily
    {
        protected int itemFamilyID = 0;
        public int FamilyID { get { return itemFamilyID; } }

        protected string itemFamilyName = "";
        public string FamilyName { get { return itemFamilyName; } }

        protected Dictionary<int, SQItem> familyRegisterItems = new Dictionary<int, SQItem>();

        protected string[] imagesToLoad = new string[0];
        protected int[] matchingImageID = new int[0];
        protected Dictionary<int, Bitmap> familyItemImages = new Dictionary<int, Bitmap>();

        //public SQItemFamily() { }
        public SQItemFamily(int familyID, string familyName)
        {
            itemFamilyID = familyID;
            itemFamilyName = familyName;


        }

        public SQItem TryGetItem(int subFamilyID)
        {
            SQItem result;
            if(familyRegisterItems.TryGetValue(subFamilyID, out result))
            {
                return result;
            }
            else { return null; }
        }
        public SQItemLinkError LinkItemTo(SQItem item)
        {
            if(item.Family == FamilyID)
            {
                try
                {
                    familyRegisterItems.Add(item.ItemID, item);
                    return SQItemLinkError.NO_ERROR;
                }
                catch (Exception e)
                {
                    if(e.InnerException == new ArgumentException())
                    {
                        return SQItemLinkError.DUPLICATE_ITEM_ERROR;
                    }
                    return SQItemLinkError.UNKNOWN_DICTIONARY_ERROR;
                }
            }
            else { return SQItemLinkError.FAMILY_MISMATCH_ERROR; }
        }
        public int AddItemImage(int callID, string path)
        {
            if (matchingImageID.Length > 0)
            {
                for(int p = 0; p < imagesToLoad.Length; p++)
                {
                    if(imagesToLoad[p] == path && matchingImageID[p] == callID)
                    {
                        return 0;
                    }
                }
                //if here, image has not been found in list, add with ArrayHandler
                imagesToLoad = ArrayHandler.append(imagesToLoad, path);
                matchingImageID = ArrayHandler.append(matchingImageID, callID);
                return 1;
            }
            else
            {
                matchingImageID = new int[] { callID };
                imagesToLoad = new string[] { path };
                return 1;
            }
        }
        

        //be sure to add ItemFamily registration to SQWorld!
        //REGISTRATION MUST LOAD IMAGES!

        protected virtual int LoadImages()
        {
            for( int i = 0; i < imagesToLoad.Length; i++ )
            {
                Bitmap image = SQWorld.LoadResourceImage(imagesToLoad[i]);
                try
                {
                    familyItemImages.Add(matchingImageID[i], image);
                }
                catch(Exception e) { }
            }
            return 0;
        }

        public virtual Bitmap GetItemImage(int id)
        {
            Bitmap img;
            if(familyItemImages.TryGetValue(id, out img))
            {
                return img;
            }
            else { return ItemEmptyImg; }
        }

        public static Bitmap ItemEmptyImg = new Bitmap(32, 32);
    }


    public enum SQItemLinkError
    {
        DUPLICATE_ITEM_ERROR = -3,
        FAMILY_MISMATCH_ERROR = -2,
        UNKNOWN_DICTIONARY_ERROR = -1,
        NO_ERROR = 0
    }
}

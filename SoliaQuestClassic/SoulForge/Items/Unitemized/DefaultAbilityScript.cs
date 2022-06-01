using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Items.Unitemized
{
    public class DefaultAbilityScript : SQItem
    {
        private SQAbility learnAbility = new SQAbility();
        private bool isBlank = true;
        private int iconImg = 6;

        public DefaultAbilityScript()
        {
            familyID = 0;
            subFamilyID = 6;
            displayName = "Blank Ability Scroll";
            description = "This would teach you a new trick, if only it weren\'t blank!";
            itemRarityID = 3;
            maxStackSize = 1;
            canUseItem = true;
            removeWhenZero = true;
            isBlank = true;
        }

        /// <summary>
        /// <tooltip>Construct custom tagged item to teach an ability of your choosing.</tooltip>
        /// </summary>
        /// <param name="ability"><tooltip>Add the ability object here.</tooltip></param>
        /// <param name="icon">
        /// <tooltip>
        /// <br>Here designates the type of image you want</br>
        /// <br>00: scroll default icon</br>
        /// <br>01: disk default icon</br>
        /// </tooltip>
        /// </param>
        public DefaultAbilityScript(SQAbility ability, int icon)
        {
            learnAbility = ability;
            familyID = 0;
            subFamilyID = 6;
            switch (icon)
            {
                case 0:
                    displayName = "Ability Scroll: ";
                    description = "This scroll can teach you the ability \"" + ability.DisplayName + "\"!";
                    break;
                case 1:
                    displayName = "Ability Disk: ";
                    description = "This disk can teach you the ability \"" + ability.DisplayName + "\"!";
                    break;
                case 2:
                    displayName = "Air Ability Disk: ";
                    description = "This disk can teach you the Air type ability \"" + ability.DisplayName + "\"!";
                    break;
                case 3:
                    displayName = "Crystal Ability Disk: ";
                    description = "This disk can teach you the Crystal type ability \"" + ability.DisplayName + "\"!";
                    break;
                case 4:
                    displayName = "Dark Ability Disk: ";
                    description = "This disk can teach you the Dark type ability \"" + ability.DisplayName + "\"!";
                    break;
            }
            displayName += ability.DisplayName;
            itemRarityID = 3;
            maxStackSize = 1;
            canUseItem = true;
            removeWhenZero = true;
            isBlank = false;
            icon += 6;
            if(icon >=6 && icon <= 10) { iconImg = icon; }
            else { iconImg = 6; }
        }

        public override int UseItem(SQCreature sender, SQItemStack itemStack)
        {
            if (itemStack.canDecr(1) && !isBlank)
            {
                sender.TeachAbility(learnAbility);
                itemStack.Decrease(1);
            }
            return 0;
        }

        public override int[] GetImages()
        {
            return new int[] { iconImg };
        }

        public override object GetItemProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "useInfo":
                    if (isBlank) { return "You can\'t do anything with this, it\'s blank :("; }
                    else { return "You can use this to learn the ability \"" + learnAbility.DisplayName + "\"."; }
                default:
                    return base.GetItemProperty(propertyName);
            }
        }
    }
}

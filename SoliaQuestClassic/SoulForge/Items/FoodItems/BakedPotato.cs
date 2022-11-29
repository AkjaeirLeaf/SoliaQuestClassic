using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Items.FoodItems
{
    public class BakedPotato : SQItem
    {
        public BakedPotato()
        {
            familyID = 2;
            subFamilyID = 4;
            displayName = "Baked Potato";
            description = "Replenishes your stats a significant amount.";
            itemRarityID = 0;
            maxStackSize = 999;
            canUseItem = true;
            canUseCombat = true;
            removeWhenZero = true;
        }

        public override int UseItem(SQCreature sender, SQItemStack itemStack)
        {
            if (itemStack.canDecr(1))
            {
                if(sender.State != SQCreatureState.Nominal && sender.State != SQCreatureState.Awakened && sender.State != SQCreatureState.Ghost)
                {
                    sender.ModifyCreatureState(SQCreatureState.Nominal);
                }
                SQAbilityInfo sqai = new SQAbilityInfo();
                sqai.doHealSelf = 50;
                sqai.doHealTarget = 50;
                sqai.doStaminaSelf = 25;
                sqai.doStaminaTarget = 25;
                sender.DoHeal(sqai);
                itemStack.Decrease(1);
            }
            return 0;
        }

        public override int[] GetImages()
        {
            return new int[] { 4 };
        }

        public override object GetItemProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "useInfo":
                    return "Use this item to heal and replenish stats.";
                default:
                    return base.GetItemProperty(propertyName);
            }
        }
    }
}

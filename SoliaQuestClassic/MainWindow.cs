using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SoliaQuestClassic.SoulForge;
using SoliaQuestClassic.SoulForge.Species;

namespace SoliaQuestClassic
{
    public partial class MainWindow : Form
    {
        private int sizeofBarMaxWidth = 160;
        private int sizeofBarMaxHeight = 20;

        private bool isHoldingItemStack = false;
        private SQItemStack heldItemStack = SQItemStack.Empty;
        private int heldItemLocation = -2;

        private bool doUseItem = false;
        private bool doDeleteStack = false;

        public MainWindow()
        {
            SQWorld.AllocSetupAll();

            //Console.WriteLine(SQWorld.C_FindMostEffective(new string[] { "dark" }, new string[] { "crystal", "light" }, 1));

            if(true)

#if true
            //initialize
            InitializeComponent();
            AwakeGenerateCreature();


            EnterNameDialog end = new EnterNameDialog();
            end.ShowDialog();
            player.CreatureName = end.nameEntered;
            creatureNameLabel.Text = player.CreatureName;
            //creatureInventoryLabel.Text = player.CreatureName + "\'s Inventory:";
            player.CreateCreatureMainInventory(8);
            player.QuickGiveItem(new SoulForge.Items.FoodItems.BakedPotato(), 16);
            player.QuickGiveItem(new SoulForge.Items.Unitemized.DefaultAbilityScript(new SoulForge.Abilities.Whisper(), 0), 1);


            UpdateTextData();
            UpdateInventoryImages();
            UpdateAbilitiesDisplay();
#endif

        }


        public static SQCreature player;
        private bool usable = false; //can cross reference access
        private void AwakeGenerateCreature()
        {
            player = new Soqaruth().NewCreatureOf();
            player.AddTag("tag_isActiveUser", true);
            //player.ForceModifyColors(new string[] { "prismatic" } );
            //player.ForceModifyColors(new string[] { "negative" } );
            usable = true;
        }

        private void UpdateTextData()
        {
            creatureNameLabel.Text  = player.CreatureName;
            creatureInfoLabel.Text  = player.DisplayAs();
            CreaturePoseFrame.Image = player.GetFrameImage();

            double expCurr = player.Experience;
            double expReqd = SQCreature.GetRequiredExp(player.Level + 1);

            ExpBarForeground.Size = new Size((int)(215 * (expCurr / expReqd)), 10);
            CreatureExperienceLabel.Text = "Experience: " + expCurr + " / " + expReqd;

            double max;
            double min;
            SQStatMod statMod;

            statMod = player.GetStatRank(SQCreatureStat.Health);
            min = player.StatCalcMinMax(statMod, SQCreatureStat.Health, false);
            max = player.StatCalcMinMax(statMod, SQCreatureStat.Health, true);
            creatureHealthDynamic.Size = new Size((int)(sizeofBarMaxWidth * (player.DynamicHealth / player.Health)), 15);
            creatureHealthAdvance.Size = new Size((int)(sizeofBarMaxWidth * (player.Health - min) / (max - min)), 5);

            statMod = player.GetStatRank(SQCreatureStat.Defense);
            min = player.StatCalcMinMax(statMod, SQCreatureStat.Defense, false);
            max = player.StatCalcMinMax(statMod, SQCreatureStat.Defense, true);
            creatureDefenseDynamic.Size = new Size((int)(sizeofBarMaxWidth * (player.DynamicDefense / player.Defense)), 15);
            creatureDefenseAdvance.Size = new Size((int)(sizeofBarMaxWidth * (player.Defense - min) / (max - min)), 5);

            statMod = player.GetStatRank(SQCreatureStat.Attack);
            min = player.StatCalcMinMax(statMod, SQCreatureStat.Attack, false);
            max = player.StatCalcMinMax(statMod, SQCreatureStat.Attack, true);
            creatureAttackDynamic.Size = new Size((int)(sizeofBarMaxWidth * (player.DynamicAttack / player.Attack)), 15);
            creatureAttackAdvance.Size = new Size((int)(sizeofBarMaxWidth * (player.Attack - min) / (max - min)), 5);

            statMod = player.GetStatRank(SQCreatureStat.Stamina);
            min = player.StatCalcMinMax(statMod, SQCreatureStat.Stamina, false);
            max = player.StatCalcMinMax(statMod, SQCreatureStat.Stamina, true);
            creatureStaminaDynamic.Size = new Size((int)(sizeofBarMaxWidth * (player.DynamicStamina / player.Stamina)), 15);
            creatureStaminaAdvance.Size = new Size((int)(sizeofBarMaxWidth * (player.Stamina - min) / (max - min)), 5);

            statMod = player.GetStatRank(SQCreatureStat.Evade);
            min = player.StatCalcMinMax(statMod, SQCreatureStat.Evade, false);
            max = player.StatCalcMinMax(statMod, SQCreatureStat.Evade, true);
            creatureEvadeDynamic.Size = new Size((int)(sizeofBarMaxWidth * (player.DynamicEvade / player.Evade)), 15);
            creatureEvadeAdvance.Size = new Size((int)(sizeofBarMaxWidth * (player.Evade - min) / (max - min)), 5);

            statMod = player.GetStatRank(SQCreatureStat.Control);
            min = player.StatCalcMinMax(statMod, SQCreatureStat.Control, false);
            max = player.StatCalcMinMax(statMod, SQCreatureStat.Control, true);
            creatureControlDynamic.Size = new Size((int)(sizeofBarMaxWidth * (player.DynamicControl / player.Control)), 15);
            creatureControlAdvance.Size = new Size((int)(sizeofBarMaxWidth * (player.Control - min) / (max - min)), 5);

            creatureInventoryLabel.Text = player.CreatureName + "\'s Inventory:";

            //try type images:
            for(int t = 0; t < player.CreatureSpecies.UseSpeciesTypes.Length; t++)
            {
                SQType type;
                if (SQWorld.SQWorldTypeList.TryGetValue(player.CreatureSpecies.UseSpeciesTypes[t], out type))
                {
                    Bitmap bmpI = type.Image();
                    if(bmpI != null)
                    {
                        switch (t)
                        {
                            case 0:
                                typeImgBox0.Image = bmpI;
                                break;
                            case 1:
                                typeImgBox1.Image = bmpI;
                                break;
                            case 2:
                                typeImgBox2.Image = bmpI;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }


        #region ClickOnStat
        private void creatureNameLabel_Click(object sender, EventArgs e)
        {
            EnterNameDialog end = new EnterNameDialog();
            end.ShowDialog();
            player.CreatureName = end.nameEntered;
            creatureNameLabel.Text = player.CreatureName;
        }

        private void debugOpenCombat_Click(object sender, EventArgs e)
        {
            FightDialog fightDialog = new FightDialog();
            fightDialog.ShowDialog();
            if (fightDialog.PlayerWins && fightDialog.enemyCreature.HasInventory)
            {
                for(int i = 0; i < fightDialog.enemyCreature.InventorySize; i++)
                {
                    AddRewards(fightDialog.enemyCreature.MainInventory.Contents[i]);
                }
            }
            player.FullHeal();
            player.EndCombat();
            UpdateInventoryImages();
            UpdateTextData();
        }

        private void creatureHealthDynamic_MouseClick(object sender, MouseEventArgs e)
        {
            StatDetailsWindow sdw = new StatDetailsWindow(SQCreatureStat.Health, player);
            sdw.ShowDialog();
            UpdateTextData();
        }

        private void creatureDefenseDynamic_MouseClick(object sender, MouseEventArgs e)
        {
            StatDetailsWindow sdw = new StatDetailsWindow(SQCreatureStat.Defense, player);
            sdw.ShowDialog();
            UpdateTextData();
        }

        private void creatureAttackDynamic_MouseClick(object sender, MouseEventArgs e)
        {
            StatDetailsWindow sdw = new StatDetailsWindow(SQCreatureStat.Attack, player);
            sdw.ShowDialog();
            UpdateTextData();
        }

        private void creatureStaminaDynamic_MouseClick(object sender, MouseEventArgs e)
        {
            StatDetailsWindow sdw = new StatDetailsWindow(SQCreatureStat.Stamina, player);
            sdw.ShowDialog();
            UpdateTextData();
        }

        private void creatureEvadeDynamic_MouseClick(object sender, MouseEventArgs e)
        {
            StatDetailsWindow sdw = new StatDetailsWindow(SQCreatureStat.Evade, player);
            sdw.ShowDialog();
            UpdateTextData();
        }

        private void creatureControlDynamic_MouseClick(object sender, MouseEventArgs e)
        {
            StatDetailsWindow sdw = new StatDetailsWindow(SQCreatureStat.Control, player);
            sdw.ShowDialog();
            UpdateTextData();
        }
        #endregion ClickOnStat

        #region Inventory
        //inventory handles
        private void UpdateInventoryImages()
        {
            invSlotCount0.Text = (player.MainInventory.Contents[0].StackSize == 0 ? "" : player.MainInventory.Contents[0].StackSize == 1 ? "" : player.MainInventory.Contents[0].StackSize == -1 ? "" : player.MainInventory.Contents[0].StackSize.ToString());
            invSlotCount1.Text = (player.MainInventory.Contents[1].StackSize == 0 ? "" : player.MainInventory.Contents[1].StackSize == 1 ? "" : player.MainInventory.Contents[1].StackSize == -1 ? "" : player.MainInventory.Contents[1].StackSize.ToString());
            invSlotCount2.Text = (player.MainInventory.Contents[2].StackSize == 0 ? "" : player.MainInventory.Contents[2].StackSize == 1 ? "" : player.MainInventory.Contents[2].StackSize == -1 ? "" : player.MainInventory.Contents[2].StackSize.ToString());
            invSlotCount3.Text = (player.MainInventory.Contents[3].StackSize == 0 ? "" : player.MainInventory.Contents[3].StackSize == 1 ? "" : player.MainInventory.Contents[3].StackSize == -1 ? "" : player.MainInventory.Contents[3].StackSize.ToString());
            invSlotCount4.Text = (player.MainInventory.Contents[4].StackSize == 0 ? "" : player.MainInventory.Contents[4].StackSize == 1 ? "" : player.MainInventory.Contents[4].StackSize == -1 ? "" : player.MainInventory.Contents[4].StackSize.ToString());
            invSlotCount5.Text = (player.MainInventory.Contents[5].StackSize == 0 ? "" : player.MainInventory.Contents[5].StackSize == 1 ? "" : player.MainInventory.Contents[5].StackSize == -1 ? "" : player.MainInventory.Contents[5].StackSize.ToString());
            invSlotCount6.Text = (player.MainInventory.Contents[6].StackSize == 0 ? "" : player.MainInventory.Contents[6].StackSize == 1 ? "" : player.MainInventory.Contents[6].StackSize == -1 ? "" : player.MainInventory.Contents[6].StackSize.ToString());
            invSlotCount7.Text = (player.MainInventory.Contents[7].StackSize == 0 ? "" : player.MainInventory.Contents[7].StackSize == 1 ? "" : player.MainInventory.Contents[7].StackSize == -1 ? "" : player.MainInventory.Contents[7].StackSize.ToString());

            invSlotIcon0.Image = player.MainInventory.Contents[0].StackItem.Image();
            invSlotIcon1.Image = player.MainInventory.Contents[1].StackItem.Image();
            invSlotIcon2.Image = player.MainInventory.Contents[2].StackItem.Image();
            invSlotIcon3.Image = player.MainInventory.Contents[3].StackItem.Image();
            invSlotIcon4.Image = player.MainInventory.Contents[4].StackItem.Image();
            invSlotIcon5.Image = player.MainInventory.Contents[5].StackItem.Image();
            invSlotIcon6.Image = player.MainInventory.Contents[6].StackItem.Image();
            invSlotIcon7.Image = player.MainInventory.Contents[7].StackItem.Image();


            //rewards section
            if(RewardsInventory.Length > 0)
            {
                invROcount.Text = (RewardsInventory[0].StackSize == 0 ? "" : RewardsInventory[0].StackSize == 1 ? "" : RewardsInventory[0].StackSize == -1 ? "" : RewardsInventory[0].StackSize.ToString());
                invROicon.Image = RewardsInventory[0].StackItem.Image();
            }
            else
            {
                invROcount.Text = "";
                invROicon.Image = new Bitmap(32, 32);
            }
            
        }

        //simple condensed function
        private void PickUpStack(SQCreature owner, int slot)
        {
            if(slot >= 0 && slot < 8)
            {
                if (owner.HasInventory)
                {
                    if (!owner.MainInventory.Contents[slot].IsEmptyStack)
                    {
                        //stack has contents that can be moved.
                        isHoldingItemStack = true;
                        heldItemLocation = slot;
                        heldItemStack = owner.MainInventory.TakeItemStack(slot);
                        // ^ this covers replacing the itemstack in the inventory. keep the new
                        // itemstack safe because the items will be lost otherwise.
                        owner.MainInventory.Contents[slot] = new SQItemStack();
                    }
                    else
                    {
                        //stack is empty
                    }
                    UpdateInventoryImages();
                }
            }
            else if(slot == -1)
            {
                if (RewardsInventory.Length > 0)
                {
                    if (!RewardsInventory[0].IsEmptyStack)
                    {
                        GrabTopReward();
                    }
                }
            }
        }
        private void PlaceItemStack(SQCreature owner, int slot)
        {
            if(isHoldingItemStack && !heldItemStack.IsEmptyStack)
            {
                if(slot >= 0 && slot < 8)
                {
                    if (owner.HasInventory)
                    {
                        SQItemStack extras;
                        owner.MainInventory.PlaceItemStack(heldItemStack, slot, out extras);
                        if (extras.IsEmptyStack)
                        {
                            heldItemStack.DisposeOf();
                            isHoldingItemStack = false;
                            heldItemLocation = -2;
                        }
                        else
                        {
                            heldItemStack = extras.Grab();
                            isHoldingItemStack = true;
                        }
                    }
                }
                else if (slot == -1)
                {
                    AddRewards(heldItemStack, true);
                    heldItemStack.DisposeOf();
                    isHoldingItemStack = false;
                    heldItemLocation = -2;
                }
            }
            UpdateInventoryImages();
        }
        private void GiveItemStack(SQCreature owner, SQItemStack stack, out SQItemStack extras)
        {
            if(!stack.IsEmptyStack && owner.HasInventory)
            {
                owner.MainInventory.AddItemStack(stack, out extras);
            }
            else
            {
                extras = stack.Grab();
            }
            UpdateInventoryImages();
        }

        private void invSlotIcon0_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(0); }
            else if (doDeleteStack) { DeleteSelectedItem(0); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 0); }
                else { PickUpStack(player, 0); }
                UpdateInventoryImages();
            }
            
        }
        private void invSlotIcon1_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(1); }
            else if (doDeleteStack) { DeleteSelectedItem(1); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 1); }
                else { PickUpStack(player, 1); }
                UpdateInventoryImages();
            }
            
        }
        private void invSlotIcon2_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(2); }
            else if (doDeleteStack) { DeleteSelectedItem(2); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 2); }
                else { PickUpStack(player, 2); }
                UpdateInventoryImages();
            }
        }
        private void invSlotIcon3_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(3); }
            else if (doDeleteStack) { DeleteSelectedItem(3); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 3); }
                else { PickUpStack(player, 3); }
                UpdateInventoryImages();
            }
        }
        private void invSlotIcon4_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(4); }
            else if (doDeleteStack) { DeleteSelectedItem(4); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 4); }
                else { PickUpStack(player, 4); }
                UpdateInventoryImages();
            }
        }
        private void invSlotIcon5_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(5); }
            else if (doDeleteStack) { DeleteSelectedItem(5); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 5); }
                else { PickUpStack(player, 5); }
                UpdateInventoryImages();
            }
        }
        private void invSlotIcon6_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(6); }
            else if (doDeleteStack) { DeleteSelectedItem(6); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 6); }
                else { PickUpStack(player, 6); }
                UpdateInventoryImages();
            }
        }
        private void invSlotIcon7_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(7); }
            else if (doDeleteStack) { DeleteSelectedItem(7); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, 7); }
                else { PickUpStack(player, 7); }
                UpdateInventoryImages();
            }
        }

        private void UseItemButton_Click(object sender, EventArgs e)
        {
            if (doDeleteStack)
            {
                ResetDeleteItem();
            }
            else
            {
                if (!doUseItem)
                {
                    doUseItem = true;
                    UseItemButton.Text = "Select Item";

                }
                else
                {
                    ResetUseItem();
                }
            }
        }
        private void ResetUseItem()
        {
            if (doUseItem)
            {
                doUseItem = false;
                UseItemButton.Text = "Use Item";


            }
        }
        private void UseSelectedItem(int slot)
        {
            if (doUseItem)
            {
                ResetUseItem();
                if (player.MainInventory.Contents[slot].StackItem.CanUse)
                {
                    string useMessage = (string)player.MainInventory.Contents[slot].StackItem.GetItemProperty("useInfo");
                    switch (MessageBox.Show(useMessage, "Confirm Use Item?", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            player.MainInventory.Contents[slot].StackItem.UseItem(player, player.MainInventory.Contents[slot]);
                            if(player.MainInventory.Contents[slot].IsEmptyStack || player.MainInventory.Contents[slot].StackSize <= 0)
                            {
                                player.MainInventory.Contents[slot] = new SQItemStack();
                            }
                            UpdateInventoryImages();
                            UpdateTextData();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Can't use this item!", "Can't use!");
                }
            }
        }

        private void invSlotIcon0_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(0);
        }
        private void invSlotIcon1_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(1);
        }
        private void invSlotIcon2_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(2);
        }
        private void invSlotIcon3_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(3);
        }
        private void invSlotIcon4_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(4);
        }
        private void invSlotIcon5_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(5);
        }
        private void invSlotIcon6_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(6);
        }
        private void invSlotIcon7_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(7);
        }

        private void UpdateInvHoverText(int slot)
        {
            if(slot >= 0 && slot < 8)
            {
                itemHoverName.Text = player.MainInventory.Contents[slot].StackItem.DisplayName;
                itemTooltipDesc.Text = player.MainInventory.Contents[slot].StackItem.Description;
            }
            else if(slot == -1 && RewardsInventory.Length > 0)
            {
                itemHoverName.Text = RewardsInventory[0].StackItem.DisplayName;
                itemTooltipDesc.Text = RewardsInventory[0].StackItem.Description;
            }
            else
            {
                //kill text
                itemHoverName.Text = "";
                itemTooltipDesc.Text = "";
            }
        }

        private void ClearInvHoverText(object sender, EventArgs e)
        {
            UpdateInvHoverText(-2);
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            if (doUseItem)
            {
                ResetUseItem();
            }
            else
            {
                if (!doDeleteStack)
                {
                    doDeleteStack = true;
                    deleteItemButton.Text = "Select Item";

                }
                else
                {
                    ResetDeleteItem();
                }
            }
        }
        private void ResetDeleteItem()
        {
            if (doDeleteStack)
            {
                doDeleteStack = false;
                deleteItemButton.Text = "Delete";


            }
        }
        private void DeleteSelectedItem(int slot)
        {
            if (doDeleteStack)
            {
                ResetDeleteItem();
                if (!player.MainInventory.Contents[slot].IsEmptyStack)
                {
                    switch (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete Item?", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            player.MainInventory.Contents[slot] = new SQItemStack();
                            UpdateInventoryImages();
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        //Rewards Inventory & Overflow!
        private SQItemStack[] RewardsInventory = new SQItemStack[0];
        public void AddRewards(SQItemStack stack, bool insert = false)
        {
            if (!stack.IsEmptyStack)
            {
                if (RewardsInventory.Length > 0)
                {
                    SQItemStack[] stacksList = new SQItemStack[RewardsInventory.Length + 1];
                    if (!insert)
                    {
                        for (int s = 0; s < RewardsInventory.Length; s++)
                        {
                            stacksList[s] = RewardsInventory[s].Grab();
                        }
                        stacksList[RewardsInventory.Length] = stack.Grab();
                        RewardsInventory = stacksList;
                    }
                    else
                    {
                        stacksList[0] = stack.Grab();
                        for (int s = 1; s <= RewardsInventory.Length; s++)
                        {
                            stacksList[s] = RewardsInventory[s - 1].Grab();
                        }
                        RewardsInventory = stacksList;
                    }
                }
                else
                {
                    RewardsInventory = new SQItemStack[] { stack.Grab() };
                }
                UpdateInventoryImages();
            }
        }
        public void GrabTopReward()
        {
            if (RewardsInventory.Length > 0)
            {
                heldItemStack = RewardsInventory[0].Grab();
                heldItemLocation = -1;
                isHoldingItemStack = true;
                SQItemStack[] stacksList = new SQItemStack[RewardsInventory.Length - 1];
                for (int s = 1; s < RewardsInventory.Length; s++)
                {
                    stacksList[s - 1] = RewardsInventory[s].Grab();
                }
                RewardsInventory = stacksList;
            }
            else
            {
                isHoldingItemStack = false;
                heldItemLocation = -2;
                heldItemStack = new SQItemStack();
            }
            UpdateInventoryImages();
        }
        public void DropHeldStack()
        {
            if (isHoldingItemStack)
            {
                if(heldItemLocation >= 0 && heldItemLocation < 8)
                {//location is in player inventory.
                    PlaceItemStack(player, heldItemLocation);
                }
                else if(heldItemLocation == -1)
                {//location is in rewards stack.
                    AddRewards(heldItemStack, true);
                    heldItemStack = new SQItemStack();
                    heldItemLocation = -2;
                    isHoldingItemStack = false;
                }
                UpdateInventoryImages();
            }
        }

        private void invROicon_Click(object sender, EventArgs e)
        {
            if (doUseItem) { UseSelectedItem(-1); }
            else if (doDeleteStack) { DeleteSelectedItem(-1); }
            else
            {
                if (isHoldingItemStack) { PlaceItemStack(player, -1); }
                else { PickUpStack(player, -1); }
                UpdateInventoryImages();
            }
        }
        private void inventoryTab_Click(object sender, EventArgs e)
        {
            if (isHoldingItemStack) { DropHeldStack(); }
        }

        private void invROicon_MouseEnter(object sender, EventArgs e)
        {
            UpdateInvHoverText(-1);
        }
        #endregion Inventory

        #region Abilities
        private int SelectedAbilityIndex = 0;
        private int UpdateAbilitiesDisplay()
        {
            if(player.Abilities.Length > 0)
            {
                if (SelectedAbilityIndex >= 0 && SelectedAbilityIndex < player.Abilities.Length)
                {
                    string typeslist = "";
                    for(int t = 0; t < player.Abilities[SelectedAbilityIndex].AbilityType.Length; t++)
                    {
                        SQType type;
                        if (SQWorld.SQWorldTypeList.TryGetValue(player.Abilities[SelectedAbilityIndex].AbilityType[t], out type)) ;
                        {
                            typeslist += type.Title;
                            if (t != player.Abilities[SelectedAbilityIndex].AbilityType.Length - 1)
                            {
                                typeslist += ", ";
                            }
                        }
                    }

                    selectAbilityName.Text = player.Abilities[SelectedAbilityIndex].DisplayName;
                    selectAbilityTypes.Text = typeslist + "\n" +
                        player.Abilities[SelectedAbilityIndex].Description
                        + "\nDamage: " + player.Abilities[SelectedAbilityIndex].GetDealDamageTarget(player)
                        + "\nHealing: " + player.Abilities[SelectedAbilityIndex].GetHealValueSelf(player)
                        + "\nEffectiveness: " + player.Abilities[SelectedAbilityIndex].UseEffectivity(player);

                    abilityTypeImg0.Image = null;
                    abilityTypeImg1.Image = null;
                    abilityTypeImg2.Image = null;

                    //type images
                    for (int t = 0; t < player.Abilities[SelectedAbilityIndex].AbilityType.Length; t++)
                    {
                        SQType type;
                        if (SQWorld.SQWorldTypeList.TryGetValue(player.Abilities[SelectedAbilityIndex].AbilityType[t], out type))
                        {
                            Bitmap bmpI = type.Image();
                            if (bmpI != null)
                            {
                                switch (t)
                                {
                                    case 0:
                                        abilityTypeImg0.Image = bmpI;
                                        break;
                                    case 1:
                                        abilityTypeImg1.Image = bmpI;
                                        break;
                                    case 2:
                                        abilityTypeImg2.Image = bmpI;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    int displace = selectAbilityName.Size.Width;
                    int buff = 4;
                    int x = 24;
                    int y = 9;
                    abilityTypeImg0.Location = new Point(buff + displace, y);
                    abilityTypeImg1.Location = new Point(buff + displace + x, y);
                    abilityTypeImg2.Location = new Point(buff + displace + x + x, y);
                    return 1;
                }
            }

            selectAbilityName.Text = "";
            selectAbilityTypes.Text = "";

            return 0;
        }
        private void selectAbilityLast_Click(object sender, EventArgs e)
        {
            if (SelectedAbilityIndex == 0)
            {
                SelectedAbilityIndex = player.Abilities.Length - 1;
            }
            else { SelectedAbilityIndex--; }
            UpdateAbilitiesDisplay();
        }
        private void selectAbilityNext_Click(object sender, EventArgs e)
        {
            if (SelectedAbilityIndex == player.Abilities.Length - 1)
            {
                SelectedAbilityIndex = 0;
            }
            else { SelectedAbilityIndex++; }
            UpdateAbilitiesDisplay();
        }

#endregion Abilities



    }
}

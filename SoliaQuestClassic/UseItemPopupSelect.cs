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

namespace SoliaQuestClassic
{
    public partial class UseItemPopupSelect : Form
    {
        private SQCreature user;
        public int SelectedSlot = -2;
        public bool slotIsSelected = false;

        private bool usedItemAbility = false;
        public bool UsedItem { get { return usedItemAbility; } }

        public UseItemPopupSelect(SQCreature sender)
        {
            user = sender;
            InitializeComponent();
            creatureInventoryLabel.Text = user.CreatureName + "\'s Inventory:";
            UpdateInventoryImages(user);
        }

        //inventory handles
        private void UpdateInventoryImages(SQCreature player)
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

        }


        #region hovertext
        private void UpdateInvHoverText(int slot)
        {
            if (slot >= 0 && slot < 8)
            {
                itemHoverName.Text = user.MainInventory.Contents[slot].StackItem.DisplayName;
                itemTooltipDesc.Text = user.MainInventory.Contents[slot].StackItem.Description;
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
        #endregion hovertext

        private void resetSlotColors()
        {
            if (!slotIsSelected)
            {
                UseItemButton.Enabled = false;
            }
            else
            {
                switch (SelectedSlot)
                {
                    case 0:
                        invSlotIcon0.BackColor = Color.LimeGreen;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                    case 1:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.LimeGreen;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                    case 2:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.LimeGreen;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                    case 3:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.LimeGreen;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                    case 4:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.LimeGreen;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                    case 5:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.LimeGreen;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                    case 6:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.LimeGreen;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                    case 7:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.LimeGreen;
                        break;
                    default:
                        invSlotIcon0.BackColor = Color.Transparent;
                        invSlotIcon1.BackColor = Color.Transparent;
                        invSlotIcon2.BackColor = Color.Transparent;
                        invSlotIcon3.BackColor = Color.Transparent;
                        invSlotIcon4.BackColor = Color.Transparent;
                        invSlotIcon5.BackColor = Color.Transparent;
                        invSlotIcon6.BackColor = Color.Transparent;
                        invSlotIcon7.BackColor = Color.Transparent;
                        break;
                }
                UseItemButton.Enabled = true;
            }
        }

        private void invSlotIcon0_Click(object sender, EventArgs e)
        {
            if(slotIsSelected && SelectedSlot == 0)
            { SelectedSlot = -2; slotIsSelected = false; }
            else 
            {
                SelectedSlot = 0;
                slotIsSelected = true;
            }
            resetSlotColors();
        }
        private void invSlotIcon1_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot == 1)
            { SelectedSlot = -2; slotIsSelected = false; }
            else
            {
                SelectedSlot = 1;
                slotIsSelected = true;
            }
            resetSlotColors();
        }
        private void invSlotIcon2_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot == 2)
            { SelectedSlot = -2; slotIsSelected = false; }
            else
            {
                SelectedSlot = 2;
                slotIsSelected = true;
            }
            resetSlotColors();
        }
        private void invSlotIcon3_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot == 3)
            { SelectedSlot = -2; slotIsSelected = false; }
            else
            {
                SelectedSlot = 3;
                slotIsSelected = true;
            }
            resetSlotColors();
        }
        private void invSlotIcon4_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot == 4)
            { SelectedSlot = -2; slotIsSelected = false; }
            else
            {
                SelectedSlot = 4;
                slotIsSelected = true;
            }
            resetSlotColors();
        }
        private void invSlotIcon5_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot == 5)
            { SelectedSlot = -2; slotIsSelected = false; }
            else
            {
                SelectedSlot = 5;
                slotIsSelected = true;
            }
            resetSlotColors();
        }
        private void invSlotIcon6_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot == 6)
            { SelectedSlot = -2; slotIsSelected = false; }
            else
            {
                SelectedSlot = 6;
                slotIsSelected = true;
            }
            resetSlotColors();
        }
        private void invSlotIcon7_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot == 7)
            { SelectedSlot = -2; slotIsSelected = false; }
            else
            {
                SelectedSlot = 7;
                slotIsSelected = true;
            }
            resetSlotColors();
        }

        private void UseItemButton_Click(object sender, EventArgs e)
        {
            if (slotIsSelected && SelectedSlot >= 0 && SelectedSlot < 8)
            {
                if (user.MainInventory.Contents[SelectedSlot].StackItem.CanUseInCombat)
                {
                    user.MainInventory.Contents[SelectedSlot].StackItem.UseItem(user, user.MainInventory.Contents[SelectedSlot]);
                    usedItemAbility = true;
                    this.Close();
                }
                else
                {
                    slotIsSelected = false;
                    SelectedSlot = -2;
                    resetSlotColors();
                    MessageBox.Show("Cannot use this item at this time.");
                }
            }
        }
    }
}

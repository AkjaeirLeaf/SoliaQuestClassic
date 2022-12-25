using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoliaQuestClassic
{
    public partial class EnterNameDialog : Form
    {
        public string nameEntered = "";
        public SoulForge.SQGender genderEntered;

        public EnterNameDialog(string initialName = "", SoulForge.SQGender initialGender = SoulForge.SQGender.Genderless)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(initialName))
            {
                nameEntryBox.Text = "New Creature";
            }
            //genderEntered = MainWindow.player.Gender;
            genderEntered = initialGender;
            //genderSelectionBox.SelectedIndex = ((int)MainWindow.player.Gender);
            genderSelectionBox.SelectedIndex = ((int)initialGender);
        }

        private void nameEntryBox_Click(object sender, EventArgs e)
        {
            if(nameEntryBox.Text == "New Creature") { nameEntryBox.Clear(); }
        }

        private void nameEntryBox_TextChanged(object sender, EventArgs e)
        {
            nameEntered = nameEntryBox.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(nameEntered) && nameEntered != "New Creature")
            {
                this.Close();
            }
            else
            {
                errorLabel.Text = "*Enter a valid name.";
            }
        }

        private void genderSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            genderEntered = (SoulForge.SQGender)(genderSelectionBox.SelectedIndex);
        }
    }
}

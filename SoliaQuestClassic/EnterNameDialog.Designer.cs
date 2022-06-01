
namespace SoliaQuestClassic
{
    partial class EnterNameDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameEntryBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.genderSelectionBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameEntryBox
            // 
            this.nameEntryBox.Location = new System.Drawing.Point(12, 12);
            this.nameEntryBox.Name = "nameEntryBox";
            this.nameEntryBox.Size = new System.Drawing.Size(125, 20);
            this.nameEntryBox.TabIndex = 0;
            this.nameEntryBox.Text = "New Creature";
            this.nameEntryBox.Click += new System.EventHandler(this.nameEntryBox_Click);
            this.nameEntryBox.TextChanged += new System.EventHandler(this.nameEntryBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(160, 38);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(9, 43);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 2;
            // 
            // genderSelectionBox
            // 
            this.genderSelectionBox.FormattingEnabled = true;
            this.genderSelectionBox.Items.AddRange(new object[] {
            "Genderless  ",
            "Agender     ",
            "Androgyne   ",
            "Bigender    ",
            "Genderfluid ",
            "Nonbinary   ",
            "Omnigender  ",
            "Polygender  ",
            "Twospirit   ",
            "Female      ",
            "Male"});
            this.genderSelectionBox.Location = new System.Drawing.Point(143, 11);
            this.genderSelectionBox.Name = "genderSelectionBox";
            this.genderSelectionBox.Size = new System.Drawing.Size(92, 21);
            this.genderSelectionBox.TabIndex = 3;
            this.genderSelectionBox.SelectedIndexChanged += new System.EventHandler(this.genderSelectionBox_SelectedIndexChanged);
            // 
            // EnterNameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 67);
            this.Controls.Add(this.genderSelectionBox);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameEntryBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(263, 106);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(263, 106);
            this.Name = "EnterNameDialog";
            this.Text = "Enter Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameEntryBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.ComboBox genderSelectionBox;
    }
}
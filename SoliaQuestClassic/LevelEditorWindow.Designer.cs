
namespace SoliaQuestClassic
{
    partial class LevelEditorWindow
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
            this.LevelNameBox = new System.Windows.Forms.TextBox();
            this.LevelNameLabel = new System.Windows.Forms.Label();
            this.SearchObjectsLabel = new System.Windows.Forms.Label();
            this.ObjectSearchBox = new System.Windows.Forms.TextBox();
            this.ObjectShapeSelector = new System.Windows.Forms.ComboBox();
            this.SelectObjectLabel = new System.Windows.Forms.Label();
            this.SelectObjectListBox = new System.Windows.Forms.ListBox();
            this.SmoothCornersRadioBuutton = new System.Windows.Forms.RadioButton();
            this.SharpCornersRadioButton = new System.Windows.Forms.RadioButton();
            this.RoughSidesRadio = new System.Windows.Forms.RadioButton();
            this.SmoothSidesRadio = new System.Windows.Forms.RadioButton();
            this.CurrentLayerBox = new System.Windows.Forms.ComboBox();
            this.CurrentLayerLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LevelNameBox
            // 
            this.LevelNameBox.Location = new System.Drawing.Point(145, 6);
            this.LevelNameBox.Name = "LevelNameBox";
            this.LevelNameBox.Size = new System.Drawing.Size(100, 20);
            this.LevelNameBox.TabIndex = 0;
            // 
            // LevelNameLabel
            // 
            this.LevelNameLabel.AutoSize = true;
            this.LevelNameLabel.Location = new System.Drawing.Point(12, 9);
            this.LevelNameLabel.Name = "LevelNameLabel";
            this.LevelNameLabel.Size = new System.Drawing.Size(107, 13);
            this.LevelNameLabel.TabIndex = 2;
            this.LevelNameLabel.Text = "Current Level Name :";
            // 
            // SearchObjectsLabel
            // 
            this.SearchObjectsLabel.AutoSize = true;
            this.SearchObjectsLabel.Location = new System.Drawing.Point(12, 29);
            this.SearchObjectsLabel.Name = "SearchObjectsLabel";
            this.SearchObjectsLabel.Size = new System.Drawing.Size(86, 13);
            this.SearchObjectsLabel.TabIndex = 4;
            this.SearchObjectsLabel.Text = "Search Objects :";
            // 
            // ObjectSearchBox
            // 
            this.ObjectSearchBox.Location = new System.Drawing.Point(145, 26);
            this.ObjectSearchBox.Name = "ObjectSearchBox";
            this.ObjectSearchBox.Size = new System.Drawing.Size(100, 20);
            this.ObjectSearchBox.TabIndex = 3;
            // 
            // ObjectShapeSelector
            // 
            this.ObjectShapeSelector.FormattingEnabled = true;
            this.ObjectShapeSelector.Location = new System.Drawing.Point(145, 94);
            this.ObjectShapeSelector.Name = "ObjectShapeSelector";
            this.ObjectShapeSelector.Size = new System.Drawing.Size(100, 21);
            this.ObjectShapeSelector.TabIndex = 5;
            // 
            // SelectObjectLabel
            // 
            this.SelectObjectLabel.AutoSize = true;
            this.SelectObjectLabel.BackColor = System.Drawing.Color.Transparent;
            this.SelectObjectLabel.Location = new System.Drawing.Point(12, 78);
            this.SelectObjectLabel.Name = "SelectObjectLabel";
            this.SelectObjectLabel.Size = new System.Drawing.Size(132, 13);
            this.SelectObjectLabel.TabIndex = 6;
            this.SelectObjectLabel.Text = "Select Object and Shape :";
            // 
            // SelectObjectListBox
            // 
            this.SelectObjectListBox.FormattingEnabled = true;
            this.SelectObjectListBox.Location = new System.Drawing.Point(15, 94);
            this.SelectObjectListBox.Name = "SelectObjectListBox";
            this.SelectObjectListBox.Size = new System.Drawing.Size(129, 173);
            this.SelectObjectListBox.TabIndex = 7;
            this.SelectObjectListBox.SelectedIndexChanged += new System.EventHandler(this.SelectObjectListBox_SelectedIndexChanged);
            // 
            // SmoothCornersRadioBuutton
            // 
            this.SmoothCornersRadioBuutton.AutoSize = true;
            this.SmoothCornersRadioBuutton.Location = new System.Drawing.Point(0, 0);
            this.SmoothCornersRadioBuutton.Name = "SmoothCornersRadioBuutton";
            this.SmoothCornersRadioBuutton.Size = new System.Drawing.Size(100, 17);
            this.SmoothCornersRadioBuutton.TabIndex = 8;
            this.SmoothCornersRadioBuutton.TabStop = true;
            this.SmoothCornersRadioBuutton.Text = "Smooth Corners";
            this.SmoothCornersRadioBuutton.UseVisualStyleBackColor = true;
            this.SmoothCornersRadioBuutton.CheckedChanged += new System.EventHandler(this.SmoothCornersRadioBuutton_CheckedChanged);
            // 
            // SharpCornersRadioButton
            // 
            this.SharpCornersRadioButton.AutoSize = true;
            this.SharpCornersRadioButton.Location = new System.Drawing.Point(0, 23);
            this.SharpCornersRadioButton.Name = "SharpCornersRadioButton";
            this.SharpCornersRadioButton.Size = new System.Drawing.Size(92, 17);
            this.SharpCornersRadioButton.TabIndex = 9;
            this.SharpCornersRadioButton.TabStop = true;
            this.SharpCornersRadioButton.Text = "Sharp Corners";
            this.SharpCornersRadioButton.UseVisualStyleBackColor = true;
            this.SharpCornersRadioButton.CheckedChanged += new System.EventHandler(this.SharpCornersRadioButton_CheckedChanged);
            // 
            // RoughSidesRadio
            // 
            this.RoughSidesRadio.AutoSize = true;
            this.RoughSidesRadio.Location = new System.Drawing.Point(0, 23);
            this.RoughSidesRadio.Name = "RoughSidesRadio";
            this.RoughSidesRadio.Size = new System.Drawing.Size(86, 17);
            this.RoughSidesRadio.TabIndex = 11;
            this.RoughSidesRadio.TabStop = true;
            this.RoughSidesRadio.Text = "Rough Sides";
            this.RoughSidesRadio.UseVisualStyleBackColor = true;
            this.RoughSidesRadio.CheckedChanged += new System.EventHandler(this.RoughSidesRadio_CheckedChanged);
            // 
            // SmoothSidesRadio
            // 
            this.SmoothSidesRadio.AutoSize = true;
            this.SmoothSidesRadio.Location = new System.Drawing.Point(0, 0);
            this.SmoothSidesRadio.Name = "SmoothSidesRadio";
            this.SmoothSidesRadio.Size = new System.Drawing.Size(90, 17);
            this.SmoothSidesRadio.TabIndex = 10;
            this.SmoothSidesRadio.TabStop = true;
            this.SmoothSidesRadio.Text = "Smooth Sides";
            this.SmoothSidesRadio.UseVisualStyleBackColor = true;
            this.SmoothSidesRadio.CheckedChanged += new System.EventHandler(this.SmoothSidesRadio_CheckedChanged);
            // 
            // CurrentLayerBox
            // 
            this.CurrentLayerBox.FormattingEnabled = true;
            this.CurrentLayerBox.Location = new System.Drawing.Point(145, 52);
            this.CurrentLayerBox.Name = "CurrentLayerBox";
            this.CurrentLayerBox.Size = new System.Drawing.Size(100, 21);
            this.CurrentLayerBox.TabIndex = 12;
            this.CurrentLayerBox.SelectedIndexChanged += new System.EventHandler(this.CurrentLayerBox_SelectedIndexChanged);
            // 
            // CurrentLayerLabel
            // 
            this.CurrentLayerLabel.AutoSize = true;
            this.CurrentLayerLabel.Location = new System.Drawing.Point(12, 55);
            this.CurrentLayerLabel.Name = "CurrentLayerLabel";
            this.CurrentLayerLabel.Size = new System.Drawing.Size(76, 13);
            this.CurrentLayerLabel.TabIndex = 13;
            this.CurrentLayerLabel.Text = "Current Layer :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SmoothCornersRadioBuutton);
            this.panel1.Controls.Add(this.SharpCornersRadioButton);
            this.panel1.Location = new System.Drawing.Point(151, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 42);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SmoothSidesRadio);
            this.panel2.Controls.Add(this.RoughSidesRadio);
            this.panel2.Location = new System.Drawing.Point(151, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(106, 42);
            this.panel2.TabIndex = 15;
            // 
            // LevelEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 307);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CurrentLayerLabel);
            this.Controls.Add(this.CurrentLayerBox);
            this.Controls.Add(this.SelectObjectListBox);
            this.Controls.Add(this.SelectObjectLabel);
            this.Controls.Add(this.ObjectShapeSelector);
            this.Controls.Add(this.SearchObjectsLabel);
            this.Controls.Add(this.ObjectSearchBox);
            this.Controls.Add(this.LevelNameLabel);
            this.Controls.Add(this.LevelNameBox);
            this.Name = "LevelEditorWindow";
            this.Text = "LevelEditorWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LevelNameBox;
        private System.Windows.Forms.Label LevelNameLabel;
        private System.Windows.Forms.Label SearchObjectsLabel;
        private System.Windows.Forms.TextBox ObjectSearchBox;
        private System.Windows.Forms.ComboBox ObjectShapeSelector;
        private System.Windows.Forms.Label SelectObjectLabel;
        private System.Windows.Forms.ListBox SelectObjectListBox;
        private System.Windows.Forms.RadioButton SmoothCornersRadioBuutton;
        private System.Windows.Forms.RadioButton SharpCornersRadioButton;
        private System.Windows.Forms.RadioButton RoughSidesRadio;
        private System.Windows.Forms.RadioButton SmoothSidesRadio;
        private System.Windows.Forms.ComboBox CurrentLayerBox;
        private System.Windows.Forms.Label CurrentLayerLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
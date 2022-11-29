
namespace SoliaQuestClassic
{
    partial class FightDialog
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
            this.creatureStats = new System.Windows.Forms.Label();
            this.creatureEnemy = new System.Windows.Forms.Label();
            this.creatureAttackInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.abilityTypeImg2 = new System.Windows.Forms.PictureBox();
            this.abilityTypeImg1 = new System.Windows.Forms.PictureBox();
            this.abilityTypeImg0 = new System.Windows.Forms.PictureBox();
            this.useSelectedAbility = new System.Windows.Forms.Button();
            this.selectAbilityLast = new System.Windows.Forms.Button();
            this.selectAbilityNext = new System.Windows.Forms.Button();
            this.selectAbilityTypes = new System.Windows.Forms.Label();
            this.selectAbilityName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abilityTypeImg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilityTypeImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilityTypeImg0)).BeginInit();
            this.SuspendLayout();
            // 
            // creatureStats
            // 
            this.creatureStats.AutoSize = true;
            this.creatureStats.Location = new System.Drawing.Point(375, 9);
            this.creatureStats.Name = "creatureStats";
            this.creatureStats.Size = new System.Drawing.Size(23, 13);
            this.creatureStats.TabIndex = 0;
            this.creatureStats.Text = "null";
            // 
            // creatureEnemy
            // 
            this.creatureEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.creatureEnemy.AutoSize = true;
            this.creatureEnemy.Location = new System.Drawing.Point(558, 9);
            this.creatureEnemy.Name = "creatureEnemy";
            this.creatureEnemy.Size = new System.Drawing.Size(23, 13);
            this.creatureEnemy.TabIndex = 1;
            this.creatureEnemy.Text = "null";
            this.creatureEnemy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // creatureAttackInfo
            // 
            this.creatureAttackInfo.AutoSize = true;
            this.creatureAttackInfo.Location = new System.Drawing.Point(97, 34);
            this.creatureAttackInfo.Name = "creatureAttackInfo";
            this.creatureAttackInfo.Size = new System.Drawing.Size(57, 13);
            this.creatureAttackInfo.TabIndex = 3;
            this.creatureAttackInfo.Text = "yourattack";
            this.creatureAttackInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.abilityTypeImg2);
            this.panel1.Controls.Add(this.abilityTypeImg1);
            this.panel1.Controls.Add(this.abilityTypeImg0);
            this.panel1.Controls.Add(this.useSelectedAbility);
            this.panel1.Controls.Add(this.selectAbilityLast);
            this.panel1.Controls.Add(this.selectAbilityNext);
            this.panel1.Controls.Add(this.selectAbilityTypes);
            this.panel1.Controls.Add(this.selectAbilityName);
            this.panel1.Location = new System.Drawing.Point(12, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 120);
            this.panel1.TabIndex = 4;
            // 
            // abilityTypeImg2
            // 
            this.abilityTypeImg2.Location = new System.Drawing.Point(205, 10);
            this.abilityTypeImg2.Name = "abilityTypeImg2";
            this.abilityTypeImg2.Size = new System.Drawing.Size(25, 25);
            this.abilityTypeImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.abilityTypeImg2.TabIndex = 24;
            this.abilityTypeImg2.TabStop = false;
            // 
            // abilityTypeImg1
            // 
            this.abilityTypeImg1.Location = new System.Drawing.Point(183, 10);
            this.abilityTypeImg1.Name = "abilityTypeImg1";
            this.abilityTypeImg1.Size = new System.Drawing.Size(25, 25);
            this.abilityTypeImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.abilityTypeImg1.TabIndex = 23;
            this.abilityTypeImg1.TabStop = false;
            // 
            // abilityTypeImg0
            // 
            this.abilityTypeImg0.Location = new System.Drawing.Point(159, 10);
            this.abilityTypeImg0.Name = "abilityTypeImg0";
            this.abilityTypeImg0.Size = new System.Drawing.Size(25, 25);
            this.abilityTypeImg0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.abilityTypeImg0.TabIndex = 22;
            this.abilityTypeImg0.TabStop = false;
            // 
            // useSelectedAbility
            // 
            this.useSelectedAbility.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.useSelectedAbility.Location = new System.Drawing.Point(262, 94);
            this.useSelectedAbility.Name = "useSelectedAbility";
            this.useSelectedAbility.Size = new System.Drawing.Size(74, 23);
            this.useSelectedAbility.TabIndex = 10;
            this.useSelectedAbility.Text = "Use Ability >";
            this.useSelectedAbility.UseVisualStyleBackColor = true;
            this.useSelectedAbility.Click += new System.EventHandler(this.useSelectedAbility_Click);
            // 
            // selectAbilityLast
            // 
            this.selectAbilityLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAbilityLast.Location = new System.Drawing.Point(8, 94);
            this.selectAbilityLast.Name = "selectAbilityLast";
            this.selectAbilityLast.Size = new System.Drawing.Size(74, 23);
            this.selectAbilityLast.TabIndex = 9;
            this.selectAbilityLast.Text = "< Previous";
            this.selectAbilityLast.UseVisualStyleBackColor = true;
            this.selectAbilityLast.Click += new System.EventHandler(this.selectAbilityLast_Click);
            // 
            // selectAbilityNext
            // 
            this.selectAbilityNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAbilityNext.Location = new System.Drawing.Point(88, 94);
            this.selectAbilityNext.Name = "selectAbilityNext";
            this.selectAbilityNext.Size = new System.Drawing.Size(74, 23);
            this.selectAbilityNext.TabIndex = 1;
            this.selectAbilityNext.Text = "Next >";
            this.selectAbilityNext.UseVisualStyleBackColor = true;
            this.selectAbilityNext.Click += new System.EventHandler(this.selectAbilityNext_Click);
            // 
            // selectAbilityTypes
            // 
            this.selectAbilityTypes.AutoSize = true;
            this.selectAbilityTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAbilityTypes.Location = new System.Drawing.Point(5, 35);
            this.selectAbilityTypes.Name = "selectAbilityTypes";
            this.selectAbilityTypes.Size = new System.Drawing.Size(76, 13);
            this.selectAbilityTypes.TabIndex = 8;
            this.selectAbilityTypes.Text = "does things!";
            // 
            // selectAbilityName
            // 
            this.selectAbilityName.AutoSize = true;
            this.selectAbilityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAbilityName.Location = new System.Drawing.Point(3, 9);
            this.selectAbilityName.Name = "selectAbilityName";
            this.selectAbilityName.Size = new System.Drawing.Size(175, 25);
            this.selectAbilityName.TabIndex = 2;
            this.selectAbilityName.Text = "Creature Ability";
            // 
            // FightDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 307);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.creatureAttackInfo);
            this.Controls.Add(this.creatureEnemy);
            this.Controls.Add(this.creatureStats);
            this.Name = "FightDialog";
            this.Text = "Fight! SoliaQuest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FightDialog_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abilityTypeImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilityTypeImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilityTypeImg0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label creatureStats;
        private System.Windows.Forms.Label creatureEnemy;
        private System.Windows.Forms.Label creatureAttackInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectAbilityLast;
        private System.Windows.Forms.Button selectAbilityNext;
        private System.Windows.Forms.Label selectAbilityTypes;
        private System.Windows.Forms.Label selectAbilityName;
        private System.Windows.Forms.Button useSelectedAbility;
        private System.Windows.Forms.PictureBox abilityTypeImg2;
        private System.Windows.Forms.PictureBox abilityTypeImg1;
        private System.Windows.Forms.PictureBox abilityTypeImg0;
    }
}
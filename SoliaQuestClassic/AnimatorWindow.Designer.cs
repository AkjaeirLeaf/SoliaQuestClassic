
namespace SoliaQuestClassic
{
    partial class AnimatorWindow
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
            this.AnimEditTabs = new System.Windows.Forms.TabControl();
            this.Tab_Bones = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SLIDER_BoneAxisPhase = new System.Windows.Forms.TrackBar();
            this.TXT_AXIS_YAW_Z = new System.Windows.Forms.TextBox();
            this.TXT_AXIS_YAW_Y = new System.Windows.Forms.TextBox();
            this.TXT_AXIS_YAW_X = new System.Windows.Forms.TextBox();
            this.Label_EditBoneAxisLabelX = new System.Windows.Forms.Label();
            this.TXT_AXIS_PITCH_Z = new System.Windows.Forms.TextBox();
            this.TXT_AXIS_PITCH_Y = new System.Windows.Forms.TextBox();
            this.TXT_AXIS_PITCH_X = new System.Windows.Forms.TextBox();
            this.TXT_AXIS_HEADING_Z = new System.Windows.Forms.TextBox();
            this.TXT_AXIS_HEADING_Y = new System.Windows.Forms.TextBox();
            this.TXT_AXIS_HEADING_X = new System.Windows.Forms.TextBox();
            this.Label_EditBoneAxisLabelY = new System.Windows.Forms.Label();
            this.Label_EditBoneAxisLabelZ = new System.Windows.Forms.Label();
            this.Label_BoneAxis = new System.Windows.Forms.Label();
            this.Button_SaveBone = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Label_BonePair = new System.Windows.Forms.Label();
            this.TXT_ParentName = new System.Windows.Forms.TextBox();
            this.Label_boneparentname = new System.Windows.Forms.Label();
            this.TXT_BoneName = new System.Windows.Forms.TextBox();
            this.Label_bonerename = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label_BoneChildren = new System.Windows.Forms.Label();
            this.Box_ListChildren = new System.Windows.Forms.ListBox();
            this.Button_ExportObjectInfo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label_BoneLength = new System.Windows.Forms.Label();
            this.TXT_TailPosition_Z = new System.Windows.Forms.TextBox();
            this.TXT_TailPosition_Y = new System.Windows.Forms.TextBox();
            this.TXT_TailPosition_X = new System.Windows.Forms.TextBox();
            this.TXT_HeadPosition_Z = new System.Windows.Forms.TextBox();
            this.TXT_HeadPosition_Y = new System.Windows.Forms.TextBox();
            this.TXT_HeadPosition_X = new System.Windows.Forms.TextBox();
            this.Label_EditTailPosition = new System.Windows.Forms.Label();
            this.Label_EditHeadPosition = new System.Windows.Forms.Label();
            this.Label_BoneDetailsT1 = new System.Windows.Forms.Label();
            this.Button_ParentBone = new System.Windows.Forms.Button();
            this.Label_BoneList = new System.Windows.Forms.Label();
            this.Box_BoneList = new System.Windows.Forms.ListBox();
            this.Tab_Pose = new System.Windows.Forms.TabPage();
            this.Label_SelectedBone_PosesPage = new System.Windows.Forms.Label();
            this.Tab_Animation = new System.Windows.Forms.TabPage();
            this.COMBO_BoneTypeCat = new System.Windows.Forms.ComboBox();
            this.Label_boneAutoCategory = new System.Windows.Forms.Label();
            this.COMBO_LOCKYAWTO = new System.Windows.Forms.ComboBox();
            this.COMBO_LOCKPITCHTO = new System.Windows.Forms.ComboBox();
            this.LABEL_POSE_VIEW_X = new System.Windows.Forms.Label();
            this.TRACK_POSE_PREVIEW_X = new System.Windows.Forms.TrackBar();
            this.LABEL_POSE_VIEW_Y = new System.Windows.Forms.Label();
            this.TRACK_POSE_PREVIEW_Y = new System.Windows.Forms.TrackBar();
            this.LABEL_POSE_VIEW_Z = new System.Windows.Forms.Label();
            this.TRACK_POSE_PREVIEW_Z = new System.Windows.Forms.TrackBar();
            this.CHECK_ShowWeightValues = new System.Windows.Forms.CheckBox();
            this.RTB_RawDataEntry = new System.Windows.Forms.RichTextBox();
            this.DataOverrideTab = new System.Windows.Forms.TabPage();
            this.LABEL_DDO_DESC = new System.Windows.Forms.Label();
            this.PANEL_TB4_Objinfo = new System.Windows.Forms.Panel();
            this.LABEL_Meshdata_Vertcount = new System.Windows.Forms.Label();
            this.RTB_PointInfluence_Override = new System.Windows.Forms.RichTextBox();
            this.RTB_WeightReference_Override = new System.Windows.Forms.RichTextBox();
            this.BUTTON_OverrideWeightData = new System.Windows.Forms.Button();
            this.DebugConsoleTab = new System.Windows.Forms.TabPage();
            this.RTB_ConsoleOutputBox = new System.Windows.Forms.RichTextBox();
            this.RTB_ConsoleInputBox = new System.Windows.Forms.TextBox();
            this.AnimEditTabs.SuspendLayout();
            this.Tab_Bones.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLIDER_BoneAxisPhase)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Tab_Pose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_POSE_PREVIEW_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_POSE_PREVIEW_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_POSE_PREVIEW_Z)).BeginInit();
            this.DataOverrideTab.SuspendLayout();
            this.PANEL_TB4_Objinfo.SuspendLayout();
            this.DebugConsoleTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnimEditTabs
            // 
            this.AnimEditTabs.Controls.Add(this.Tab_Bones);
            this.AnimEditTabs.Controls.Add(this.Tab_Pose);
            this.AnimEditTabs.Controls.Add(this.Tab_Animation);
            this.AnimEditTabs.Controls.Add(this.DataOverrideTab);
            this.AnimEditTabs.Controls.Add(this.DebugConsoleTab);
            this.AnimEditTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimEditTabs.Location = new System.Drawing.Point(0, 0);
            this.AnimEditTabs.Name = "AnimEditTabs";
            this.AnimEditTabs.SelectedIndex = 0;
            this.AnimEditTabs.Size = new System.Drawing.Size(821, 315);
            this.AnimEditTabs.TabIndex = 0;
            // 
            // Tab_Bones
            // 
            this.Tab_Bones.Controls.Add(this.RTB_RawDataEntry);
            this.Tab_Bones.Controls.Add(this.panel4);
            this.Tab_Bones.Controls.Add(this.Button_SaveBone);
            this.Tab_Bones.Controls.Add(this.panel3);
            this.Tab_Bones.Controls.Add(this.panel2);
            this.Tab_Bones.Controls.Add(this.Button_ExportObjectInfo);
            this.Tab_Bones.Controls.Add(this.panel1);
            this.Tab_Bones.Controls.Add(this.Button_ParentBone);
            this.Tab_Bones.Controls.Add(this.Label_BoneList);
            this.Tab_Bones.Controls.Add(this.Box_BoneList);
            this.Tab_Bones.Location = new System.Drawing.Point(4, 22);
            this.Tab_Bones.Name = "Tab_Bones";
            this.Tab_Bones.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Bones.Size = new System.Drawing.Size(813, 289);
            this.Tab_Bones.TabIndex = 0;
            this.Tab_Bones.Text = "Armature & Bones";
            this.Tab_Bones.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.COMBO_LOCKPITCHTO);
            this.panel4.Controls.Add(this.COMBO_LOCKYAWTO);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.SLIDER_BoneAxisPhase);
            this.panel4.Controls.Add(this.TXT_AXIS_YAW_Z);
            this.panel4.Controls.Add(this.TXT_AXIS_YAW_Y);
            this.panel4.Controls.Add(this.TXT_AXIS_YAW_X);
            this.panel4.Controls.Add(this.Label_EditBoneAxisLabelX);
            this.panel4.Controls.Add(this.TXT_AXIS_PITCH_Z);
            this.panel4.Controls.Add(this.TXT_AXIS_PITCH_Y);
            this.panel4.Controls.Add(this.TXT_AXIS_PITCH_X);
            this.panel4.Controls.Add(this.TXT_AXIS_HEADING_Z);
            this.panel4.Controls.Add(this.TXT_AXIS_HEADING_Y);
            this.panel4.Controls.Add(this.TXT_AXIS_HEADING_X);
            this.panel4.Controls.Add(this.Label_EditBoneAxisLabelY);
            this.panel4.Controls.Add(this.Label_EditBoneAxisLabelZ);
            this.panel4.Controls.Add(this.Label_BoneAxis);
            this.panel4.Location = new System.Drawing.Point(416, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 235);
            this.panel4.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Axial Phase (Based on HEADING axis)";
            // 
            // SLIDER_BoneAxisPhase
            // 
            this.SLIDER_BoneAxisPhase.Location = new System.Drawing.Point(6, 174);
            this.SLIDER_BoneAxisPhase.Maximum = 360;
            this.SLIDER_BoneAxisPhase.Name = "SLIDER_BoneAxisPhase";
            this.SLIDER_BoneAxisPhase.Size = new System.Drawing.Size(366, 45);
            this.SLIDER_BoneAxisPhase.TabIndex = 15;
            this.SLIDER_BoneAxisPhase.Scroll += new System.EventHandler(this.SLIDER_BoneAxisPhase_Scroll);
            // 
            // TXT_AXIS_YAW_Z
            // 
            this.TXT_AXIS_YAW_Z.Location = new System.Drawing.Point(173, 93);
            this.TXT_AXIS_YAW_Z.Name = "TXT_AXIS_YAW_Z";
            this.TXT_AXIS_YAW_Z.ReadOnly = true;
            this.TXT_AXIS_YAW_Z.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_YAW_Z.TabIndex = 14;
            // 
            // TXT_AXIS_YAW_Y
            // 
            this.TXT_AXIS_YAW_Y.Location = new System.Drawing.Point(173, 67);
            this.TXT_AXIS_YAW_Y.Name = "TXT_AXIS_YAW_Y";
            this.TXT_AXIS_YAW_Y.ReadOnly = true;
            this.TXT_AXIS_YAW_Y.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_YAW_Y.TabIndex = 13;
            // 
            // TXT_AXIS_YAW_X
            // 
            this.TXT_AXIS_YAW_X.Location = new System.Drawing.Point(173, 41);
            this.TXT_AXIS_YAW_X.Name = "TXT_AXIS_YAW_X";
            this.TXT_AXIS_YAW_X.ReadOnly = true;
            this.TXT_AXIS_YAW_X.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_YAW_X.TabIndex = 12;
            // 
            // Label_EditBoneAxisLabelX
            // 
            this.Label_EditBoneAxisLabelX.AutoSize = true;
            this.Label_EditBoneAxisLabelX.Location = new System.Drawing.Point(128, 29);
            this.Label_EditBoneAxisLabelX.Name = "Label_EditBoneAxisLabelX";
            this.Label_EditBoneAxisLabelX.Size = new System.Drawing.Size(50, 78);
            this.Label_EditBoneAxisLabelX.TabIndex = 11;
            this.Label_EditBoneAxisLabelX.Text = "Yaw (Y) :\r\nX      :\r\n\r\nY      :\r\n\r\nZ      :";
            // 
            // TXT_AXIS_PITCH_Z
            // 
            this.TXT_AXIS_PITCH_Z.Location = new System.Drawing.Point(298, 93);
            this.TXT_AXIS_PITCH_Z.Name = "TXT_AXIS_PITCH_Z";
            this.TXT_AXIS_PITCH_Z.ReadOnly = true;
            this.TXT_AXIS_PITCH_Z.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_PITCH_Z.TabIndex = 10;
            // 
            // TXT_AXIS_PITCH_Y
            // 
            this.TXT_AXIS_PITCH_Y.Location = new System.Drawing.Point(298, 67);
            this.TXT_AXIS_PITCH_Y.Name = "TXT_AXIS_PITCH_Y";
            this.TXT_AXIS_PITCH_Y.ReadOnly = true;
            this.TXT_AXIS_PITCH_Y.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_PITCH_Y.TabIndex = 9;
            // 
            // TXT_AXIS_PITCH_X
            // 
            this.TXT_AXIS_PITCH_X.Location = new System.Drawing.Point(298, 41);
            this.TXT_AXIS_PITCH_X.Name = "TXT_AXIS_PITCH_X";
            this.TXT_AXIS_PITCH_X.ReadOnly = true;
            this.TXT_AXIS_PITCH_X.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_PITCH_X.TabIndex = 8;
            // 
            // TXT_AXIS_HEADING_Z
            // 
            this.TXT_AXIS_HEADING_Z.Location = new System.Drawing.Point(48, 93);
            this.TXT_AXIS_HEADING_Z.Name = "TXT_AXIS_HEADING_Z";
            this.TXT_AXIS_HEADING_Z.ReadOnly = true;
            this.TXT_AXIS_HEADING_Z.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_HEADING_Z.TabIndex = 7;
            // 
            // TXT_AXIS_HEADING_Y
            // 
            this.TXT_AXIS_HEADING_Y.Location = new System.Drawing.Point(48, 67);
            this.TXT_AXIS_HEADING_Y.Name = "TXT_AXIS_HEADING_Y";
            this.TXT_AXIS_HEADING_Y.ReadOnly = true;
            this.TXT_AXIS_HEADING_Y.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_HEADING_Y.TabIndex = 6;
            // 
            // TXT_AXIS_HEADING_X
            // 
            this.TXT_AXIS_HEADING_X.Location = new System.Drawing.Point(48, 41);
            this.TXT_AXIS_HEADING_X.Name = "TXT_AXIS_HEADING_X";
            this.TXT_AXIS_HEADING_X.ReadOnly = true;
            this.TXT_AXIS_HEADING_X.Size = new System.Drawing.Size(74, 20);
            this.TXT_AXIS_HEADING_X.TabIndex = 5;
            // 
            // Label_EditBoneAxisLabelY
            // 
            this.Label_EditBoneAxisLabelY.AutoSize = true;
            this.Label_EditBoneAxisLabelY.Location = new System.Drawing.Point(253, 29);
            this.Label_EditBoneAxisLabelY.Name = "Label_EditBoneAxisLabelY";
            this.Label_EditBoneAxisLabelY.Size = new System.Drawing.Size(53, 78);
            this.Label_EditBoneAxisLabelY.TabIndex = 5;
            this.Label_EditBoneAxisLabelY.Text = "Pitch (X) :\r\nX      :\r\n\r\nY      :\r\n\r\nZ      :";
            // 
            // Label_EditBoneAxisLabelZ
            // 
            this.Label_EditBoneAxisLabelZ.AutoSize = true;
            this.Label_EditBoneAxisLabelZ.Location = new System.Drawing.Point(3, 29);
            this.Label_EditBoneAxisLabelZ.Name = "Label_EditBoneAxisLabelZ";
            this.Label_EditBoneAxisLabelZ.Size = new System.Drawing.Size(69, 78);
            this.Label_EditBoneAxisLabelZ.TabIndex = 4;
            this.Label_EditBoneAxisLabelZ.Text = "Heading (Z) :\r\nX      :\r\n\r\nY      :\r\n\r\nZ      :";
            // 
            // Label_BoneAxis
            // 
            this.Label_BoneAxis.AutoSize = true;
            this.Label_BoneAxis.Location = new System.Drawing.Point(-2, 0);
            this.Label_BoneAxis.Name = "Label_BoneAxis";
            this.Label_BoneAxis.Size = new System.Drawing.Size(82, 13);
            this.Label_BoneAxis.TabIndex = 3;
            this.Label_BoneAxis.Text = "Bone Basis Axis";
            // 
            // Button_SaveBone
            // 
            this.Button_SaveBone.Location = new System.Drawing.Point(220, 264);
            this.Button_SaveBone.Name = "Button_SaveBone";
            this.Button_SaveBone.Size = new System.Drawing.Size(78, 23);
            this.Button_SaveBone.TabIndex = 14;
            this.Button_SaveBone.Text = "Save Bone";
            this.Button_SaveBone.UseVisualStyleBackColor = true;
            this.Button_SaveBone.Click += new System.EventHandler(this.Button_SaveBone_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Label_BonePair);
            this.panel3.Controls.Add(this.TXT_ParentName);
            this.panel3.Controls.Add(this.Label_boneparentname);
            this.panel3.Controls.Add(this.TXT_BoneName);
            this.panel3.Controls.Add(this.Label_bonerename);
            this.panel3.Location = new System.Drawing.Point(139, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(141, 106);
            this.panel3.TabIndex = 13;
            // 
            // Label_BonePair
            // 
            this.Label_BonePair.AutoSize = true;
            this.Label_BonePair.Location = new System.Drawing.Point(3, 85);
            this.Label_BonePair.Name = "Label_BonePair";
            this.Label_BonePair.Size = new System.Drawing.Size(75, 13);
            this.Label_BonePair.TabIndex = 17;
            this.Label_BonePair.Text = "No Pair Found";
            // 
            // TXT_ParentName
            // 
            this.TXT_ParentName.Location = new System.Drawing.Point(3, 59);
            this.TXT_ParentName.Name = "TXT_ParentName";
            this.TXT_ParentName.ReadOnly = true;
            this.TXT_ParentName.Size = new System.Drawing.Size(131, 20);
            this.TXT_ParentName.TabIndex = 13;
            // 
            // Label_boneparentname
            // 
            this.Label_boneparentname.AutoSize = true;
            this.Label_boneparentname.Location = new System.Drawing.Point(-2, 43);
            this.Label_boneparentname.Name = "Label_boneparentname";
            this.Label_boneparentname.Size = new System.Drawing.Size(66, 13);
            this.Label_boneparentname.TabIndex = 14;
            this.Label_boneparentname.Text = "Bone Parent";
            // 
            // TXT_BoneName
            // 
            this.TXT_BoneName.Location = new System.Drawing.Point(3, 16);
            this.TXT_BoneName.Name = "TXT_BoneName";
            this.TXT_BoneName.Size = new System.Drawing.Size(131, 20);
            this.TXT_BoneName.TabIndex = 12;
            // 
            // Label_bonerename
            // 
            this.Label_bonerename.AutoSize = true;
            this.Label_bonerename.Location = new System.Drawing.Point(-2, 0);
            this.Label_bonerename.Name = "Label_bonerename";
            this.Label_bonerename.Size = new System.Drawing.Size(63, 13);
            this.Label_bonerename.TabIndex = 12;
            this.Label_bonerename.Text = "Bone Name";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Label_BoneChildren);
            this.panel2.Controls.Add(this.Box_ListChildren);
            this.panel2.Location = new System.Drawing.Point(286, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 106);
            this.panel2.TabIndex = 6;
            // 
            // Label_BoneChildren
            // 
            this.Label_BoneChildren.AutoSize = true;
            this.Label_BoneChildren.Location = new System.Drawing.Point(-2, 0);
            this.Label_BoneChildren.Name = "Label_BoneChildren";
            this.Label_BoneChildren.Size = new System.Drawing.Size(73, 13);
            this.Label_BoneChildren.TabIndex = 12;
            this.Label_BoneChildren.Text = "Bone Children";
            // 
            // Box_ListChildren
            // 
            this.Box_ListChildren.FormattingEnabled = true;
            this.Box_ListChildren.Location = new System.Drawing.Point(3, 16);
            this.Box_ListChildren.Name = "Box_ListChildren";
            this.Box_ListChildren.Size = new System.Drawing.Size(111, 82);
            this.Box_ListChildren.TabIndex = 7;
            // 
            // Button_ExportObjectInfo
            // 
            this.Button_ExportObjectInfo.Location = new System.Drawing.Point(304, 264);
            this.Button_ExportObjectInfo.Name = "Button_ExportObjectInfo";
            this.Button_ExportObjectInfo.Size = new System.Drawing.Size(106, 23);
            this.Button_ExportObjectInfo.TabIndex = 5;
            this.Button_ExportObjectInfo.Text = "Export To Debug";
            this.Button_ExportObjectInfo.UseVisualStyleBackColor = true;
            this.Button_ExportObjectInfo.Click += new System.EventHandler(this.Button_ExportObjectInfo_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Label_BoneLength);
            this.panel1.Controls.Add(this.TXT_TailPosition_Z);
            this.panel1.Controls.Add(this.TXT_TailPosition_Y);
            this.panel1.Controls.Add(this.TXT_TailPosition_X);
            this.panel1.Controls.Add(this.TXT_HeadPosition_Z);
            this.panel1.Controls.Add(this.TXT_HeadPosition_Y);
            this.panel1.Controls.Add(this.TXT_HeadPosition_X);
            this.panel1.Controls.Add(this.Label_EditTailPosition);
            this.panel1.Controls.Add(this.Label_EditHeadPosition);
            this.panel1.Controls.Add(this.Label_BoneDetailsT1);
            this.panel1.Location = new System.Drawing.Point(139, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 123);
            this.panel1.TabIndex = 4;
            // 
            // Label_BoneLength
            // 
            this.Label_BoneLength.AutoSize = true;
            this.Label_BoneLength.Location = new System.Drawing.Point(128, 0);
            this.Label_BoneLength.Name = "Label_BoneLength";
            this.Label_BoneLength.Size = new System.Drawing.Size(40, 13);
            this.Label_BoneLength.TabIndex = 11;
            this.Label_BoneLength.Text = "Length";
            // 
            // TXT_TailPosition_Z
            // 
            this.TXT_TailPosition_Z.Location = new System.Drawing.Point(173, 93);
            this.TXT_TailPosition_Z.Name = "TXT_TailPosition_Z";
            this.TXT_TailPosition_Z.Size = new System.Drawing.Size(74, 20);
            this.TXT_TailPosition_Z.TabIndex = 10;
            this.TXT_TailPosition_Z.TextChanged += new System.EventHandler(this.TXT_TailPosition_Z_TextChanged);
            this.TXT_TailPosition_Z.Leave += new System.EventHandler(this.TXT_TailPosition_Z_Leave);
            // 
            // TXT_TailPosition_Y
            // 
            this.TXT_TailPosition_Y.Location = new System.Drawing.Point(173, 67);
            this.TXT_TailPosition_Y.Name = "TXT_TailPosition_Y";
            this.TXT_TailPosition_Y.Size = new System.Drawing.Size(74, 20);
            this.TXT_TailPosition_Y.TabIndex = 9;
            this.TXT_TailPosition_Y.TextChanged += new System.EventHandler(this.TXT_TailPosition_Y_TextChanged);
            this.TXT_TailPosition_Y.Leave += new System.EventHandler(this.TXT_TailPosition_Y_Leave);
            // 
            // TXT_TailPosition_X
            // 
            this.TXT_TailPosition_X.Location = new System.Drawing.Point(173, 41);
            this.TXT_TailPosition_X.Name = "TXT_TailPosition_X";
            this.TXT_TailPosition_X.Size = new System.Drawing.Size(74, 20);
            this.TXT_TailPosition_X.TabIndex = 8;
            this.TXT_TailPosition_X.TextChanged += new System.EventHandler(this.TXT_TailPosition_X_TextChanged);
            this.TXT_TailPosition_X.Leave += new System.EventHandler(this.TXT_TailPosition_X_Leave);
            // 
            // TXT_HeadPosition_Z
            // 
            this.TXT_HeadPosition_Z.Location = new System.Drawing.Point(48, 93);
            this.TXT_HeadPosition_Z.Name = "TXT_HeadPosition_Z";
            this.TXT_HeadPosition_Z.Size = new System.Drawing.Size(74, 20);
            this.TXT_HeadPosition_Z.TabIndex = 7;
            this.TXT_HeadPosition_Z.TextChanged += new System.EventHandler(this.TXT_HeadPosition_Z_TextChanged);
            this.TXT_HeadPosition_Z.Leave += new System.EventHandler(this.TXT_HeadPosition_Z_Leave);
            // 
            // TXT_HeadPosition_Y
            // 
            this.TXT_HeadPosition_Y.Location = new System.Drawing.Point(48, 67);
            this.TXT_HeadPosition_Y.Name = "TXT_HeadPosition_Y";
            this.TXT_HeadPosition_Y.Size = new System.Drawing.Size(74, 20);
            this.TXT_HeadPosition_Y.TabIndex = 6;
            this.TXT_HeadPosition_Y.TextChanged += new System.EventHandler(this.TXT_HeadPosition_Y_TextChanged);
            this.TXT_HeadPosition_Y.Leave += new System.EventHandler(this.TXT_HeadPosition_Y_Leave);
            // 
            // TXT_HeadPosition_X
            // 
            this.TXT_HeadPosition_X.Location = new System.Drawing.Point(48, 41);
            this.TXT_HeadPosition_X.Name = "TXT_HeadPosition_X";
            this.TXT_HeadPosition_X.Size = new System.Drawing.Size(74, 20);
            this.TXT_HeadPosition_X.TabIndex = 5;
            this.TXT_HeadPosition_X.TextChanged += new System.EventHandler(this.TXT_HeadPosition_X_TextChanged);
            this.TXT_HeadPosition_X.Leave += new System.EventHandler(this.TXT_HeadPosition_X_Leave);
            // 
            // Label_EditTailPosition
            // 
            this.Label_EditTailPosition.AutoSize = true;
            this.Label_EditTailPosition.Location = new System.Drawing.Point(128, 29);
            this.Label_EditTailPosition.Name = "Label_EditTailPosition";
            this.Label_EditTailPosition.Size = new System.Drawing.Size(35, 78);
            this.Label_EditTailPosition.TabIndex = 5;
            this.Label_EditTailPosition.Text = "Tail :\r\nX      :\r\n\r\nY      :\r\n\r\nZ      :";
            // 
            // Label_EditHeadPosition
            // 
            this.Label_EditHeadPosition.AutoSize = true;
            this.Label_EditHeadPosition.Location = new System.Drawing.Point(3, 29);
            this.Label_EditHeadPosition.Name = "Label_EditHeadPosition";
            this.Label_EditHeadPosition.Size = new System.Drawing.Size(39, 78);
            this.Label_EditHeadPosition.TabIndex = 4;
            this.Label_EditHeadPosition.Text = "Head :\r\nX      :\r\n\r\nY      :\r\n\r\nZ      :";
            // 
            // Label_BoneDetailsT1
            // 
            this.Label_BoneDetailsT1.AutoSize = true;
            this.Label_BoneDetailsT1.Location = new System.Drawing.Point(-2, 0);
            this.Label_BoneDetailsT1.Name = "Label_BoneDetailsT1";
            this.Label_BoneDetailsT1.Size = new System.Drawing.Size(86, 13);
            this.Label_BoneDetailsT1.TabIndex = 3;
            this.Label_BoneDetailsT1.Text = "Bone Positioning";
            // 
            // Button_ParentBone
            // 
            this.Button_ParentBone.Location = new System.Drawing.Point(139, 264);
            this.Button_ParentBone.Name = "Button_ParentBone";
            this.Button_ParentBone.Size = new System.Drawing.Size(75, 23);
            this.Button_ParentBone.TabIndex = 2;
            this.Button_ParentBone.Text = "Link Parent";
            this.Button_ParentBone.UseVisualStyleBackColor = true;
            this.Button_ParentBone.Click += new System.EventHandler(this.Button_ParentBone_Click);
            // 
            // Label_BoneList
            // 
            this.Label_BoneList.AutoSize = true;
            this.Label_BoneList.Location = new System.Drawing.Point(3, 3);
            this.Label_BoneList.Name = "Label_BoneList";
            this.Label_BoneList.Size = new System.Drawing.Size(51, 13);
            this.Label_BoneList.TabIndex = 1;
            this.Label_BoneList.Text = "Bone List";
            // 
            // Box_BoneList
            // 
            this.Box_BoneList.FormattingEnabled = true;
            this.Box_BoneList.Location = new System.Drawing.Point(3, 23);
            this.Box_BoneList.Name = "Box_BoneList";
            this.Box_BoneList.Size = new System.Drawing.Size(130, 264);
            this.Box_BoneList.TabIndex = 0;
            this.Box_BoneList.SelectedIndexChanged += new System.EventHandler(this.Box_BoneList_SelectedIndexChanged);
            // 
            // Tab_Pose
            // 
            this.Tab_Pose.Controls.Add(this.CHECK_ShowWeightValues);
            this.Tab_Pose.Controls.Add(this.LABEL_POSE_VIEW_Z);
            this.Tab_Pose.Controls.Add(this.TRACK_POSE_PREVIEW_Z);
            this.Tab_Pose.Controls.Add(this.LABEL_POSE_VIEW_Y);
            this.Tab_Pose.Controls.Add(this.TRACK_POSE_PREVIEW_Y);
            this.Tab_Pose.Controls.Add(this.LABEL_POSE_VIEW_X);
            this.Tab_Pose.Controls.Add(this.TRACK_POSE_PREVIEW_X);
            this.Tab_Pose.Controls.Add(this.Label_boneAutoCategory);
            this.Tab_Pose.Controls.Add(this.COMBO_BoneTypeCat);
            this.Tab_Pose.Controls.Add(this.Label_SelectedBone_PosesPage);
            this.Tab_Pose.Location = new System.Drawing.Point(4, 22);
            this.Tab_Pose.Name = "Tab_Pose";
            this.Tab_Pose.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Pose.Size = new System.Drawing.Size(813, 289);
            this.Tab_Pose.TabIndex = 1;
            this.Tab_Pose.Text = "Poses & Actions";
            this.Tab_Pose.UseVisualStyleBackColor = true;
            // 
            // Label_SelectedBone_PosesPage
            // 
            this.Label_SelectedBone_PosesPage.AutoSize = true;
            this.Label_SelectedBone_PosesPage.Location = new System.Drawing.Point(8, 3);
            this.Label_SelectedBone_PosesPage.Name = "Label_SelectedBone_PosesPage";
            this.Label_SelectedBone_PosesPage.Size = new System.Drawing.Size(63, 13);
            this.Label_SelectedBone_PosesPage.TabIndex = 3;
            this.Label_SelectedBone_PosesPage.Text = "Bone Name";
            // 
            // Tab_Animation
            // 
            this.Tab_Animation.Location = new System.Drawing.Point(4, 22);
            this.Tab_Animation.Name = "Tab_Animation";
            this.Tab_Animation.Size = new System.Drawing.Size(813, 289);
            this.Tab_Animation.TabIndex = 2;
            this.Tab_Animation.Text = "Animation";
            this.Tab_Animation.UseVisualStyleBackColor = true;
            // 
            // COMBO_BoneTypeCat
            // 
            this.COMBO_BoneTypeCat.FormattingEnabled = true;
            this.COMBO_BoneTypeCat.Location = new System.Drawing.Point(73, 24);
            this.COMBO_BoneTypeCat.Name = "COMBO_BoneTypeCat";
            this.COMBO_BoneTypeCat.Size = new System.Drawing.Size(121, 21);
            this.COMBO_BoneTypeCat.TabIndex = 4;
            this.COMBO_BoneTypeCat.SelectedIndexChanged += new System.EventHandler(this.COMBO_BoneTypeCat_SelectedIndexChanged);
            // 
            // Label_boneAutoCategory
            // 
            this.Label_boneAutoCategory.AutoSize = true;
            this.Label_boneAutoCategory.Location = new System.Drawing.Point(8, 27);
            this.Label_boneAutoCategory.Name = "Label_boneAutoCategory";
            this.Label_boneAutoCategory.Size = new System.Drawing.Size(59, 13);
            this.Label_boneAutoCategory.TabIndex = 5;
            this.Label_boneAutoCategory.Text = "Bone Type";
            // 
            // COMBO_LOCKYAWTO
            // 
            this.COMBO_LOCKYAWTO.FormattingEnabled = true;
            this.COMBO_LOCKYAWTO.Items.AddRange(new object[] {
            "No Yaw Lock.",
            "Global X",
            "Global Y",
            "Global Z"});
            this.COMBO_LOCKYAWTO.Location = new System.Drawing.Point(57, 119);
            this.COMBO_LOCKYAWTO.Name = "COMBO_LOCKYAWTO";
            this.COMBO_LOCKYAWTO.Size = new System.Drawing.Size(121, 21);
            this.COMBO_LOCKYAWTO.TabIndex = 17;
            this.COMBO_LOCKYAWTO.SelectedIndexChanged += new System.EventHandler(this.COMBO_LOCKYAWTO_SelectedIndexChanged);
            // 
            // COMBO_LOCKPITCHTO
            // 
            this.COMBO_LOCKPITCHTO.FormattingEnabled = true;
            this.COMBO_LOCKPITCHTO.Items.AddRange(new object[] {
            "No Pitch Lock.",
            "Global X",
            "Global Y",
            "Global Z"});
            this.COMBO_LOCKPITCHTO.Location = new System.Drawing.Point(228, 119);
            this.COMBO_LOCKPITCHTO.Name = "COMBO_LOCKPITCHTO";
            this.COMBO_LOCKPITCHTO.Size = new System.Drawing.Size(121, 21);
            this.COMBO_LOCKPITCHTO.TabIndex = 18;
            this.COMBO_LOCKPITCHTO.SelectedIndexChanged += new System.EventHandler(this.COMBO_LOCKPITCHTO_SelectedIndexChanged);
            // 
            // LABEL_POSE_VIEW_X
            // 
            this.LABEL_POSE_VIEW_X.AutoSize = true;
            this.LABEL_POSE_VIEW_X.Location = new System.Drawing.Point(436, 6);
            this.LABEL_POSE_VIEW_X.Name = "LABEL_POSE_VIEW_X";
            this.LABEL_POSE_VIEW_X.Size = new System.Drawing.Size(73, 13);
            this.LABEL_POSE_VIEW_X.TabIndex = 18;
            this.LABEL_POSE_VIEW_X.Text = "Test X Posing";
            // 
            // TRACK_POSE_PREVIEW_X
            // 
            this.TRACK_POSE_PREVIEW_X.Location = new System.Drawing.Point(439, 27);
            this.TRACK_POSE_PREVIEW_X.Maximum = 360;
            this.TRACK_POSE_PREVIEW_X.Name = "TRACK_POSE_PREVIEW_X";
            this.TRACK_POSE_PREVIEW_X.Size = new System.Drawing.Size(366, 45);
            this.TRACK_POSE_PREVIEW_X.TabIndex = 17;
            this.TRACK_POSE_PREVIEW_X.Value = 180;
            this.TRACK_POSE_PREVIEW_X.Scroll += new System.EventHandler(this.TRACK_POSE_PREVIEW_X_Scroll);
            // 
            // LABEL_POSE_VIEW_Y
            // 
            this.LABEL_POSE_VIEW_Y.AutoSize = true;
            this.LABEL_POSE_VIEW_Y.Location = new System.Drawing.Point(436, 75);
            this.LABEL_POSE_VIEW_Y.Name = "LABEL_POSE_VIEW_Y";
            this.LABEL_POSE_VIEW_Y.Size = new System.Drawing.Size(73, 13);
            this.LABEL_POSE_VIEW_Y.TabIndex = 20;
            this.LABEL_POSE_VIEW_Y.Text = "Test Y Posing";
            // 
            // TRACK_POSE_PREVIEW_Y
            // 
            this.TRACK_POSE_PREVIEW_Y.Location = new System.Drawing.Point(439, 96);
            this.TRACK_POSE_PREVIEW_Y.Maximum = 360;
            this.TRACK_POSE_PREVIEW_Y.Name = "TRACK_POSE_PREVIEW_Y";
            this.TRACK_POSE_PREVIEW_Y.Size = new System.Drawing.Size(366, 45);
            this.TRACK_POSE_PREVIEW_Y.TabIndex = 19;
            this.TRACK_POSE_PREVIEW_Y.Value = 180;
            this.TRACK_POSE_PREVIEW_Y.Scroll += new System.EventHandler(this.TRACK_POSE_PREVIEW_Y_Scroll);
            // 
            // LABEL_POSE_VIEW_Z
            // 
            this.LABEL_POSE_VIEW_Z.AutoSize = true;
            this.LABEL_POSE_VIEW_Z.Location = new System.Drawing.Point(436, 144);
            this.LABEL_POSE_VIEW_Z.Name = "LABEL_POSE_VIEW_Z";
            this.LABEL_POSE_VIEW_Z.Size = new System.Drawing.Size(73, 13);
            this.LABEL_POSE_VIEW_Z.TabIndex = 22;
            this.LABEL_POSE_VIEW_Z.Text = "Test Z Posing";
            // 
            // TRACK_POSE_PREVIEW_Z
            // 
            this.TRACK_POSE_PREVIEW_Z.Location = new System.Drawing.Point(439, 165);
            this.TRACK_POSE_PREVIEW_Z.Maximum = 360;
            this.TRACK_POSE_PREVIEW_Z.Name = "TRACK_POSE_PREVIEW_Z";
            this.TRACK_POSE_PREVIEW_Z.Size = new System.Drawing.Size(366, 45);
            this.TRACK_POSE_PREVIEW_Z.TabIndex = 21;
            this.TRACK_POSE_PREVIEW_Z.Value = 180;
            this.TRACK_POSE_PREVIEW_Z.Scroll += new System.EventHandler(this.TRACK_POSE_PREVIEW_Z_Scroll);
            // 
            // CHECK_ShowWeightValues
            // 
            this.CHECK_ShowWeightValues.AutoSize = true;
            this.CHECK_ShowWeightValues.Location = new System.Drawing.Point(307, 6);
            this.CHECK_ShowWeightValues.Name = "CHECK_ShowWeightValues";
            this.CHECK_ShowWeightValues.Size = new System.Drawing.Size(123, 17);
            this.CHECK_ShowWeightValues.TabIndex = 23;
            this.CHECK_ShowWeightValues.Text = "Show Bone Weights";
            this.CHECK_ShowWeightValues.UseVisualStyleBackColor = true;
            this.CHECK_ShowWeightValues.CheckedChanged += new System.EventHandler(this.CHECK_ShowWeightValues_CheckedChanged);
            // 
            // RTB_RawDataEntry
            // 
            this.RTB_RawDataEntry.Location = new System.Drawing.Point(3, 293);
            this.RTB_RawDataEntry.Name = "RTB_RawDataEntry";
            this.RTB_RawDataEntry.Size = new System.Drawing.Size(407, 96);
            this.RTB_RawDataEntry.TabIndex = 1;
            this.RTB_RawDataEntry.Text = "";
            this.RTB_RawDataEntry.Leave += new System.EventHandler(this.RTB_RawDataEntry_Leave);
            // 
            // DataOverrideTab
            // 
            this.DataOverrideTab.Controls.Add(this.BUTTON_OverrideWeightData);
            this.DataOverrideTab.Controls.Add(this.RTB_WeightReference_Override);
            this.DataOverrideTab.Controls.Add(this.RTB_PointInfluence_Override);
            this.DataOverrideTab.Controls.Add(this.PANEL_TB4_Objinfo);
            this.DataOverrideTab.Controls.Add(this.LABEL_DDO_DESC);
            this.DataOverrideTab.Location = new System.Drawing.Point(4, 22);
            this.DataOverrideTab.Name = "DataOverrideTab";
            this.DataOverrideTab.Size = new System.Drawing.Size(813, 289);
            this.DataOverrideTab.TabIndex = 3;
            this.DataOverrideTab.Text = "DEBUG Data Override";
            this.DataOverrideTab.UseVisualStyleBackColor = true;
            // 
            // LABEL_DDO_DESC
            // 
            this.LABEL_DDO_DESC.AutoSize = true;
            this.LABEL_DDO_DESC.Location = new System.Drawing.Point(3, 10);
            this.LABEL_DDO_DESC.Name = "LABEL_DDO_DESC";
            this.LABEL_DDO_DESC.Size = new System.Drawing.Size(189, 13);
            this.LABEL_DDO_DESC.TabIndex = 0;
            this.LABEL_DDO_DESC.Text = "APPLY UPDATED SKIN DATA HERE";
            // 
            // PANEL_TB4_Objinfo
            // 
            this.PANEL_TB4_Objinfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PANEL_TB4_Objinfo.Controls.Add(this.LABEL_Meshdata_Vertcount);
            this.PANEL_TB4_Objinfo.Location = new System.Drawing.Point(6, 26);
            this.PANEL_TB4_Objinfo.Name = "PANEL_TB4_Objinfo";
            this.PANEL_TB4_Objinfo.Size = new System.Drawing.Size(200, 77);
            this.PANEL_TB4_Objinfo.TabIndex = 1;
            // 
            // LABEL_Meshdata_Vertcount
            // 
            this.LABEL_Meshdata_Vertcount.AutoSize = true;
            this.LABEL_Meshdata_Vertcount.Location = new System.Drawing.Point(0, 0);
            this.LABEL_Meshdata_Vertcount.Name = "LABEL_Meshdata_Vertcount";
            this.LABEL_Meshdata_Vertcount.Size = new System.Drawing.Size(63, 13);
            this.LABEL_Meshdata_Vertcount.TabIndex = 2;
            this.LABEL_Meshdata_Vertcount.Text = "VERTICES:";
            // 
            // RTB_PointInfluence_Override
            // 
            this.RTB_PointInfluence_Override.Location = new System.Drawing.Point(212, 25);
            this.RTB_PointInfluence_Override.Name = "RTB_PointInfluence_Override";
            this.RTB_PointInfluence_Override.Size = new System.Drawing.Size(302, 96);
            this.RTB_PointInfluence_Override.TabIndex = 2;
            this.RTB_PointInfluence_Override.Text = "";
            // 
            // RTB_WeightReference_Override
            // 
            this.RTB_WeightReference_Override.Location = new System.Drawing.Point(212, 127);
            this.RTB_WeightReference_Override.Name = "RTB_WeightReference_Override";
            this.RTB_WeightReference_Override.Size = new System.Drawing.Size(302, 96);
            this.RTB_WeightReference_Override.TabIndex = 3;
            this.RTB_WeightReference_Override.Text = "";
            // 
            // BUTTON_OverrideWeightData
            // 
            this.BUTTON_OverrideWeightData.Location = new System.Drawing.Point(381, 229);
            this.BUTTON_OverrideWeightData.Name = "BUTTON_OverrideWeightData";
            this.BUTTON_OverrideWeightData.Size = new System.Drawing.Size(133, 23);
            this.BUTTON_OverrideWeightData.TabIndex = 4;
            this.BUTTON_OverrideWeightData.Text = "Insert New Weight Data";
            this.BUTTON_OverrideWeightData.UseVisualStyleBackColor = true;
            this.BUTTON_OverrideWeightData.Click += new System.EventHandler(this.BUTTON_OverrideWeightData_Click);
            // 
            // DebugConsoleTab
            // 
            this.DebugConsoleTab.BackColor = System.Drawing.Color.Black;
            this.DebugConsoleTab.Controls.Add(this.RTB_ConsoleInputBox);
            this.DebugConsoleTab.Controls.Add(this.RTB_ConsoleOutputBox);
            this.DebugConsoleTab.Location = new System.Drawing.Point(4, 22);
            this.DebugConsoleTab.Name = "DebugConsoleTab";
            this.DebugConsoleTab.Size = new System.Drawing.Size(813, 289);
            this.DebugConsoleTab.TabIndex = 4;
            this.DebugConsoleTab.Text = "CONSOLE";
            // 
            // RTB_ConsoleOutputBox
            // 
            this.RTB_ConsoleOutputBox.BackColor = System.Drawing.Color.Black;
            this.RTB_ConsoleOutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_ConsoleOutputBox.ForeColor = System.Drawing.Color.MediumOrchid;
            this.RTB_ConsoleOutputBox.Location = new System.Drawing.Point(0, 0);
            this.RTB_ConsoleOutputBox.Name = "RTB_ConsoleOutputBox";
            this.RTB_ConsoleOutputBox.Size = new System.Drawing.Size(813, 289);
            this.RTB_ConsoleOutputBox.TabIndex = 0;
            this.RTB_ConsoleOutputBox.Text = "";
            // 
            // RTB_ConsoleInputBox
            // 
            this.RTB_ConsoleInputBox.BackColor = System.Drawing.Color.Black;
            this.RTB_ConsoleInputBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RTB_ConsoleInputBox.ForeColor = System.Drawing.Color.MediumOrchid;
            this.RTB_ConsoleInputBox.Location = new System.Drawing.Point(0, 269);
            this.RTB_ConsoleInputBox.Name = "RTB_ConsoleInputBox";
            this.RTB_ConsoleInputBox.Size = new System.Drawing.Size(813, 20);
            this.RTB_ConsoleInputBox.TabIndex = 1;
            // 
            // AnimatorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 315);
            this.Controls.Add(this.AnimEditTabs);
            this.MaximumSize = new System.Drawing.Size(837, 354);
            this.MinimumSize = new System.Drawing.Size(837, 354);
            this.Name = "AnimatorWindow";
            this.Text = "Animator Window (Active Model)";
            this.AnimEditTabs.ResumeLayout(false);
            this.Tab_Bones.ResumeLayout(false);
            this.Tab_Bones.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLIDER_BoneAxisPhase)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Tab_Pose.ResumeLayout(false);
            this.Tab_Pose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_POSE_PREVIEW_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_POSE_PREVIEW_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_POSE_PREVIEW_Z)).EndInit();
            this.DataOverrideTab.ResumeLayout(false);
            this.DataOverrideTab.PerformLayout();
            this.PANEL_TB4_Objinfo.ResumeLayout(false);
            this.PANEL_TB4_Objinfo.PerformLayout();
            this.DebugConsoleTab.ResumeLayout(false);
            this.DebugConsoleTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl AnimEditTabs;
        private System.Windows.Forms.TabPage Tab_Bones;
        private System.Windows.Forms.TabPage Tab_Pose;
        private System.Windows.Forms.TabPage Tab_Animation;
        private System.Windows.Forms.ListBox Box_BoneList;
        private System.Windows.Forms.Label Label_BoneList;
        private System.Windows.Forms.Button Button_ParentBone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label_BoneDetailsT1;
        private System.Windows.Forms.TextBox TXT_HeadPosition_X;
        private System.Windows.Forms.Label Label_EditTailPosition;
        private System.Windows.Forms.Label Label_EditHeadPosition;
        private System.Windows.Forms.TextBox TXT_HeadPosition_Z;
        private System.Windows.Forms.TextBox TXT_HeadPosition_Y;
        private System.Windows.Forms.TextBox TXT_TailPosition_Z;
        private System.Windows.Forms.TextBox TXT_TailPosition_Y;
        private System.Windows.Forms.TextBox TXT_TailPosition_X;
        private System.Windows.Forms.Button Button_ExportObjectInfo;
        private System.Windows.Forms.Label Label_BoneLength;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Label_BoneChildren;
        private System.Windows.Forms.ListBox Box_ListChildren;
        private System.Windows.Forms.Label Label_SelectedBone_PosesPage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Label_bonerename;
        private System.Windows.Forms.TextBox TXT_BoneName;
        private System.Windows.Forms.Button Button_SaveBone;
        private System.Windows.Forms.TextBox TXT_ParentName;
        private System.Windows.Forms.Label Label_boneparentname;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox TXT_AXIS_PITCH_Z;
        private System.Windows.Forms.TextBox TXT_AXIS_PITCH_Y;
        private System.Windows.Forms.TextBox TXT_AXIS_PITCH_X;
        private System.Windows.Forms.TextBox TXT_AXIS_HEADING_Z;
        private System.Windows.Forms.TextBox TXT_AXIS_HEADING_Y;
        private System.Windows.Forms.TextBox TXT_AXIS_HEADING_X;
        private System.Windows.Forms.Label Label_EditBoneAxisLabelY;
        private System.Windows.Forms.Label Label_EditBoneAxisLabelZ;
        private System.Windows.Forms.Label Label_BoneAxis;
        private System.Windows.Forms.TextBox TXT_AXIS_YAW_Z;
        private System.Windows.Forms.TextBox TXT_AXIS_YAW_Y;
        private System.Windows.Forms.TextBox TXT_AXIS_YAW_X;
        private System.Windows.Forms.Label Label_EditBoneAxisLabelX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar SLIDER_BoneAxisPhase;
        private System.Windows.Forms.Label Label_BonePair;
        private System.Windows.Forms.Label Label_boneAutoCategory;
        private System.Windows.Forms.ComboBox COMBO_BoneTypeCat;
        private System.Windows.Forms.ComboBox COMBO_LOCKPITCHTO;
        private System.Windows.Forms.ComboBox COMBO_LOCKYAWTO;
        private System.Windows.Forms.Label LABEL_POSE_VIEW_Z;
        private System.Windows.Forms.TrackBar TRACK_POSE_PREVIEW_Z;
        private System.Windows.Forms.Label LABEL_POSE_VIEW_Y;
        private System.Windows.Forms.TrackBar TRACK_POSE_PREVIEW_Y;
        private System.Windows.Forms.Label LABEL_POSE_VIEW_X;
        private System.Windows.Forms.TrackBar TRACK_POSE_PREVIEW_X;
        private System.Windows.Forms.CheckBox CHECK_ShowWeightValues;
        private System.Windows.Forms.RichTextBox RTB_RawDataEntry;
        private System.Windows.Forms.TabPage DataOverrideTab;
        private System.Windows.Forms.Label LABEL_DDO_DESC;
        private System.Windows.Forms.Panel PANEL_TB4_Objinfo;
        private System.Windows.Forms.Label LABEL_Meshdata_Vertcount;
        private System.Windows.Forms.Button BUTTON_OverrideWeightData;
        private System.Windows.Forms.RichTextBox RTB_WeightReference_Override;
        private System.Windows.Forms.RichTextBox RTB_PointInfluence_Override;
        private System.Windows.Forms.TabPage DebugConsoleTab;
        private System.Windows.Forms.TextBox RTB_ConsoleInputBox;
        private System.Windows.Forms.RichTextBox RTB_ConsoleOutputBox;
    }
}
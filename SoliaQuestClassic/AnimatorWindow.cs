using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kirali.MathR;

using SoliaQuestClassic.Render;
using SoliaQuestClassic.IO;
using SoliaQuestClassic.SoulForge;
using SoliaQuestClassic.Render.UIObjectsLib;

namespace SoliaQuestClassic
{
    public partial class AnimatorWindow : Form
    {
        private static PoseableObject CurrentEditingPoseable;
        private static Object3D CurrentEditingMesh;
        private static int CurrentBoneDetailsEdit = -1;
        public static int EditIndex { get { return CurrentBoneDetailsEdit; } }
        private static int CurrentBonePairIndex = -1;
        public static int PairIndex { get { return CurrentBonePairIndex; } }
        private bool SelectedHasPair = false;
        private static int SetParentSelector = -1;
        private bool isSelectingLinkParent = false;

        
        // CONSOLE
        public void Cout<T>(T content)
        {
            RTB_ConsoleOutputBox.AppendText(content.ToString() + "\n");
        }
        public void RunCommand(string command)
        {
            Cout("Command Sent: \"" + command + "\"");
            switch (command)
            {
                case "export_object":
                    Cout("Exporting object data...");
                    ObjectJson json = ObjectJson.FromObject3D(CurrentEditingMesh);
                    json.Export();
                    Cout("Export Complete!");
                    break;
                default:
                    Cout("ERROR Command not recognised \"" + command + "\"");
                    break;
            }
        }


        public AnimatorWindow()
        {
            InitializeComponent();

            CurrentEditingMesh = SQGameWindow.PlayerTeam.Members[0].CreatureModel.LinkObject;
            CurrentEditingPoseable = SQGameWindow.PlayerTeam.Members[0].CreatureModel;
            ResetBoneTypeCombo();
            ResetBoneListBox();
            SLIDER_Center();

            Cout("Animator Window Console Initiated.");
        }

        // TOOLS
        private string GetNumeric(string val)
        {
            char[] arr = val.ToCharArray();
            string build = "";
            bool hasDecimalPoint = false;
            bool hasSign = false;
            bool encounterNumber = false;
            for (int ix = 0; ix < arr.Length; ix++)
            {
                if (Char.IsNumber(arr[ix])) { build += arr[ix]; encounterNumber = true; }
                else if (arr[ix] == '.' && !hasDecimalPoint) { build += arr[ix]; hasDecimalPoint = true; encounterNumber = true; }
                else if (arr[ix] == '-' && !hasSign && !encounterNumber) { build += arr[ix]; hasSign = true; }
            }
            return build;
        }
        private void AddChildTo()
        {
            SaveCurrentBone();
            if(CurrentEditingMesh.Armature_Bones[SetParentSelector].Link_Children != null)
            {
                if (CurrentEditingMesh.Armature_Bones[SetParentSelector].Link_Children.Length == 0)
                {
                    CurrentEditingMesh.Armature_Bones[SetParentSelector].Link_Children = new string[] { CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Name };
                }
                else
                {
                    string[] temp = new string[CurrentEditingMesh.Armature_Bones.Length + 1];
                    for (int ix = 0; ix < temp.Length - 1; ix++)
                    {
                        temp[ix] = CurrentEditingMesh.Armature_Bones[ix].Name;
                    }
                    temp[temp.Length - 1] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Name;
                    CurrentEditingMesh.Armature_Bones[SetParentSelector].Link_Children = temp;
                }
            }
            else
            {
                CurrentEditingMesh.Armature_Bones[SetParentSelector].Link_Children = new string[] { CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Name };
            }
            
        }
        private void SaveCurrentBone(bool update_axis = false)
        {
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Name = TXT_BoneName.Text;
            Double.TryParse(TXT_HeadPosition_X.Text, out CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[0]);
            Double.TryParse(TXT_HeadPosition_Y.Text, out CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[1]);
            Double.TryParse(TXT_HeadPosition_Z.Text, out CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[2]);
            Double.TryParse(TXT_TailPosition_X.Text, out CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[0]);
            Double.TryParse(TXT_TailPosition_Y.Text, out CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[1]);
            Double.TryParse(TXT_TailPosition_Z.Text, out CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[2]);


            UpdateSelectedBoneAXISDISPLAY(CurrentBoneDetailsEdit, update_axis, false);

            if(CurrentBonePairIndex != -1)
            {
                // write pair values

                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Head[0] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[0] * -1;
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Head[1] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[1];
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Head[2] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[2];
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Tail[0] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[0] * -1;
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Tail[1] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[1];
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Tail[2] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[2];

                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_P[0] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P[0] * -1;
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_P[1] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P[1];
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_P[2] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P[2];

                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_R[0] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_R[0] * -1;
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_R[1] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_R[1];
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_R[2] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_R[2];

                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_T[0] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T[0] * -1;
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_T[1] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T[1];
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_T[2] = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T[2];



            }
        }
        private int CheckBoneHasPair()
        {
            int pairIndex = -1;
            string bone_name = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Name;
            string pair_suggest = "";
            if(bone_name[bone_name.Length-1] == 'R') { pair_suggest = bone_name.Remove(bone_name.Length - 1, 1) + "L"; }
            else if(bone_name[bone_name.Length-1] == 'L') { pair_suggest = bone_name.Remove(bone_name.Length - 1, 1) + "R"; }

            for(int ix = 0; ix < CurrentEditingMesh.Armature_Bones.Length; ix++)
            {
                if (CurrentEditingMesh.Armature_Bones[ix].Name == pair_suggest) { pairIndex = ix; SelectedHasPair = true; CurrentBonePairIndex = ix; return pairIndex; }
            }
            SelectedHasPair = false; CurrentBonePairIndex = -1;
            return pairIndex;
        }
        
        //Updating ui to selections
        private void ResetBoneListBox()
        {
            Box_BoneList.Items.Clear();
            for (int ix = 0; ix < CurrentEditingMesh.Armature_Bones.Length; ix++)
            {
                Box_BoneList.Items.Add(CurrentEditingMesh.Armature_Bones[ix].Name);
            }
            CurrentBoneDetailsEdit = 0;
            Box_BoneList.SelectedIndex = CurrentBoneDetailsEdit;
        }
        private void ResetBoneTypeCombo()
        {
            COMBO_BoneTypeCat.Items.Clear();
            foreach(Bone_type_ident bti in Enum.GetValues(typeof(Bone_type_ident)))
            {
                COMBO_BoneTypeCat.Items.Add(bti.ToString());
            }
            
        }

        private void UpdateSelectedBoneDetails()
        {
            // armature editing page
            #region updatebonedeets_tab1
            TXT_BoneName.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Name;
            TXT_HeadPosition_X.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[0].ToString();
            TXT_HeadPosition_Y.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[1].ToString();
            TXT_HeadPosition_Z.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Head[2].ToString();
            TXT_TailPosition_X.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[0].ToString();
            TXT_TailPosition_Y.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[1].ToString();
            TXT_TailPosition_Z.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Tail[2].ToString();

            TXT_ParentName.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Parent_Name;

            Box_ListChildren.Items.Clear();
            if (CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Link_Children != null)
            {
                if (CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Link_Children.Length > 0)
                {
                    for (int ix = 0; ix < CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Link_Children.Length; ix++)
                    {
                        Box_ListChildren.Items.Add(CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Link_Children[ix]);
                    }
                }
            }
            else { CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Link_Children = new string[0]; }

            // Pair?
            if(CheckBoneHasPair() != -1)
            {
                Label_BonePair.Text = "Bone pair: " + CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Name;
            }
            else { Label_BonePair.Text = "Bone not a pair."; }

            UpdateSelectedBoneAXISDISPLAY(CurrentBoneDetailsEdit, false, false);

            COMBO_BoneTypeCat.SelectedIndex = (int)CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].bone_type;
            ResetComboLock();
            #endregion updatebonedeets_tab1
            // pose page
            Label_SelectedBone_PosesPage.Text = CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Name;

            // TAB4 Mesh override weight data;
            int null_pointInfluencectr = 0;
            for(int ix = 0; ix < CurrentEditingMesh.Point_Armature_Array.Length; ix++)
            {
                if(CurrentEditingMesh.Point_Armature_Array[ix].JOINT != null) { null_pointInfluencectr++; }
            }
            int null_weightRefctr = 0;
            for(int ix = 0; ix < CurrentEditingMesh.BoneInfluenceRef.Length; ix++)
            {
                if(CurrentEditingMesh.BoneInfluenceRef[ix] != 0) { null_weightRefctr++; }
            }

            LABEL_Meshdata_Vertcount.Text = "VERTICES: " + CurrentEditingMesh.PointData.Length + "\n" +
                "Point Influence Data: " + null_pointInfluencectr + " of " + CurrentEditingMesh.PointData.Length + "\n" +
                "Weight Data: " + null_weightRefctr + " of " + CurrentEditingMesh.BoneInfluenceRef.Length;



        }
        private void BUTTON_OverrideWeightData_Click(object sender, EventArgs e)
        {
            try
            {
                string[] PI_broken = RTB_PointInfluence_Override.Text.Split(' ');
                string[] Pointer_Broken = RTB_VPTR_Override.Text.Split(' ');
                string[] BoneWeights_broken = RTB_WeightReference_Override.Text.Split(' ');
                PointInfluence[] new_PI = new PointInfluence[PI_broken.Length];
                if(new_PI.Length == CurrentEditingMesh.Point_Armature_Array.Length)
                {
                    int absolute = 0;
                    for (int ix = 0; ix < PI_broken.Length; ix++)
                    {
                        int length = Int32.Parse(PI_broken[ix]);
                        new_PI[ix].JOINT  = new int[length];
                        new_PI[ix].WEIGHT = new int[length];
                        for (int iv = 0; iv < length; iv++)
                        {
                            new_PI[ix].JOINT[iv]  = Int32.Parse(Pointer_Broken[absolute]); absolute++;
                            new_PI[ix].WEIGHT[iv] = Int32.Parse(Pointer_Broken[absolute]); absolute++;

                        }
                    }
                    CurrentEditingMesh.Point_Armature_Array = new_PI;
                    Cout("Inserted Point Influence.");

                    double[] bone_pointerweights = new double[BoneWeights_broken.Length];
                    for (int ix = 0; ix < BoneWeights_broken.Length; ix++)
                    {
                        Double.TryParse(BoneWeights_broken[ix], out bone_pointerweights[ix]);
                    }
                    CurrentEditingMesh.BoneInfluenceRef = bone_pointerweights;
                    Cout("Inserted Bone Weights.");


                    RunCommand("export_object");
                }
                else
                {
                    Cout("ERROR at Override Weight Data operation: Given PI Entry has incorrect number of values!");
                    SetTab(4);
                }
            }
            catch { }
        }
        private void SetTab(int index)
        {
            if(index >= 0 && index < AnimEditTabs.TabPages.Count)
            {
                AnimEditTabs.SelectedIndex = index;
            }
        }
        private void RTB_RawDataEntry_Leave(object sender, EventArgs e)
        {
            
        }
        private void UpdateSelectedBoneAXISDISPLAY(int index, bool updateCalcs = false, bool dosave = true)
        {
            Vector3 z_heading = new Vector3(CurrentEditingMesh.Armature_Bones[index].Axis_R);
            double len = z_heading.Length();

            Vector3 y_yaw     = new Vector3(CurrentEditingMesh.Armature_Bones[index].Axis_P);
            if (y_yaw.Length() != z_heading.Length()) { y_yaw = y_yaw.SafeNormalize() * len; 
                CurrentEditingMesh.Armature_Bones[index].Axis_P = y_yaw.ToArray();
                if (PairIndex != -1)
                {
                    CurrentEditingMesh.Armature_Bones[PairIndex].Axis_P = y_yaw.ToArray();
                    CurrentEditingMesh.Armature_Bones[PairIndex].Axis_P[0] = CurrentEditingMesh.Armature_Bones[PairIndex].Axis_P[0] * -1;
                }
            }
            Vector3 x_pitch   = new Vector3(CurrentEditingMesh.Armature_Bones[index].Axis_T);
            if (x_pitch.Length() != z_heading.Length()) { x_pitch = x_pitch.SafeNormalize() * len;
                CurrentEditingMesh.Armature_Bones[index].Axis_T = x_pitch.ToArray();
                if(PairIndex != -1) { CurrentEditingMesh.Armature_Bones[PairIndex].Axis_T = x_pitch.ToArray();
                    CurrentEditingMesh.Armature_Bones[PairIndex].Axis_T[0] = CurrentEditingMesh.Armature_Bones[PairIndex].Axis_T[0] * -1;
                }
            }




            if (dosave) { SaveCurrentBone(); }

            Vector3 proper_heading = new Vector3(CurrentEditingMesh.Armature_Bones[index].Tail[0] - CurrentEditingMesh.Armature_Bones[index].Head[0],
                                                 CurrentEditingMesh.Armature_Bones[index].Tail[1] - CurrentEditingMesh.Armature_Bones[index].Head[1],
                                                 CurrentEditingMesh.Armature_Bones[index].Tail[2] - CurrentEditingMesh.Armature_Bones[index].Head[2]);


            if(updateCalcs)
            {
                bool gx, gy, gz;
                if(proper_heading.X >= proper_heading.Y && proper_heading.X >= proper_heading.Z) { gx = true; } else { gx = false; }
                if(proper_heading.Y >= proper_heading.Z && proper_heading.Y >= proper_heading.X) { gy = true; } else { gy = false; }
                if(proper_heading.Z >= proper_heading.X && proper_heading.Z >= proper_heading.Y) { gz = true; } else { gz = false; }
        


                if (COMBO_LOCKPITCHTO.SelectedIndex != 0)
                {
                    switch (COMBO_LOCKPITCHTO.SelectedIndex)
                    {
                        case 1:
                            if      (gz) { x_pitch = proper_heading.A_Perpendicular(1,    0, -500); }
                            else if (gy) { x_pitch = proper_heading.A_Perpendicular(1, -500,    0); }
                            break;
                        case 2:
                            if      (gx) { x_pitch = proper_heading.A_Perpendicular(-500, 1,    0); }
                            else if (gz) { x_pitch = proper_heading.A_Perpendicular(   0, 1, -500); }
                            break;
                        case 3:
                            if      (gx) { x_pitch = proper_heading.A_Perpendicular(-500,    0, 1); }
                            else if (gy) { x_pitch = proper_heading.A_Perpendicular(1,    -500, 1); }
                            break;
                    }
                    y_yaw = Vector3.RotateU(x_pitch, proper_heading, -Math.PI / 2);
                }
                else if(COMBO_LOCKYAWTO.SelectedIndex != 0)
                {
                    switch (COMBO_LOCKYAWTO.SelectedIndex)
                    {
                        case 1:
                            if      (gz) { y_yaw = proper_heading.A_Perpendicular(1,    0, -500); }
                            else if (gy) { y_yaw = proper_heading.A_Perpendicular(1, -500,    0); }
                            break;
                        case 2:
                            if      (gx) { y_yaw = proper_heading.A_Perpendicular(-500, 1,    0); }
                            else if (gz) { y_yaw = proper_heading.A_Perpendicular(   0, 1, -500); }
                            break;
                        case 3:
                            if      (gx) { y_yaw = proper_heading.A_Perpendicular(-500,    0, 1); }
                            else if (gy) { y_yaw = proper_heading.A_Perpendicular(1,    -500, 1); }
                            break;
                    }
                    x_pitch = Vector3.RotateU(y_yaw, proper_heading, -Math.PI / 2);
                }
                else
                {
                    // guess x and y axis
                    y_yaw = proper_heading.A_Perpendicular();
                    x_pitch = Vector3.RotateU(y_yaw, proper_heading, -Math.PI / 2);
                }

                z_heading = proper_heading;

            }
            else
            {

            }



            TXT_AXIS_HEADING_X.Text = z_heading.X.ToString();
            TXT_AXIS_HEADING_Y.Text = z_heading.Y.ToString();
            TXT_AXIS_HEADING_Z.Text = z_heading.Z.ToString();

            TXT_AXIS_YAW_X.Text = y_yaw.X.ToString();
            TXT_AXIS_YAW_Y.Text = y_yaw.Y.ToString();
            TXT_AXIS_YAW_Z.Text = y_yaw.Z.ToString();

            TXT_AXIS_PITCH_X.Text = x_pitch.X.ToString();
            TXT_AXIS_PITCH_Y.Text = x_pitch.Y.ToString();
            TXT_AXIS_PITCH_Z.Text = x_pitch.Z.ToString();

            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_R[0] = z_heading.X;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_R[1] = z_heading.Y;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_R[2] = z_heading.Z;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P[0] = y_yaw.X;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P[1] = y_yaw.Y;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P[2] = y_yaw.Z;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T[0] = x_pitch.X;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T[1] = x_pitch.Y;
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T[2] = x_pitch.Z;
        }


        private void Box_BoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isSelectingLinkParent)
            {
                CurrentBoneDetailsEdit = Box_BoneList.SelectedIndex;
            }
            else
            {
                SetParentSelector = Box_BoneList.SelectedIndex;
                TXT_ParentName.Text = CurrentEditingMesh.Armature_Bones[SetParentSelector].Name;
                CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Parent_Name = CurrentEditingMesh.Armature_Bones[SetParentSelector].Name;
                AddChildTo();
                isSelectingLinkParent = false;
                Button_ParentBone.Text = "Link Parent";
                Box_BoneList.SelectedIndex = CurrentBoneDetailsEdit;
            }
            UpdateSelectedBoneDetails();
        }
        #region base_ui
        private void Button_ExportObjectInfo_Click(object sender, EventArgs e)
        {
            RunCommand("export_object");
        }
        private void Button_SaveBone_Click(object sender, EventArgs e)
        {
            SaveCurrentBone();
        }
        private void Button_ParentBone_Click(object sender, EventArgs e)
        {
            if (!isSelectingLinkParent) { Button_ParentBone.Text = "< Select"; isSelectingLinkParent = true; }
            else { Button_ParentBone.Text = "Link Parent"; isSelectingLinkParent = false; }
        }
        private void TXT_HeadPosition_X_TextChanged(object sender, EventArgs e)
        {
            TXT_HeadPosition_X.Text = GetNumeric(TXT_HeadPosition_X.Text);
        }
        private void TXT_HeadPosition_Y_TextChanged(object sender, EventArgs e)
        {
            TXT_HeadPosition_Y.Text = GetNumeric(TXT_HeadPosition_Y.Text);
        }
        private void TXT_HeadPosition_Z_TextChanged(object sender, EventArgs e)
        {
            TXT_HeadPosition_Z.Text = GetNumeric(TXT_HeadPosition_Z.Text);
        }
        private void TXT_TailPosition_X_TextChanged(object sender, EventArgs e)
        {
            TXT_TailPosition_X.Text = GetNumeric(TXT_TailPosition_X.Text);
        }
        private void TXT_TailPosition_Y_TextChanged(object sender, EventArgs e)
        {
            TXT_TailPosition_Y.Text = GetNumeric(TXT_TailPosition_Y.Text);
        }
        private void TXT_TailPosition_Z_TextChanged(object sender, EventArgs e)
        {
            TXT_TailPosition_Z.Text = GetNumeric(TXT_TailPosition_Z.Text);
        }
        private void TXT_HeadPosition_X_Leave(object sender, EventArgs e)
        {
            SaveCurrentBone(true);
        }
        private void TXT_HeadPosition_Y_Leave(object sender, EventArgs e)
        {
            SaveCurrentBone(true);
        }
        private void TXT_HeadPosition_Z_Leave(object sender, EventArgs e)
        {
            SaveCurrentBone(true);
        }
        private void TXT_TailPosition_X_Leave(object sender, EventArgs e)
        {
            SaveCurrentBone(true);
        }
        private void TXT_TailPosition_Y_Leave(object sender, EventArgs e)
        {
            SaveCurrentBone(true);
        }
        private void TXT_TailPosition_Z_Leave(object sender, EventArgs e)
        {
            SaveCurrentBone(true);
        }
        private void SLIDER_BoneAxisPhase_Scroll(object sender, EventArgs e)
        {
            double delta = SLIDER_BoneAxisPhase.Value - (SLIDER_BoneAxisPhase.Maximum / 2);

            Vector3 axis_P = new Vector3(CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P);
            Vector3 axis_T = new Vector3(CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T);
            Vector3 axis_R = new Vector3(CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_R);

            axis_P = Vector3.RotateU(axis_P, axis_R, delta / 180 * Math.PI);
            axis_T = Vector3.RotateU(axis_T, axis_R, delta / 180 * Math.PI);

            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_P = axis_P.ToArray();
            CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].Axis_T = axis_T.ToArray();


            TXT_AXIS_YAW_X.Text = axis_P.X.ToString();
            TXT_AXIS_YAW_Y.Text = axis_P.Y.ToString();
            TXT_AXIS_YAW_Z.Text = axis_P.Z.ToString();

            TXT_AXIS_PITCH_X.Text = axis_T.X.ToString();
            TXT_AXIS_PITCH_Y.Text = axis_T.Y.ToString();
            TXT_AXIS_PITCH_Z.Text = axis_T.Z.ToString();

            if(CurrentBonePairIndex != -1)
            {
                Vector3 axis_P_mirror = new Vector3(axis_P); axis_P_mirror.X *= -1;
                Vector3 axis_T_mirror = new Vector3(axis_T); axis_T_mirror.X *= -1;
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_P = axis_P_mirror.ToArray();
                CurrentEditingMesh.Armature_Bones[CurrentBonePairIndex].Axis_T = axis_T_mirror.ToArray();
            }


            SLIDER_Center();
        }

        private void SLIDER_Center()
        {
            SLIDER_BoneAxisPhase.Scroll -= SLIDER_BoneAxisPhase_Scroll;

            SLIDER_BoneAxisPhase.Value = SLIDER_BoneAxisPhase.Maximum / 2;

            SLIDER_BoneAxisPhase.Scroll += new EventHandler(SLIDER_BoneAxisPhase_Scroll);
        }

        private void COMBO_BoneTypeCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CurrentBoneDetailsEdit != -1)
            {
                CurrentEditingMesh.Armature_Bones[CurrentBoneDetailsEdit].bone_type = (Bone_type_ident)COMBO_BoneTypeCat.SelectedIndex;
            }
        }

        private void COMBO_LOCKYAWTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetComboAxiLockPITCH();
            UpdateSelectedBoneAXISDISPLAY(CurrentBoneDetailsEdit, true);
        }

        private void COMBO_LOCKPITCHTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetComboAxiLockYAW();
            UpdateSelectedBoneAXISDISPLAY(CurrentBoneDetailsEdit, true);
        }

        private void ResetComboLock()
        {
            ResetComboAxiLockPITCH();
            ResetComboAxiLockYAW();
        }
        private void ResetComboAxiLockPITCH()
        {
            COMBO_LOCKPITCHTO.SelectedIndexChanged -= COMBO_LOCKPITCHTO_SelectedIndexChanged;
            COMBO_LOCKPITCHTO.SelectedIndex = 0;
            COMBO_LOCKPITCHTO.SelectedIndexChanged += new EventHandler(COMBO_LOCKPITCHTO_SelectedIndexChanged);
        }
        private void ResetComboAxiLockYAW()
        {
            COMBO_LOCKYAWTO.SelectedIndexChanged -= COMBO_LOCKYAWTO_SelectedIndexChanged;
            COMBO_LOCKYAWTO.SelectedIndex = 0;
            COMBO_LOCKYAWTO.SelectedIndexChanged += new EventHandler(COMBO_LOCKYAWTO_SelectedIndexChanged);
        }
        #endregion base_ui

        private void TRACK_POSE_PREVIEW_X_Scroll(object sender, EventArgs e)
        {
            // do pose action
            double delta = TRACK_POSE_PREVIEW_X.Value - (TRACK_POSE_PREVIEW_X.Maximum / 2);
            CurrentEditingPoseable.boneGroup[CurrentBoneDetailsEdit].PoseBone_RotateThet(delta / 60);
            RESET_PPREVIEWX();
        }
        private void RESET_PPREVIEWX()
        {
            TRACK_POSE_PREVIEW_X.Scroll -= TRACK_POSE_PREVIEW_X_Scroll;
            TRACK_POSE_PREVIEW_X.Value = TRACK_POSE_PREVIEW_X.Maximum / 2;
            TRACK_POSE_PREVIEW_X.Scroll += new EventHandler(TRACK_POSE_PREVIEW_X_Scroll);
        }

        private void TRACK_POSE_PREVIEW_Y_Scroll(object sender, EventArgs e)
        {
            // do pose action
            double delta = TRACK_POSE_PREVIEW_Y.Value - (TRACK_POSE_PREVIEW_Y.Maximum / 2);
            CurrentEditingPoseable.boneGroup[CurrentBoneDetailsEdit].PoseBone_RotatePhie(delta / 60);
            RESET_PPREVIEWY();
        }
        private void RESET_PPREVIEWY()
        {
            TRACK_POSE_PREVIEW_Y.Scroll -= TRACK_POSE_PREVIEW_Y_Scroll;
            TRACK_POSE_PREVIEW_Y.Value = TRACK_POSE_PREVIEW_Y.Maximum / 2;
            TRACK_POSE_PREVIEW_Y.Scroll += new EventHandler(TRACK_POSE_PREVIEW_Y_Scroll);
        }

        private void TRACK_POSE_PREVIEW_Z_Scroll(object sender, EventArgs e)
        {
            // do pose action
            double delta = TRACK_POSE_PREVIEW_Z.Value - (TRACK_POSE_PREVIEW_Z.Maximum / 2);
            CurrentEditingPoseable.boneGroup[CurrentBoneDetailsEdit].PoseBone_RotateRadi(delta / 60);
            RESET_PPREVIEWZ();
        }
        private void RESET_PPREVIEWZ()
        {
            TRACK_POSE_PREVIEW_Z.Scroll -= TRACK_POSE_PREVIEW_Z_Scroll;
            TRACK_POSE_PREVIEW_Z.Value = TRACK_POSE_PREVIEW_Z.Maximum / 2;
            TRACK_POSE_PREVIEW_Z.Scroll += new EventHandler(TRACK_POSE_PREVIEW_Z_Scroll);
        }


        public static bool ANIMW_ShowBoneWeightRender = false;
        private void CHECK_ShowWeightValues_CheckedChanged(object sender, EventArgs e)
        {
            ANIMW_ShowBoneWeightRender = CHECK_ShowWeightValues.Checked;
        }

        private int[] vcount_rawSet;
        private int[] collect;

    }
}

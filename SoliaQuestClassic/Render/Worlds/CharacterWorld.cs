using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SoliaQuestClassic.Render;
using SoliaQuestClassic.IO;
using SoliaQuestClassic.Render.UIObjectsLib;

namespace SoliaQuestClassic.Render.Worlds
{
    public class CharacterWorld : RenderWorld
    {
        public static GameLevel[] Levels = new GameLevel[0];
        public static int CharacterWorldID { get { return 3; } }
        private static int backgroundsCount = 0;

        public Kirali.Light.Camera Camera3D;

        
        // ANIMATION
        private static readonly bool DEBUG_ANIMATIONWINDOW = true;
        public static UI_PointerArrow[] armatureGuideArrows;


        public override void Init()
        {
            Camera3D = new Kirali.Light.Camera(new Kirali.MathR.Vector3(0, -1.6, 0.6), Kirali.MathR.Vector3.Zero, MainCamera.Width, MainCamera.Height);
            Camera3D.RotateThet(-Math.PI / 2);

            Texture2D.RegisterNew(ResourcePath + "World.CharacterBackgrounds.melanoct.melanoct_0.png", "melanoct_bg", this);
            backgroundsCount = 1;
            //Object3D.FromColladaResx(ResourcePath + "Creatures.qesota.default.dae", out cube);
            //ObjectJson json = cube.GetExport();
            //json.Export();

            //setup bones
            if (DEBUG_ANIMATIONWINDOW) 
            {
                armatureGuideArrows = new UI_PointerArrow[6];
                // pre-setup arrows for display :)
                
                armatureGuideArrows[0] = new UI_PointerArrow(Color.Red);
                armatureGuideArrows[1] = new UI_PointerArrow(Color.Green);
                armatureGuideArrows[2] = new UI_PointerArrow(Color.Blue);

                armatureGuideArrows[3] = new UI_PointerArrow(Color.DarkRed);
                armatureGuideArrows[4] = new UI_PointerArrow(Color.DarkGreen);
                armatureGuideArrows[5] = new UI_PointerArrow(Color.DarkBlue);

            }

        }

        private static double[] m_QuickAddArray(double[] d1, double[] d2)
        {
            double[] sum = new double[d1.Length];
            if(d1.Length == d2.Length)
            {
                for (int ix = 0; ix < d1.Length; ix++)
                {
                    sum[ix] = d1[ix] + d2[ix];
                }
            }
            return sum;
        }
        private static Kirali.MathR.Vector3 m_QuickArrToVec(double[] xyz)
        {
            if (xyz.Length == 3)
                return new Kirali.MathR.Vector3(xyz[0], xyz[1], xyz[2]);
            else return new Kirali.MathR.Vector3();
        }

        public override void Render()
        {
            SQGameWindow.PlayerTeam.Members[0].Render(Camera3D, new Kirali.MathR.Vector3(1, 4, -13).Normalize(), Kirali.Light.KColor4.WHITE);
            
            
            if (DEBUG_ANIMATIONWINDOW)
            {
                Armature_bone bone_edit = new Armature_bone();
                Armature_bone bone_pair = new Armature_bone();
                int mx = 0;
                if(AnimatorWindow.EditIndex != -1) { mx = 3; bone_edit = SQGameWindow.PlayerTeam.Members[0].CreatureModel.LinkObject.Armature_Bones[AnimatorWindow.EditIndex];}
                if(AnimatorWindow.PairIndex != -1) { mx = 6; bone_pair = SQGameWindow.PlayerTeam.Members[0].CreatureModel.LinkObject.Armature_Bones[AnimatorWindow.PairIndex]; }
                if(mx > 0)
                {
                    armatureGuideArrows[0].Modify(m_QuickArrToVec(m_QuickAddArray(bone_edit.Axis_T, bone_edit.Head)), m_QuickArrToVec(bone_edit.Head));
                    armatureGuideArrows[1].Modify(m_QuickArrToVec(m_QuickAddArray(bone_edit.Axis_P, bone_edit.Head)), m_QuickArrToVec(bone_edit.Head));
                    armatureGuideArrows[2].Modify(m_QuickArrToVec(m_QuickAddArray(bone_edit.Axis_R, bone_edit.Head)), m_QuickArrToVec(bone_edit.Head));
                    armatureGuideArrows[0].Render(Camera3D);
                    armatureGuideArrows[1].Render(Camera3D);
                    armatureGuideArrows[2].Render(Camera3D);

                }
                if(mx > 3)
                {
                    armatureGuideArrows[3].Modify(m_QuickArrToVec(m_QuickAddArray(bone_pair.Axis_T, bone_pair.Head)), m_QuickArrToVec(bone_pair.Head));
                    armatureGuideArrows[4].Modify(m_QuickArrToVec(m_QuickAddArray(bone_pair.Axis_P, bone_pair.Head)), m_QuickArrToVec(bone_pair.Head));
                    armatureGuideArrows[5].Modify(m_QuickArrToVec(m_QuickAddArray(bone_pair.Axis_R, bone_pair.Head)), m_QuickArrToVec(bone_pair.Head));
                    armatureGuideArrows[3].Render(Camera3D);
                    armatureGuideArrows[4].Render(Camera3D);
                    armatureGuideArrows[5].Render(Camera3D);
                }
            }
        }

        private double rot_cameraView = 0;
        private double rot_cameraSpeed = 0.01;
        public void Tick()
        {
            rot_cameraView += rot_cameraSpeed;
            if(rot_cameraView > Math.PI * 2) { rot_cameraView -= (2 * Math.PI); }
            Camera3D.position = Kirali.MathR.Vector3.RotateU(Camera3D.position, Kirali.MathR.Vector3.Zaxis, -rot_cameraSpeed);
            Camera3D.RotatePhi(-rot_cameraSpeed);
        }

        public static void Click(int x, int y, Camera MainCamera, OpenTK.Input.MouseButtonEventArgs args)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Security.Cryptography;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

using SoliaQuestClassic.Render;
using SoliaQuestClassic.Render.Worlds;

namespace SoliaQuestClassic
{
    public class SQGameWindow : GameWindow
    {
        public static SQGameWindow ENV_RUNNER;
        private int DEFAULT_WIDTH  = 960;
        private int DEFAULT_HEIGHT = 540;

        public static int CurrentBoundTexture = 0;

        // RENDER WORLDS
        private static int Active_RenderWorld = 2;
        public static RenderWorld debug_world;   // rw 0
        public static RenderWorld main_menu;     // rw 1
        public static PlanetWorld planet_levels; // rw 2


        public SQGameWindow(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            //executableAssembly = Assembly.GetExecutingAssembly();
            //this.Icon = 
            ENV_RUNNER = this;
            InitGlEvents();
            InitRenderWorld();
            //ResetCamera();

        }

        private void InitRenderWorld()
        {
            debug_world = new RenderWorld();
            RenderWorld.ErrorImage = new Texture2D("SoliaQuestClassic.Resources.Debug.errorImage.png", "error", debug_world);

            main_menu      = new RenderWorld(Width, Height);
            planet_levels  = new PlanetWorld();

            planet_levels.ResizeLimits(Width, Height);
            LevelEditorWindow LEV = new LevelEditorWindow();
            LEV.Show();
        }

        public static RenderWorld GetRenderWorld(int ID)
        {
            switch (ID)
            {
                case 0:
                    return debug_world;
                case 1:
                    return main_menu;
                case 2:
                    return planet_levels;
                default:
                    return debug_world;
            }
        }

        private void InitGlEvents()
        {
            KeyDown    += SQ_KeyDown;
            KeyPress   += SQ_KeyPress;
            MouseMove  += SQ_MouseMove;
            MouseWheel += SQ_MouseWheel;
            MouseDown  += SQ_MouseDown;
        }

        

        protected override void OnLoad(EventArgs e)
        {
            //currentState = GameState.LOADING;
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            //GL.ClearColor(0.2f, 0.0f, 0.2f, 1.0f);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc((BlendingFactor)BlendingFactorSrc.SrcAlpha, (BlendingFactor)BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.DepthClamp);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.Enable(EnableCap.Texture2D);

            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (Active_RenderWorld == 2)
            {
                double MoveSpeed = 0.2;

                if (input.IsKeyDown(Key.W))
                {
                    planet_levels.MainCamera.Move(MoveSpeed, new Kirali.MathR.Vector3(0, 1, 0));
                }
                if (input.IsKeyDown(Key.A))
                {
                    planet_levels.MainCamera.Move(MoveSpeed, new Kirali.MathR.Vector3(-1, 0, 0));
                }
                if (input.IsKeyDown(Key.S))
                {
                    planet_levels.MainCamera.Move(MoveSpeed, new Kirali.MathR.Vector3(0, -1, 0));
                }
                if (input.IsKeyDown(Key.D))
                {
                    planet_levels.MainCamera.Move(MoveSpeed, new Kirali.MathR.Vector3(1, 0, 0));
                }
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // ALL DRAW TO SCREEN
            switch (Active_RenderWorld)
            {
                case 0:
                    debug_world.Render();
                    break;
                case 1:
                    main_menu.Render();
                    break;
                case 2:
                    planet_levels.Render();
                    break;
                default:
                    debug_world.Render();
                    break;
            }

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        private int MousePos_X = 0;
        private int MousePos_Y = 0;

        private void SQ_MouseMove(object sender, MouseMoveEventArgs e)
        {
            MousePos_X = e.X;
            MousePos_Y = e.Y;
        }

        private void SQ_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Active_RenderWorld == 2)
            {
                PlanetWorld.Click(MousePos_X, MousePos_Y, planet_levels.MainCamera, e);
            }
        }

        private void SQ_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Active_RenderWorld == 2 && PlanetWorld.ENABLE_LEVELEDITOR)
            {
                if(planet_levels.MainCamera.zoom + e.DeltaPrecise > 7 && planet_levels.MainCamera.zoom + e.DeltaPrecise < 150) 
                {
                    planet_levels.MainCamera.zoom += e.DeltaPrecise;
                }
                
            }
        }

        private void SQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressEvent(e.KeyChar);
        }

        private void SQ_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            
        }
        public void KeyPressEvent(char key)
        {
            //MOVED TO ONUPDATEFRAME
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            double scale = 1.0;
            if (((double)Width / DEFAULT_WIDTH) > ((double)Height / DEFAULT_HEIGHT))
                scale *= ((double)Height / DEFAULT_HEIGHT);
            else scale *= ((double)Width / DEFAULT_WIDTH);
            
            base.OnResize(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            base.OnUnload(e);
        }

    }
}

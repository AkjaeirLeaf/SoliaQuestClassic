using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Drawing;


using Kirali.Light;
using Kirali.MathR;
using Kirali.Environment;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace SoliaQuestClassic.Render
{
    public partial class UIObject
    {
        public Color Tint = Color.White;

        private   Kirali.MathR.Vector2[] event_collider_bounds = new Kirali.MathR.Vector2[4]; // TL, TR, BR. BL
        protected Kirali.MathR.Vector2[] draw_object_bounds    = new Kirali.MathR.Vector2[4]; // TL, TR, BR. BL
        protected Kirali.MathR.Vector2[] event_collider_bounds_Access { get { return event_collider_bounds; }
            set
            {
                event_collider_bounds = value; rect_bounds_calc = false; geo_only = false;
            }
        }
        protected BasicUIGeometry[] geo_obj = new BasicUIGeometry[0]; private bool geo_only = true;

        private bool rect_bounds_calc = false; private bool rect_bounds;
        private bool BoundsAreRectangle
        {
            get
            {
                if (rect_bounds_calc) { return rect_bounds; }
                if(    event_collider_bounds[0].Y == event_collider_bounds[1].Y
                    && event_collider_bounds[0].X == event_collider_bounds[3].X
                    && event_collider_bounds[2].X == event_collider_bounds[1].X
                    && event_collider_bounds[2].Y == event_collider_bounds[3].Y)
                {
                    rect_bounds_calc = true;
                    rect_bounds = true;
                    return true;
                }
                else
                {
                    rect_bounds_calc = true;
                    rect_bounds = false;
                    return false;
                }
            }
        }


        protected Texture2D[] object_Textures = new Texture2D[0];
        protected bool[] doRenderLayer = new bool[0];

        protected bool canInteract = false;
        public bool UI_IsInteractive { get { return canInteract; } }

        public UIObject()
        {

        }

        public virtual void Render(Kirali.Light.Camera MainCamera)
        {
            // Render main ui (textures)



            //unbind textures.
            if (SQGameWindow.CurrentBoundTexture != 0)
            {
                SQGameWindow.CurrentBoundTexture = 0;
            }

            // Render geo objects (no textures)
            if(geo_obj.Length > 0)
            {
                for(int ix = 0; ix < geo_obj.Length; ix++)
                {
                    RenderUIGeometry(MainCamera, Tint, geo_obj[ix]);
                }
            }
        }

        public virtual bool CanInteractAt(Kirali.MathR.Vector2 position)
        {
            if (canInteract)
            {
                // is vert within bounds?
                if (BoundsAreRectangle && 
                    position.X >= event_collider_bounds_Access[0].X &&
                    position.X <= event_collider_bounds_Access[1].X &&
                    position.Y >= event_collider_bounds_Access[0].Y &&
                    position.Y <= event_collider_bounds_Access[2].Y // may need to flip these later... idk;
                    )
                {
                    return true;
                }
                else if (false)
                {
                    //todo: some math shit
                    
                }
            }
            return false;
        }

        public virtual void OnUiInteract()
        {

        }

        private static void RenderUIGeometry(Kirali.Light.Camera MainCamera, Color tint, BasicUIGeometry geometry)
        {
            if(geometry.points.Length == 4)
            {
                //DRAW
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(tint);
                GL.Vertex2(geometry.points[0].X, geometry.points[0].Y);
                GL.Vertex2(geometry.points[1].X, geometry.points[1].Y);
                GL.Vertex2(geometry.points[2].X, geometry.points[2].Y);
                GL.Vertex2(geometry.points[3].X, geometry.points[3].Y);
                GL.End();
            }
            else if (geometry.points.Length == 3)
            {
                //DRAW
                GL.Begin(PrimitiveType.Triangles);
                GL.Color4(tint);
                GL.Vertex2(geometry.points[0].X, geometry.points[0].Y);
                GL.Vertex2(geometry.points[1].X, geometry.points[1].Y);
                GL.Vertex2(geometry.points[2].X, geometry.points[2].Y);
                GL.End();
            }

        }

        public static BasicUIGeometry GetRectangle(Kirali.MathR.Vector2 Position, Kirali.MathR.Vector2 Size, UI_ScalingMode scalingMode = UI_ScalingMode.TOP_LEFT)
        {
            BasicUIGeometry geo = new BasicUIGeometry(); geo.points = new Kirali.MathR.Vector2[4];
            Kirali.MathR.Vector2 tl, br;
            double halfX = Size.X / 2;
            double halfY = Size.Y / 2;
            double posX = Position.X;
            double posY = Position.Y;
            switch (scalingMode)
            {
                case UI_ScalingMode.CENTER:
                    tl = new Kirali.MathR.Vector2(posX - halfX, posY - halfY);
                    br = new Kirali.MathR.Vector2(posX + halfX, posY + halfY);
                    break;
                case UI_ScalingMode.TOP_LEFT:
                    tl = new Kirali.MathR.Vector2(posX, posY);
                    br = new Kirali.MathR.Vector2(posX + Size.X, posY + Size.Y);
                    break;
                case UI_ScalingMode.TOP_CENTER:
                    tl = new Kirali.MathR.Vector2(posX - halfX, posY);
                    br = new Kirali.MathR.Vector2(posX + halfX, posY + Size.Y);
                    break;
                case UI_ScalingMode.TOP_RIGHT:
                    tl = new Kirali.MathR.Vector2(posX - Size.X, posY);
                    br = new Kirali.MathR.Vector2(posX, posY + Size.Y);
                    break;
                case UI_ScalingMode.RIGHT_CENTER:
                    tl = new Kirali.MathR.Vector2(posX - Size.X, posY - halfY);
                    br = new Kirali.MathR.Vector2(posX, posY + halfY);
                    break;
                case UI_ScalingMode.BOTTOM_RIGHT:
                    tl = new Kirali.MathR.Vector2(posX - Size.X, posY - Size.Y);
                    br = new Kirali.MathR.Vector2(posX + halfX, posY + halfY);
                    break;
            }
            //geo.points[0] = new Kirali.MathR.Vector2(tl);
            //geo.points[0] = new Kirali.MathR.Vector2(tl.Y, br.X);
            //geo.points[2] = new Kirali.MathR.Vector2(br);
            //geo.points[2] = new Kirali.MathR.Vector2(br.Y, tl.X);
            return geo;
        }
        public static BasicUIGeometry GetTriangle(Kirali.MathR.Vector2 Position, Kirali.MathR.Vector2 p1, Kirali.MathR.Vector2 p2, Kirali.MathR.Vector2 p3)
        {
            BasicUIGeometry b = new BasicUIGeometry();
            Kirali.MathR.Vector2[] pts = new Kirali.MathR.Vector2[3];
            pts[0] = p1 + Position;
            pts[1] = p2 + Position;
            pts[2] = p3 + Position;
            b.points = pts;
            return b;

        }

        public static BasicUIGeometry TranslateeUIGeometry(BasicUIGeometry geo, Kirali.MathR.Vector2 translation)
        {
            BasicUIGeometry b = new BasicUIGeometry(); b.points = new Kirali.MathR.Vector2[geo.points.Length];
            for (int ix = 0; ix < geo.points.Length; ix++)
            {
                b.points[ix] = new Kirali.MathR.Vector2(geo.points[ix]) + translation;
            }
            return b;
        }
        public static BasicUIGeometry ScaleUIGeometry(BasicUIGeometry geo, Kirali.MathR.Vector2 Center, Kirali.MathR.Vector2 scale)
        {
            BasicUIGeometry b = new BasicUIGeometry(); b.points = new Kirali.MathR.Vector2[geo.points.Length];
            for(int ix = 0; ix < geo.points.Length; ix++)
            {
                b.points[ix] = new Kirali.MathR.Vector2(scale.X * (geo.points[ix].X - Center.X) + Center.X, scale.Y * (geo.points[ix].Y - Center.Y) + Center.Y);
            }
            return b;
        }
        public static BasicUIGeometry RotateUIGeometry(BasicUIGeometry geo, Kirali.MathR.Vector2 Center, double radians)
        {
            BasicUIGeometry b = new BasicUIGeometry(); b.points = new Kirali.MathR.Vector2[geo.points.Length];
            for (int ix = 0; ix < geo.points.Length; ix++)
            {
                b.points[ix] = Kirali.MathR.Vector2.Rotate(new Kirali.MathR.Vector2(geo.points[ix]) - Center, radians) + Center;
            }
            return b;
        }
        public static BasicUIGeometry RotateUIGeometry(BasicUIGeometry geo, double radians)
        {
            BasicUIGeometry b = new BasicUIGeometry(); b.points = new Kirali.MathR.Vector2[geo.points.Length];
            for (int ix = 0; ix < geo.points.Length; ix++)
            {
                b.points[ix] = Kirali.MathR.Vector2.Rotate(new Kirali.MathR.Vector2(geo.points[ix]), radians);
            }
            return b;
        }
    }

    public struct BasicUIGeometry
    {
        public Kirali.MathR.Vector2[] points;
    }

    public enum UI_ScalingMode
    {
        CENTER,
        TOP_LEFT,
        TOP_RIGHT,
        BOTTOM_LEFT,
        BOTTOM_RIGHT,
        TOP_CENTER,
        RIGHT_CENTER,
        LEFT_CENTER,
        BOTTOM_CENTER
    }

    public enum UI_InteractionMethod
    {
        RIGHT_CLICK,
        LEFT_CLICK,
        MIDDLE_CLICK,
        MOUSE_SCROLL,
        MOUSE_4,
        MOUSE_5
    }
}

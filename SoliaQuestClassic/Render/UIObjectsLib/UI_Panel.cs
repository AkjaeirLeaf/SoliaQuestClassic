using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.MathR;


namespace SoliaQuestClassic.Render.UIObjectsLib
{
    public class UI_Panel : UIObject
    {
        private BasicUIGeometry main_panelbody;
        private Kirali.Light.Camera cameralink;
        private int posX, posY;
        private int sizeX, sizeY;


        public UI_Panel(Vector2 pos, Vector2 size, Color tint, UI_ScalingMode scalingMode)
        {
            Tint = tint;
            main_panelbody = UIObject.GetRectangle(pos, size, scalingMode);
            geo_obj = new BasicUIGeometry[] { main_panelbody };
            draw_object_bounds = new Vector2[]
            {
                pos, new Vector2(pos.X + size.X, pos.Y), pos + size, new Vector2(pos.X, pos.Y + size.Y)
            };
            event_collider_bounds_Access = new Vector2[]
            {
                pos, new Vector2(pos.X + size.X, pos.Y), pos + size, new Vector2(pos.X, pos.Y + size.Y)
            };
        }

        public UI_Panel(Point pos, Size size, Color tint, Kirali.Light.Camera MainCamera)
        {
            Tint = tint;
            cameralink = MainCamera;

            posX = pos.X;
            posY = pos.Y;

            sizeX = size.Width;
            sizeY = size.Height;

            RecalculatePoints(MainCamera);
        }

        public void Resize(Size newSize, Kirali.Light.Camera camera = null)
        {
            sizeX = newSize.Width;
            sizeY = newSize.Height;
            if (camera == null) { RecalculatePoints(cameralink); }
            else { RecalculatePoints(camera); }
        }
        private void RecalculatePoints(Kirali.Light.Camera camera)
        {
            Vector2 size, pos;

            pos = new Vector2(((double)posX / camera.Width) - 1, ((double)posY / camera.Height) - 1);
            size = new Vector2((double)sizeX / camera.Width * 2, (double)sizeY / camera.Height * 2);

            main_panelbody = UIObject.GetRectangle(pos, size, UI_ScalingMode.TOP_LEFT);
            geo_obj = new BasicUIGeometry[] { main_panelbody };
            draw_object_bounds = new Vector2[]
            {
                pos, new Vector2(pos.X + size.X, pos.Y), pos + size, new Vector2(pos.X, pos.Y + size.Y)
            };
            event_collider_bounds_Access = new Vector2[]
            {
                pos, new Vector2(pos.X + size.X, pos.Y), pos + size, new Vector2(pos.X, pos.Y + size.Y)
            };
        }
    }
}

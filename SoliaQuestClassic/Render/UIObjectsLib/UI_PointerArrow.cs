using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.Light;
using Kirali.MathR;
using Kirali.Environment;


namespace SoliaQuestClassic.Render.UIObjectsLib
{
    public class UI_PointerArrow : UIObject
    {
        private double heaft = 0.007;

        private Vector3 head_position = new Vector3(0, 0, 1);
        private Vector3 tail_position = new Vector3(0, 0, 0);

        public UI_PointerArrow()
        {
            Tint = Color.White;
            Init();
        }

        public UI_PointerArrow(Color arrow_color)
        {
            Tint = arrow_color;
            Init();
        }

        public UI_PointerArrow(Vector3 head, Vector3 tail, Color arrow_color)
        {
            Tint = arrow_color;
            Modify(head, tail);
            Init();
        }

        private void Init()
        {
            canInteract = false;
        }

        public override void Render(Kirali.Light.Camera MainCamera)
        {
            RecalculateObjects(MainCamera);
            base.Render(MainCamera);
        }
        public void Modify(Vector3 head, Vector3 tail)
        {
            head_position = head;
            tail_position = tail;
        }
        public void RecalculateObjects(Kirali.Light.Camera MainCamera)
        {
            Vector2 t_head = MainCamera.PointToScreen(head_position);
            Vector2 t_tail = MainCamera.PointToScreen(tail_position);

            double length_stem = Vector2.Distance(t_head, t_tail);
            Vector2 dir = (t_head - t_tail).Normalize();
            double x_disp = heaft;
            double y_disp = heaft * MainCamera.Width / MainCamera.Height;
            double rot = Math.Atan(dir.Y / dir.X); if (dir.X < 0) { rot += Math.PI; }

            // make triangle
            BasicUIGeometry tri = new BasicUIGeometry();
            tri.points = new Vector2[3];
            tri.points[0] = t_head + new Vector2(-3, -3) * heaft;
            tri.points[1] = t_head + new Vector2( 2,  3) * heaft;
            tri.points[2] = t_head + new Vector2( 2, -3) * heaft;

            tri = RotateUIGeometry(tri, t_head, rot);

            // make quad

            BasicUIGeometry bas = new BasicUIGeometry();
            bas.points = new Vector2[4];
            bas.points[0] = new Vector2(-1 * heaft, -1 * heaft);
            bas.points[1] = new Vector2( 1 * heaft + length_stem, -1 * heaft);
            bas.points[2] = new Vector2( 1 * heaft + length_stem,  1 * heaft);
            bas.points[3] = new Vector2(-1 * heaft,  1 * heaft);

            bas = RotateUIGeometry(bas, -rot);
            bas = TranslateeUIGeometry(bas, t_tail);

            // insert ui objects
            geo_obj = new BasicUIGeometry[2];
            geo_obj[0] = bas;
            geo_obj[1] = tri;

        }
    }
}

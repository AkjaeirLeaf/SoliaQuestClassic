using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.Render.UIObjectsLib
{
    public class UI_BackgroundImage : UIObject
    {
        public UI_BackgroundImage()
        {
            draw_object_bounds = new Kirali.MathR.Vector2[]
            {
                new Kirali.MathR.Vector2(-1,  1),
                new Kirali.MathR.Vector2( 1,  1),
                new Kirali.MathR.Vector2( 1, -1),
                new Kirali.MathR.Vector2(-1, -1)
            };
        }

        public void SetBackgroundImage(Texture2D texture)
        {
            object_Textures = new Texture2D[] { texture };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.MathR;

using SoliaQuestClassic.SoulForge;
using SoliaQuestClassic.SoulForge.Lang;

namespace SoliaQuestClassic.Render.UIObjectsLib
{
    public class UI_TextLabel : UIObject
    {
        private int languageIndex = 0;
        private int textSize = 12;
        private Color textColor;
        private Color[] advTextColors; private bool advColors = false;

        private Point position;

        private Kirali.Light.Camera linkCamera;

        private char[] glyCalls;
        private Glyph[] glyphslist; private bool recollectGlyphs = true;

        public UI_TextLabel(int language, int fontSize, Point pos, Color color, Kirali.Light.Camera camera)
        {
            languageIndex = language;
            textSize = fontSize;
            position = new Point(pos.X * 2, pos.Y * 2);
            textColor = color; advColors = false;
            linkCamera = camera;
        }

        public string Text
        {
            get { return glyCalls.ToString(); }
            set { glyCalls = value.ToCharArray(); Recollect(); }
        }

        private void Recollect()
        {
            if(glyCalls != null)
            {
                if(glyCalls.Length > 0)
                {
                    Language lang = SQWorld.languageList[languageIndex];
                    glyphslist = new Glyph[glyCalls.Length];
                    for (int ix = 0; ix < glyCalls.Length; ix++)
                    {
                        if (!lang.GetGlyph(glyCalls[ix], out glyphslist[ix]))
                        { Console.WriteLine("glyph failed."); }
                    }
                    recollectGlyphs = false;
                }
            }
        }

        public override void Render(Kirali.Light.Camera camera = null)
        {
            if (recollectGlyphs)
            {
                Recollect();
            }

            if (glyphslist != null)
            {
                if (glyphslist.Length > 0)
                {
                    Language lang = SQWorld.languageList[languageIndex];

                    for (int ix = 0; ix < glyCalls.Length; ix++)
                    {
                        int H_pos = textSize * ix;
                        if (camera == null)
                        {
                            lang.RenderGlyph(glyphslist[ix], textSize, new Point(position.X + H_pos, position.Y), textColor, linkCamera, !glyphslist[ix].isLowercase);
                        }
                        else
                        {
                            lang.RenderGlyph(glyphslist[ix], textSize, new Point(position.X + H_pos, position.Y), textColor, camera, !glyphslist[ix].isLowercase);
                        }
                    }
                }
            }
        }
    }
}

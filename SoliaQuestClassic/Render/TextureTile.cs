using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.MathR;

namespace SoliaQuestClassic.Render
{
    public class TextureTile
    {
        public Vector2 Top_Left      = new Vector2( 0, 1 );
        public Vector2 Top_Right     = new Vector2( 1, 1 );
        public Vector2 Bottom_Right  = new Vector2( 0, 0 );
        public Vector2 Bottom_Left   = new Vector2( 1, 0 );

        public TextureTile() { RecalcMiddle(); }

        public TextureTile(Vector2[] vecs)
        {
            Top_Left      = vecs[0];
            Top_Right     = vecs[1];
            Bottom_Right  = vecs[2];
            Bottom_Left   = vecs[3];
            RecalcMiddle();
        }

        public void Normalize(double width, double height)
        {
            Top_Left    .X *= (1.0 / width); Top_Left    .Y *= (1.0 / height);
            Top_Right   .X *= (1.0 / width); Top_Right   .Y *= (1.0 / height);
            Bottom_Right.X *= (1.0 / width); Bottom_Right.Y *= (1.0 / height);
            Bottom_Left .X *= (1.0 / width); Bottom_Left .Y *= (1.0 / height);
            RecalcMiddle();
        }

        public void Normalize(Vector2 size)
        {
            Normalize(size.X, size.Y);
        }

        public TextureTile(Vector2 v1, Vector2 v2, Vector2 v3, Vector2 v4)
        {
            Top_Left      = v1;
            Top_Right     = v2;
            Bottom_Right  = v3;
            Bottom_Left   = v4;
            RecalcMiddle();
        }

        private Vector2 middle;
        public Vector2 Middle { get { return middle; } }
        private void RecalcMiddle()
        {
            middle = Vector2.Average(new Vector2[4] { Top_Left, Top_Right, Bottom_Right, Bottom_Left });
        }


        public static TextureTile SubtileOct(TextureTile parent, int quadrant)
        {
            switch (quadrant)
            {
                case 1:
                    return new TextureTile ( 
                          parent.Top_Left,
                          Vector2.Mix(parent.Top_Left, parent.Top_Right, 0.5),
                          parent.Middle,
                          Vector2.Mix(parent.Top_Left, parent.Bottom_Left, 0.5)
                        );
                case 2:
                    return new TextureTile ( 
                          Vector2.Mix(parent.Top_Left, parent.Top_Right, 0.5),
                          parent.Top_Right,
                          Vector2.Mix(parent.Top_Right, parent.Bottom_Right, 0.5),
                          parent.Middle
                        );
                case 3:
                    return new TextureTile ( 
                          parent.Middle,
                          Vector2.Mix(parent.Top_Right, parent.Bottom_Right, 0.5),
                          parent.Bottom_Right,
                          Vector2.Mix(parent.Bottom_Right, parent.Bottom_Left, 0.5)
                        );
                case 4:
                    return new TextureTile ( 
                          Vector2.Mix(parent.Top_Left, parent.Bottom_Left, 0.5),
                          parent.Middle,
                          Vector2.Mix(parent.Bottom_Right, parent.Bottom_Left, 0.5),
                          parent.Bottom_Left
                        );
                default:
                    return parent;
            }
        }
    }
}

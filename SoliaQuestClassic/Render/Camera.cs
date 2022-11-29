using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kirali.MathR;

namespace SoliaQuestClassic.Render
{
    public class Camera
    {
        private int WIDTH  = 1920 / 2;
        private int HEIGHT = 1080 / 2;
        private double ZOOM = 12;

        public int Width  { get { return WIDTH;  } }
        public int Height { get { return HEIGHT; } }
        public void ModifyCameraDimensions(int width_new, int height_new)
        {
            WIDTH = width_new;
            HEIGHT = height_new;
        }
        public double zoom { get { return ZOOM; } set { ZOOM = value; } }

        public Vector3 position = new Vector3(Vector3.Zero);

        public Camera()
        {

        }

        public Camera(Vector3 pos)
        {
            position = pos;
        }

        public Camera(Vector3 pos, int width, int height)
        {
            position = pos;
            WIDTH = width;
            HEIGHT = height;
        }

        public void Move(double distance, Vector3 direction)
        {
            position += (new Vector3(direction).Normalize() * distance);
        }
    }
}

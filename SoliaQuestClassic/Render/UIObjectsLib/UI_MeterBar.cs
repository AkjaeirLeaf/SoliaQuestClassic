using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Kirali.MathR;

namespace SoliaQuestClassic.Render.UIObjectsLib
{
    public class UI_MeterBar : UIObject
    {
        private UI_Panel Background;
        private UI_Panel Foreground;

        private Color c_back;
        private Color c_front;

        private Point m_Position;
        private Size  m_Size;

        private Kirali.Light.Camera linkCamera;

        public UI_MeterBar(Color backColor, Color foreColor, Point pos, Size size, Kirali.Light.Camera camera)
        {
            linkCamera = camera;

            c_back = backColor;
            c_front = foreColor;

            m_Position = new Point(pos.X * 2, pos.Y * 2);
            m_Size = size;

            Background = new UI_Panel(m_Position, size,  c_back, camera);
            Foreground = new UI_Panel(m_Position, size, c_front, camera);
        }

        private double Value = 0;
        private double Min_Value = 0;
        private double Max_Value = 1;
        public void SetValue(double value)
        {
            if (value > Max_Value) { Value = Max_Value; }
            else if (value < Min_Value) { Value = Min_Value; }
            else { Value = value; }

            // Resize panel
            Foreground.Resize(new Size((int)(m_Size.Width * (Value - Min_Value) / Max_Value), m_Size.Height), linkCamera);
        }

        public override void Render(Kirali.Light.Camera MainCamera)
        {
            Background.Render(MainCamera);
            Foreground.Render(MainCamera);
        }
    }
}

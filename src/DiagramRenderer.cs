using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms; 

namespace LOI
{
    public class DiagramRenderer
    {
        private Panel renderPanel;
        private List<Rectangle> InitialCirclesList;
        private List<Rectangle> Circles;
        private List<Color> Colors;

        public DiagramRenderer(Panel renderPanel)
        {
            this.renderPanel = renderPanel;
            InitialCirclesList = new List<Rectangle>();
            Circles = new List<Rectangle> ();
            Colors = new List<Color> ();
        }

        public void SetCircles(List<Set> sets)
        {
            Circles.Clear();
            Colors.Clear();
            foreach (Set set in sets)
            {
                Circles.Add(set.RectangleData);
                Colors.Add(set.ColorData);
            }
        }
        public List<Rectangle> InitializeCircles(int circleCount)
        {
            InitialCirclesList.Clear();

            float circleRadius = 100;
            float mainRadius = 75;

            float centerX = renderPanel.Size.Width / 2;
            float centerY = renderPanel.Size.Height / 2;

            int angleStep = 360 / circleCount;

            for(int i = 0; i < circleCount; i++)
            {
                double angle = i * angleStep * Math.PI / 180;
                float x = centerX + (float)(mainRadius * Math.Cos(angle)) - circleRadius;
                float y = centerY + (float)(mainRadius * Math.Sin(angle)) - circleRadius;
                InitialCirclesList.Add(new Rectangle((int)x, (int)y, (int)circleRadius * 2, (int)circleRadius * 2));
            }
            return InitialCirclesList;
        }

        public void DrawInitialCircles()
        {
            using (Graphics graphics = renderPanel.CreateGraphics())
            {
                //graphics.Clear(renderPanel.BackColor);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Region region = new Region();

                for (int i = 1; i < Circles.Count+1; ++i)
                {
                    using (Pen pen = new Pen(Color.FromArgb(i * 58 % 255, i * 99 % 255, i * 74 % 255), 3))
                    {
                        graphics.DrawEllipse(pen, Circles[i-1]);
                    }
                }
            }
        }
        public void DrawRegion(Region region)
        {
            using (Graphics graphics = renderPanel.CreateGraphics())
            {
                graphics.Clear(renderPanel.BackColor);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brushCommon = new SolidBrush(Color.FromArgb(50, 50, 50)))
                {
                    graphics.FillRegion(brushCommon, region);
                }
            }
        }
    }
}

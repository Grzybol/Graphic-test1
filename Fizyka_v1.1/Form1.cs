using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fizyka_v1._1
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }
        Thread th;  
        Graphics g;
        Graphics fg;
        Bitmap btm;
        
        bool drawing = true;
        float massX = 1000000000;
        float massY = 1;
        float VelocityY = 10;



        private void Display_Load(object sender, EventArgs e)
        {
            btm = new Bitmap(600,600);
            g = Graphics.FromImage(btm);
            fg = CreateGraphics();
            th = new Thread(Draw);
            th.IsBackground = true;
            th.Start();
        }
        public void Draw()
        {
            float angle = 0.0f;
            PointF org = new PointF(250, 250);
            float rad = 250;
            
            RectangleF area = new RectangleF(30, 30, 500, 500);
            RectangleF circle = new RectangleF(0, 0, 50, 50);

            PointF loc = PointF.Empty;
            PointF img = new PointF(20, 20);

            fg.Clear(Color.Black);

            Pen pen = new Pen(Color.Red, 1);
            Brush brush = new SolidBrush(Color.Red);

            while (drawing)
            {
                g.Clear(Color.Black);

                //g.DrawEllipse(pen, area);
                loc = CirclePoint(rad, angle, org);


                circle.X = loc.X - (circle.Height / 2) + area.X;
                circle.Y = loc.Y - (circle.Height / 2) + area.Y;

                g.FillEllipse (brush, circle);
                fg.DrawImage(btm, img);
                if (angle < 360)
                {
                    angle += 0.5f;

                }
                else angle = 0;
                
            }

            

        }
        public PointF CirclePoint(float radius, float AngleInDegrees, PointF origin)
        {
            float x = (float)(radius * Math.Cos(AngleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(AngleInDegrees * Math.PI / 180F)) + origin.Y;

            return new PointF(x, y);
        }
    }
}




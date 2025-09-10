using System;
using ShapeDrawer;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;
        public MyLine()
        {
            _color = Color.Red;
            _endX = 0;
            _endY = 0;
        }
        public MyLine(Color color, float startX, float startY, float endX, float endY)
        {
            _color = color;
            _x = startX;
            _y = startY;
            _endX = endX;
            _endY = endY;
        }



        public override void Draw()
        {
            if (Selected == true)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(_color, _x, _y, _endX, _endY);
        }

        public override void DrawOutline()
        {
            int radius = 2; 
            SplashKit.FillCircle(Color.Black, _x, _y, radius);
            SplashKit.FillCircle(Color.Black, _endX, _endY, radius);
        }

        public override bool IsAt(Point2D pt)
        {
            bool check = SplashKit.PointInRectangle(pt.X, pt.Y, _x, _y, _endX, _endY);
            return check;
        }
    } 


    
} 

using System;
using ShapeDrawer;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle()
        {
            _color = Color.Blue;
            _radius = 40 + 26;
        }

        public MyCircle(Color color, float x, float y, int radius)
        {
            _color = color;
            _x = X;
            _y = Y;
            _radius = radius;
        }
        public override void Draw()
        {
            if (Selected == true)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(_color, _x, _y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, _x, _y, _radius+20);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt.X, pt.Y, _x, _y, _radius);
        }
    }
}
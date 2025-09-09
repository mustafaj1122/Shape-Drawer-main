using ShapeDrawer;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public MyRectangle()
        {
            _color = Color.Yellow;
            _x = 0.0f;
            _y = 0.0f;

            _width = 100 + 26;
            _height = 100 + 26;
        }


        public MyRectangle(Color color, float x, float y, int width, int height)
        {
            _color = color;
            _x = X;
            _y = Y;
            _width = width;
            _height = height;
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        

        public override void Draw()
        {
            if (Selected == true)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, _x-15, _y-15, _width+25, _height+25);
        }

        public override bool IsAt(Point2D pt)
        {
            bool check = SplashKit.PointInRectangle(pt.X, pt.Y, _x, _y, _width, _height);
            return check;
        }
    }
    

}
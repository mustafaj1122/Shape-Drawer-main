using System;
using System.Drawing;
using SplashKitSDK;
using static System.Formats.Asn1.AsnWriter;

namespace ShapeDrawer
{
    public class Program
    {

        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line,
        }
        public static void Main()
        {

            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();

            ShapeKind shapeToAdd = ShapeKind.Rectangle;


            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    shapeToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    shapeToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    shapeToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    Point2D currentPosition = SplashKit.MousePosition();
                    switch (shapeToAdd)
                    {
                        case ShapeKind.Rectangle:
                            newShape = new MyRectangle();
                            newShape.X = (float)currentPosition.X;
                            newShape.Y = (float)currentPosition.Y;
                            myDrawing.AddShape(newShape);
                            break;
                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            newShape.X = (float)currentPosition.X;
                            newShape.Y = (float)currentPosition.Y;
                            myDrawing.AddShape(newShape);
                            break;
                        case ShapeKind.Line:
                            Point2D lineStart = SplashKit.MousePosition();
                            int X = 16;
                            for (int i = 0; i < X; i++)
                            {
                                newShape = new MyLine(SplashKitSDK.Color.Red, (float)lineStart.X, (float)lineStart.Y + i * 50, (float)lineStart.X + 300, (float)lineStart.Y + i * 50);
                                myDrawing.AddShape(newShape);
                            }
                            
                            break;
                        default:
                            newShape = new MyRectangle();
                            break;
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectedShapesAt(SplashKit.MousePosition());
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        s.Draw();
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }


                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    myDrawing.SelectedShapesAt(SplashKit.MousePosition());
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.KeypadMinus))
                {
                    myDrawing.RemoveLastShape();

                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);

        }
    }
}

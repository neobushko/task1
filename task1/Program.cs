using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        abstract class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public abstract void Print();
            public abstract void Move(int x = 0, int y = 0);
            public abstract void Scaling(int factor);
            
        }

        class Rectangle : Point
        {
            private int dx, dy;
            public int deltaX
            {
                get => dx;  
                set { if (value != 0)
                        dx = value;
                }
            }
            public int deltaY
            {
                get => dy; 
                set
                {
                    if (value != 0)
                        dy = value;
                }
            }


            public Rectangle(int x, int y, int dx, int dy)
            {
                base.x = x;
                base.y = y;
                deltaX = dx;
                deltaY = dy;
            }
            public override void Move(int x = 0, int y = 0)
            {
                base.x += x;
                base.y += y;
            }

            public override void Print()
            {
                for (int i = 0; i < dy; i++)
                {
                    for (int j = 0; j < dx; j++)
                    {
                        if(i == 0 || i == dy-1 || j == 0 || j == dx-1)
                            Console.Write("*  ");
                        else Console.Write("   ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"С координатами {base.x},{base.y} && {deltaX}, {deltaY}");
            }

            public override void Scaling(int factor)
            {
                deltaX *= factor;
                deltaY *= factor;
            }
        }

        class Triangle : Rectangle
        {
            private int sdx, sdy;
            public int SeconddeltaX
            {
                get => sdx;
                set
                {
                    if (value != 0)
                        sdx = value;
                }
            }
            public int SeconddeltaY
            {
                get => sdy;
                set
                {
                    if (value != 0)
                        sdy = value;
                }
            }
            public Triangle(int x, int y, int dx, int dy, int sdx, int sdy)
                : base(x, y, dx, dy)
            {
                this.SeconddeltaX = sdx;
                this.SeconddeltaY = sdy;
            }
            public override void Print()
            {
                Console.WriteLine($"This is Triangle with coordinates {base.x},{base.y}  &&   {base.deltaX}, {base.deltaY} \n && {SeconddeltaX}, {SeconddeltaY}");

            }
            public override void Move(int x = 0, int y = 0)
            {
                base.x += x;
                base.y += y;
            }
            public override void Scaling(int factor)
            {
                base.deltaX *= factor;
                base.deltaY *= factor;
                SeconddeltaX *= factor;
                SeconddeltaY *= factor;
            }

        }

        class Circle : Point
        {
            private int rad;
            public int radius
            {
                get => rad;
                set {
                    if (value <= 0)
                        rad = 0;
                    else
                        rad = value;
                }
            }
            public Circle(int radius, int Xnumb = 0, int Ynumb = 0)
            {
                this.radius = radius;
                base.x = Xnumb;
                base.y = Ynumb;
            }

            public override void Print()
            {
                Console.WriteLine("this is circle! O");
            }

            public override void Move(int x = 0, int y = 0)
            {
                base.x += x;
                base.y += y;
            }

            public override void Scaling(int factor)
            {
                radius *= factor;
            }
        }

        class Representation : Rectangle
        {
            private List<Point> Shapes;
            public Representation(int x, int y, int dx, int dy)
                :base(x,y,dx,dy)
            {
                Shapes = new List<Point>();
            }

            public override void Print()
            {
                foreach (var shape in Shapes)
                {
                    shape.Print();
                }
            }

            public override void Move(int x = 0, int y = 0)
            {
                foreach (var shape in Shapes)
                {
                    shape.Move(x, y);
                }
            }

            public override void Scaling(int factor)
            {
                foreach (var shape in Shapes)
                {
                    shape.Scaling(factor);
                }
            }

            public void AddShape(Point shape)
            {
                Shapes.Add(shape);
            }


        }


        static void Main(string[] args)
        {
            Rectangle d = new Rectangle(0, 0, 4, 4);
            d.Print();
        }
    }
}

using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        Square square1 = new Square("red", 3);
        Rectangle rectangle1 = new Rectangle("blue", 10, 40);
        Circle circle1 = new Circle("green", 5);

        shapes.Add(square1);
        shapes.Add(rectangle1);
        shapes.Add(circle1);
        

        foreach (Shape item in shapes)
        {
            string color = item.GetColor();

            double area = item.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}
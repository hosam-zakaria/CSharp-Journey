// Problem:
// o Modify the IShape interface to include a default implementation of a method
// PrintDetails().
// o Create a class Circle that implements IShape.
// o Call PrintDetails() on an instance of Circle.
//  Question: What are the benefits of default implementations in interfaces introduced in C# 8.0?

class Program{
    public static void Main(String[] args){
        IShape circle = new Circle(50);

        circle.PrintDetails();
    }
}


interface IShape
{
    int Area { get; }

    void Draw();

    void PrintDetails()
    {
        Console.WriteLine("This is a shape");
    }
}


class Circle : IShape
{
    public int Area { get; }

    public Circle(int area)
    {
        Area = area;
    }

    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

//  Problem:
// o Define an interface IShape with:
// 1. A property Area (get-only).
// 2. A method Draw().
// o Create a class Rectangle implementing IShape with its own version of Draw() and
// Area.
// o Test the implementation.
//  Question: Why can't you create an instance of an interface directly?


class Program{
    public static void Main(String[] args){
        Rectangle r = new Rectangle(10, 5);

        Console.WriteLine(r.Area);
        r.Draw();
    }
}

interface IShape
{
    public int Area { get; }

    public void Draw(); 
}

class Rectangle : IShape
{
    public int Area { get; }

    public Rectangle(int width, int height)
    {
        Area = width * height;
    }

    public void  Draw(){
        Console.WriteLine("Drawing Rectangle");
    }
}

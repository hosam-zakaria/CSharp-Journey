// Problem:
// o Override the ToString() method in Parent to return (X, Y) and in Child to return
// (X, Y, Z).
// o Demonstrate polymorphism by printing instances of both Parent and Child.
//  Question: Why is ToString() often overridden in custom classes?

class Program{
    public static void Main(String[] args){
        Parent p1 = new Child(10, 20, 30);
        Parent p2 = new Parent(10, 20);

        Console.WriteLine(p1);
        Console.WriteLine(p2);
    }
}

class Child : Parent
{
    public int z { get; set; }


    public Child(int a, int b , int c) : base(a, b)
    {   
        this.z = c; 
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}

class Parent
{
    public int x { get; set; }
    public int y { get; set; }

    public Parent(int a, int b)
    {
        x = a;
        y = b;
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }
}

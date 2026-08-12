// Problem:
// o Define a method Product() in the Parent class to return X * Y.
// o In the Child class:
// 1. Override the Product() method using the new keyword.
// 2. Override it using the override keyword.
// o Demonstrate the difference in behavior using an instance of Child.
//  Question: How does new differ from override in method overriding?


// new → hides the Parent method; behavior depends on the reference type.
// override → overrides the Parent method; behavior depends on the actual object type (polymorphism)
class Program{
    public static void Main(String[] args){
        Parent p1 = new ChildNew(10, 20, 30);
        Console.WriteLine(p1.Product());

        Parent p2 = new ChildOverride(10, 20, 30);
        Console.WriteLine(p2.Product());
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

    public virtual int Product()
    {
        return x * y;
    }
}


class ChildNew : Parent
{
    public int z { get; set; }

    public ChildNew(int a, int b, int c) : base(a, b)
    {
        z = c;
    }

    public new int Product()
    {
        return x * y * z;
    }
}


class ChildOverride : Parent
{
    public int z { get; set; }

    public ChildOverride(int a, int b, int c) : base(a, b)
    {
        z = c;
    }

    public override int Product()
    {
        return x * y * z;
    }
}

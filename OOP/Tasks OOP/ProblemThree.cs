// Problem:
// o Create a base class Parent with properties X and Y, and a constructor to initialize them.
// o Create a derived class Child with an additional property Z, and chain its constructor to
// the base class.
// o Demonstrate constructor chaining by creating an instance of Child.
//  Question: What is the purpose of constructor chaining in inheritance?

class Parent
{
    public int x { get; set; }
    public int y { get; set; }

    public Parent(int a, int b){
        this.x = a; 
        this.y = b; 
    }
}

class Child : Parent
{
    public int z { get; set; }
    public Child(int a, int b, int c) : base(a, b)
    {   
        this.z = c; 
    }
}

class Program{
    public static void Main(String[] args){
        Child c1 = new Child(10, 20, 30);
        Console.WriteLine(c1.x);
        Console.WriteLine(c1.y);
        Console.WriteLine(c1.z);
    }
}


// Constructor Chaining : 
// Constructor chaining allows a derived class constructor to call the base class constructor to initialize inherited members.

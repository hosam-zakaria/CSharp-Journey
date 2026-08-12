// Problem:
// o Define an interface IMovable with a method Move().
// o Create a class Car implementing IMovable.
// o Use an IMovable reference to access the Car object and call Move().
//  Question: Why is it useful to use an interface reference to access implementing class methods?


class Program{
    public static void Main(String[] args){
        IMovable  c1 = new Car(); 
        c1.Move(); 
    }
}   

interface IMovable
{
    public void Move(); 
}


class Car : IMovable
{
    public void Move(){
        Console.WriteLine("Car is moving !!!"); 
    }
}

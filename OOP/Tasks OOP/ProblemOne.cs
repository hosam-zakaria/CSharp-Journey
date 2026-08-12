// Problem:
// o Define a class Car with properties Id, Brand, and Price.
// o Write multiple constructors:
// 1. Default constructor.
// 2. Constructor with one parameter (Id).
// 3. Constructor with two parameters (Id, Brand).
// 4. Constructor with all three parameters.
// o Demonstrate the constructors by creating objects.
//  Question: Why does defining a custom constructor suppress the default constructor in C#?
class Car
{
    public int Id = 0; 
    public string Brand = ""; 
    public int Price = 0; 


    public Car(){
        
    }
    public Car(int id){
        this.Id = id; 
    }
    public Car(int id, string brand){
        this.Id = id; 
        this.Brand = brand; 
    }
    public Car(int id, string brand, int price){
        this.Id = id; 
        this.Brand = brand; 
        this.Price = price; 
    }
}

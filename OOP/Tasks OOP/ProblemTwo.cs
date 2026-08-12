// Problem:
// o Write a class Calculator with overloaded Sum() methods to:
// 1. Add two integers.
// 2. Add three integers.
// 3. Add two doubles.
// o Write a program to test each overload.
//  Question: How does method overloading improve code readability and reusability?

class Calculator
{
    public void Sum(int a, int b){
        Console.WriteLine("Sum Two Integers Number = " + (a + b)); 
    }
    public void Sum(int a, int b, int c){
        Console.WriteLine("Sum Three Integers Number = " + (a + b + c)); 
    }
    public void Sum(double a, double b){
        Console.WriteLine($"Sum Two Double Number = {(a + b):F1}"); 
    }
}

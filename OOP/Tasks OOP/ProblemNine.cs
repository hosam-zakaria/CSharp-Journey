// roblem:
// o Create two interfaces, IReadable and IWritable, each with a method (Read() and
// Write()).
// o Create a class File that implements both interfaces.
// o Demonstrate using the File class.
//  Question: How does C# overcome the limitation of single inheritance with interfaces

class Program
{
    static void Main()
    {
        File file = new File();

        file.Read();
        file.Write();
    }
}

interface IReadable
{
    public void Read(); 
    
}

interface IWritable
{
    public void Write(); 
}
class File : IReadable, IWritable
{
    public void Read()
    {
        Console.WriteLine("Reading file...");
    }

    public void Write()
    {
        Console.WriteLine("Writing file...");
    }
}

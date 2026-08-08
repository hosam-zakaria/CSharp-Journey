# Lecture Three Notes 

## Relationships between classes
### 1 - Association

- **Association** is a relationship where one class **knows or uses** another class.
- It represents a general relationship between objects without implying ownership.
- The objects can **exist independently** of each other.
- It can be **one-to-one, one-to-many, or many-to-many**.

### Example

```csharp
class Teacher
{
    public Student Student { get; set; }
}

class Student
{
    public string Name { get; set; }
}

```

### 2 - Aggregation

- **Aggregation** is a `HAS-A` relationship where one class contains objects of another class.
- The contained objects can **exist independently** from the container.
- It represents **weak ownership**.
- Example: `Department HAS-A Teachers` — Teachers can exist even if the Department is deleted.

### Example

```csharp
class Room
{
    public Instructor Instructor { get; set; }

    public Room(Instructor instructor)
    {
        Instructor = instructor;
    }

    public void StartClass()
    {
        Console.WriteLine("Room is ready.");
        Instructor.TurnOnLight();
        Instructor.EnterRoom();
        Instructor.StartTeaching();
    }
}

class Instructor
{
    public string Name { get; set; }

    public void TurnOnLight()
    {
        Console.WriteLine($"{Name} turned on the light.");
    }

    public void EnterRoom()
    {
        Console.WriteLine($"{Name} entered the room.");
    }

    public void StartTeaching()
    {
        Console.WriteLine($"{Name} started teaching.");
    }
}
```
### 3 - Composition

- **Composition** is a `HAS-A` relationship with **strong ownership**.
- The main class **creates and owns** the object inside it.
- The contained object **cannot meaningfully exist independently** from the owner.
- Example: `Human HAS-A Brain` — the Brain is an essential part of the Human.

### Example

```csharp
class Human
{
    private Brain brain;

    public Human()
    {
        brain = new Brain();
    }

    public void Think()
    {
        brain.Think();
    }
}

class Brain
{
    public void Think()
    {
        Console.WriteLine("Human is thinking...");
    }
}
```

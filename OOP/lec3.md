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
## `base` with Inheritance & Constructors

- `base` refers to the **Parent (Base) Class**.
- A Child Class **inherits fields/properties/methods**, but it does **not inherit constructor parameters**.
- The parameter inside the Child Constructor is a normal parameter that can be passed to the Parent Constructor using `base(...)`.
- `base(name)` calls the Parent Constructor and passes `name` to it.

### Example

```csharp
class Animal
{
    public string Name;

    public Animal(string name)
    {
        Name = name;
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }
}
```

## summary : 
# Relationships Between Classes

| Relationship | موجودة ليه؟ | Example |
|---|---|---|
| **Association** | علشان Class **تتعامل أو تستخدم** Class تانية بدون Ownership | `Instructor → Marker` |
| **Aggregation** | علشان Class **تجمع/تحتوي** Objects، لكن الـ Objects تفضل مستقلة | `Room → Instructor` |
| **Composition** | علشان Class **تتكون من** Objects أساسية مرتبطة بيها في الـ lifetime | `Human → Brain` |
| **Inheritance** | علشان Class **تكون نوع من** Class تانية وتعيد استخدام صفاتها وسلوكها | `Dog → Animal` |
| **Dependency** | علشان Class **تستخدم** Class تانية مؤقتًا لتنفيذ عملية | `Report → Printer` |

## احفظها كجُمل

- **Association:** `I USE / KNOW YOU`
- **Aggregation:** `I HAVE YOU, BUT YOU CAN LIVE WITHOUT ME`
- **Composition:** `I HAVE YOU, AND YOU ARE PART OF ME`
- **Inheritance:** `I AM A TYPE OF YOU`
- **Dependency:** `I NEED YOU TEMPORARILY`

## أهم 3

```text
Association  → استخدام / تعامل
Aggregation  → احتواء + مستقل
Composition  → احتواء + تابع

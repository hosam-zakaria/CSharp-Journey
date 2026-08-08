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
# Polymorphism

- **Polymorphism** means **Many Forms**.
- It allows the same method/reference to work with different objects, while each object can have its own behavior.

## Types of Polymorphism

```text
Polymorphism
│
├── Compile-Time
│   ├── Method Overloading
│   └── Operator Overloading
│
└── Run-Time
    └── Method Overriding
```

## 1. Method Overloading

- Same method name with **different parameters**.
- The Compiler decides which method to call at **Compile-Time**.

### Example

```csharp
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}
```

```csharp
Calculator calc = new Calculator();

calc.Add(2, 3);
calc.Add(2, 3, 4);
```

> **Overloading = Same Name + Different Parameters**

---

## 2. Operator Overloading

- Allows us to define how an operator works with our own Objects.
- Operators like `+`, `-`, `*`, `==` can be overloaded.

### Example

```csharp
class Point
{
    public int X;
    public int Y;

    public static Point operator +(Point a, Point b)
    {
        return new Point
        {
            X = a.X + b.X,
            Y = a.Y + b.Y
        };
    }
}
```

Now:

```csharp
Point p3 = p1 + p2;
```

The `+` operator now has a meaning for `Point` objects.

> **Operator Overloading = Same Operator + Custom Behavior for Objects**

---

## 3. Method Overriding

- The Child Class provides a **different implementation** for a method inherited from the Parent.
- Parent method uses `virtual`.
- Child uses `override`.
- The decision happens at **Run-Time**.

### Example

```csharp
class Creature
{
    public virtual void Speak()
    {
        Console.WriteLine("Creature speaks");
    }
}

class Human : Creature
{
    public override void Speak()
    {
        Console.WriteLine("Human speaks");
    }
}

class Dog : Creature
{
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
```

### Runtime Polymorphism

```csharp
Creature c1 = new Human();
Creature c2 = new Dog();

c1.Speak();
c2.Speak();
```

Output:

```text
Human speaks
Dog barks
```

Here:

```text
Reference Type     Actual Object
     ↓                  ↓
 Creature            Human
 Creature            Dog
```

The Reference is `Creature`, but the actual Objects are `Human` and `Dog`.

At Runtime, C# chooses the overridden method according to the **actual Object**.

> **Overriding = Same Method + Different Implementation in Child**

---

## Upcasting

```csharp
Creature c = new Human();
```

- `Creature` → Parent Reference
- `Human` → Actual Object
- This is called **Upcasting**.

```text
Creature reference
       ↓
   Human object
```

Upcasting allows us to use a Parent reference to refer to different Child objects, which is important for Runtime Polymorphism.

---

## Why Do We Use Polymorphism?

Instead of writing separate code for every Child:

```csharp
Human h = new Human();
Dog d = new Dog();
Cat c = new Cat();
```

We can work with the common Parent type:

```csharp
List<Creature> creatures = new List<Creature>
{
    new Human(),
    new Dog(),
    new Cat()
};

foreach (Creature creature in creatures)
{
    creature.Speak();
}
```

Each Object executes its own version of `Speak()`.

```text
Creature
   |
   ├── Human → Human speaks
   ├── Dog   → Dog barks
   └── Cat   → Cat meows
```

This makes code more **flexible, reusable, and easier to extend**.

---

## Quick Summary

```text
Overloading
→ Same Method Name + Different Parameters
→ Compile-Time

Overriding
→ Same Method + Different Implementation
→ Run-Time

Operator Overloading
→ Same Operator + Custom Behavior for Objects
→ Compile-Time
```

## Golden Rule

> **Polymorphism = One common type/interface, many possible forms of behavior.**





## summary : 
# Relationships Between Classes

| Relationship | موجودة ليه؟ | Example |
|---|---|---|
| **Association** | علشان Class **تتعامل أو تستخدم** Class تانية بدون Ownership | `Instructor → Marker` |
| **Aggregation** | علشان Class **تجمع/تحتوي** Objects، لكن الـ Objects تفضل مستقلة | `Room → Instructor` |
| **Composition** | علشان Class **تتكون من** Objects أساسية مرتبطة بيها في الـ lifetime | `Human → Brain` |
| **Inheritance** | علشان Class **تكون نوع من** Class تانية وتعيد استخدام صفاتها وسلوكها | `Dog → Animal` |
| **Dependency** | علشان Class **تستخدم** Class تانية مؤقتًا لتنفيذ عملية | `Report → Printer` |

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
<img width="800" height="400" alt="c_polymorphism" src="https://github.com/user-attachments/assets/2bca9e4c-21b1-4235-a937-e705e9b89431" />

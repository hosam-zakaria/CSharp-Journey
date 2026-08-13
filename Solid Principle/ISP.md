# ISP — Interface Segregation Principle

> **Clients should not be forced to depend on methods they do not use.**

### What does it mean?

Instead of creating **one large interface** containing many unrelated methods, create **small, specific interfaces**.

Each interface should represent a specific responsibility.

---

### Example ❌

```csharp
interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}
```

Now imagine a `Robot`:

```csharp
class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot is working");
    }

    public void Eat()
    {
        // Robot doesn't eat!
    }

    public void Sleep()
    {
        // Robot doesn't sleep!
    }
}
```

The `Robot` is forced to implement methods that it doesn't need.

This violates **ISP**.

---

### Example ✅

Split the large interface into smaller interfaces:

```csharp
interface IWorkable
{
    void Work();
}

interface IEatable
{
    void Eat();
}

interface ISleepable
{
    void Sleep();
}
```

Now a human can implement all three:

```csharp
class Human : IWorkable, IEatable, ISleepable
{
    public void Work()
    {
        Console.WriteLine("Human is working");
    }

    public void Eat()
    {
        Console.WriteLine("Human is eating");
    }

    public void Sleep()
    {
        Console.WriteLine("Human is sleeping");
    }
}
```

But a robot only needs:

```csharp
class Robot : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Robot is working");
    }
}
```

Now the `Robot` is not forced to implement `Eat()` or `Sleep()`.

---

### The Main Idea

#### Before ISP ❌

```text
              IWorker
            /    |    \
         Work   Eat   Sleep
            ↑
          Robot
```

The `Robot` is forced to depend on everything.

#### After ISP ✅

```text
IWorkable     IEatable     ISleepable
    ↑             ↑             ↑
  Robot         Human         Human
```

Each class depends only on the interface it actually needs.

---

### Important ⚠️

ISP does **not** mean:

> Every interface should have only one method.

It means:

> **An interface should contain methods that belong together and are relevant to its clients.**

An interface can have multiple methods if they represent the same responsibility.

---

### Why ISP?

ISP helps us achieve:

* **Low Coupling**
* Smaller and cleaner interfaces
* Easier maintenance
* Easier testing
* Less unnecessary implementation
* More flexible code

---

### ISP vs SRP

They are related but focus on different things:

* **SRP** → Focuses on **Classes**
* **ISP** → Focuses on **Interfaces**

```text
SRP → Don't give a class multiple responsibilities.

ISP → Don't force a class to depend on methods it doesn't need.
```

---

### Quick Memory

> **ISP = Small, focused interfaces.**

Or:

> **"Don't force clients to implement what they don't need."**

### One-Line Summary

```text
❌ One Large Interface

        ↓

✅ Multiple Small, Specific Interfaces
```

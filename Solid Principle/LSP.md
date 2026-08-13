# LSP — Liskov Substitution Principle

> **Objects of a derived class should be replaceable with objects of the base class without breaking the correctness of the program.**

### What does it mean?

If `B` is a subclass of `A`, then we should be able to use `B` wherever `A` is expected **without unexpected behavior**.

In simple words:

> **A child class should be able to replace its parent without breaking the program.**

---

### Example ❌

```csharp
class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }
}

class Penguin : Bird
{
    public override void Fly()
    {
        throw new Exception("Penguins cannot fly!");
    }
}
```

Now:

```csharp
Bird bird = new Penguin();

bird.Fly();
```

The program expects every `Bird` to be able to `Fly()`, but `Penguin` cannot.

So `Penguin` is **not a proper substitute** for `Bird`.

This violates **LSP**.

---

### Example ✅

Instead of putting `Fly()` in the base class, separate the behaviors:

```csharp
class Bird
{
    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}
```

Create a separate interface:

```csharp
interface IFlyingBird
{
    void Fly();
}
```

Now:

```csharp
class Eagle : Bird, IFlyingBird
{
    public void Fly()
    {
        Console.WriteLine("Eagle is flying");
    }
}
```

And:

```csharp
class Penguin : Bird
{
}
```

Now `Penguin` doesn't have to pretend that it can fly.

---

### Another Example

Consider:

```csharp
class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
}
```

If we create:

```csharp
class Square : Rectangle
{
    public override int Width
    {
        set
        {
            // Width and Height must always be equal
        }
    }
}
```

Changing the `Width` of a `Square` may unexpectedly change its `Height`.

Code that expects a normal `Rectangle` may therefore behave incorrectly.

This is a common example of an **LSP violation**.

---

### The Main Idea

#### Before ❌

```text
Base Class
    ↓
Derived Class
    ↓
Unexpected behavior
```

The child changes the expected behavior of the parent.

#### After ✅

```text
Base Class
    ↑
Child Class
```

The child follows the **contract** of the parent.

---

### Important ⚠️

LSP is not simply:

> **"Every child must have the same methods as the parent."**

It's about **behavior**.

The derived class must respect the expectations and rules established by the base class.

---

### Important ⚠️

A subclass should not:

* Remove expected behavior.
* Throw unexpected exceptions for valid base-class operations.
* Require stricter conditions than the parent.
* Return results that violate the parent's expectations.

The child should behave like a valid version of the parent.

---

### LSP and Inheritance

Inheritance should represent a real **"is-a" relationship**.

```text
Dog is an Animal       ✅
Cat is an Animal       ✅
Penguin is a Bird      ✅
Penguin is a FlyingBird ❌
```

If the relationship doesn't make behavioral sense, inheritance may be the wrong choice.

---

### Why LSP?

LSP helps us achieve:

* **Reliable inheritance**
* **Predictable behavior**
* **Polymorphism without surprises**
* Easier maintenance
* Better design

---

### LSP vs OCP

They are closely related:

* **OCP** → We should be able to extend behavior without modifying existing code.
* **LSP** → New derived classes must behave correctly when substituted for their base class.

```text
OCP → Can I add a new child?

LSP → Can I safely use that child as the parent?
```

---

### Quick Memory

> **LSP = Child should be safely replaceable for Parent.**

Or:

> **"If it says it's a child, it should behave like the parent."**

### One-Line Summary

```text
❌ Child changes or breaks the expected behavior.

✅ Child can replace Parent without breaking the program.
```

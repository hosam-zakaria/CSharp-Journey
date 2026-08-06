# Lecture one Notes 

## 1. Procedural Programming

### Definition
Procedural Programming is a programming style where the program is divided into procedures (functions), and data is usually public and can be accessed directly.
### Characteristics
- Focuses on functions.
- Data is not protected.
- Variables can be modified directly.

### Example

```csharp
class Car
{
    public string Model;
}

Car car = new Car();

car.Model = "BMW";
Console.WriteLine(car.Model);
```
### Problem
Anyone can change the value directly.
```csharp
car.Model = "";
car.Model = null;
```
This may lead to invalid data.
---
# Get & Set (Method Style)
### Definition
Getter returns a value.

Setter updates a value.
### Example

```csharp
class Car
{
    private string model;

    public void SetModel(string value)
    {
        model = value;
    }

    public string GetModel()
    {
        return model;
    }
}
```

Usage

```csharp
Car car = new Car();

car.SetModel("BMW");

Console.WriteLine(car.GetModel());
```

### Advantages

- Can validate data.
- Protects variables.
- Better encapsulation.

---

# Get & Set (Property Style)

C# provides a shorter syntax called **Properties**.

### Example

```csharp
class Car
{
    private string model;

    public string Model
    {
        get
        {
            return model;
        }

        set
        {
            model = value;
        }
    }
}
```

Usage

```csharp
Car car = new Car();

car.Model = "BMW";

Console.WriteLine(car.Model);
```

---

# Auto-Implemented Property

If no validation is needed, C# creates the private field automatically.

```csharp
class Car
{
    public string Model { get; set; }
}
```

Usage

```csharp
Car car = new Car();

car.Model = "BMW";

Console.WriteLine(car.Model);
```

---

# Read-Only Property

The value can only be read outside the class.

```csharp
class Car
{
    public string Model { get; private set; }

    public Car()
    {
        Model = "BMW";
    }
}
```

Outside the class

```csharp
Console.WriteLine(car.Model); // ✅

car.Model = "Audi";           // ❌ Error
```

---

# Write-Only Property

Rarely used.

```csharp
class User
{
    private string password;

    public string Password
    {
        set
        {
            password = value;
        }
    }
}
```

Cannot read the value outside the class.

---

# Difference

| Procedural | Encapsulation |
|------------|---------------|
| Data is public | Data is hidden |
| Direct access | Controlled access |
| Less secure | More secure |

---

# Get Method vs Property

| Get/Set Methods | Property |
|-----------------|----------|
| GetName() | Name |
| SetName() | Name = value |
| More code | Less code |
| Similar functionality | Cleaner syntax |

---

## 2. Object

## Definition

An **Object** is an **instance** of a **Class**.

When you write:

```csharp
Car car1 = new Car();
```

The following happens:

- The **CLR** allocates memory in the **Heap**.
- It creates an instance of the **Class**.
- You now have a real object called `car1`.

So,

> **Object = A real instance of a Class stored in memory.**

---

## Physical Representation

An Object is the **runtime (physical) representation** of a Class in memory.

In other words:

- **Class** → Blueprint (Design).
- **Object** → The real implementation of that blueprint in memory.

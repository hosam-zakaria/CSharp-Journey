# Procedural Programming & Get/Set in C#

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

## 2. Encapsulation

### Definition

Encapsulation is the process of hiding data and controlling how it is accessed.

We use:

- private fields
- Getters
- Setters
- Properties

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

# Interview Notes

### Why do we use Getter and Setter?

- Protect data.
- Validate values.
- Follow Encapsulation.
- Prevent invalid data.

---

### What is the difference between a Field and a Property?

Field:
```csharp
private string model;
```

Property:
```csharp
public string Model { get; set; }
```

A Property provides controlled access to a field.

---

# Quick Review

```
Procedural
↓
Public Variables
↓
Direct Access

Encapsulation
↓
Private Fields
↓
Getter / Setter
↓
Properties
```

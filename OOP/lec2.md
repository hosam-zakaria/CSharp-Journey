# Lecture Two Notes 

## Stack
- Fast memory used to store **local variables** and **references**.
- Memory is released automatically when the method finishes.

## Heap
- Memory used to store **objects** created with `new`.
- Managed by the **Garbage Collector (GC)**.

## Value Types
- Store the **actual value**.
- Usually stored in the **Stack** (when local variables).
- Examples: `int`, `double`, `bool`, `char`, `struct`.

```csharp
int x = 10;
```

## Reference Types
- Store the **memory address (reference)** of an object.
- The **reference** is stored in the Stack, while the **object** is stored in the Heap.
- Examples: `class`, `string`, `array`, `interface`, `delegate`.

```csharp
Car car = new Car();
```

### Memory Summary

| Item | Stored In |
|------|-----------|
| Local Value Type | Stack |
| Reference Variable | Stack |
| Object (`new`) | Heap |
| Class | Blueprint (Not stored in Stack or Heap) |


## `this` Keyword

- `this` is a **reference** that points to the **current object**.
- It is used to access the current object's fields, properties, and methods.
- It helps distinguish between instance variables and method/constructor parameters with the same name.
- `this` can also be used to call another constructor in the same class (`this(...)`).

### Example

```csharp
class Person
{
    private string name;

    public Person(string name)
    {
        this.name = name;
    }

    public void Print()
    {
        Console.WriteLine(this.name);
    }
}
```

### Notes
- `this.name` → Field (instance variable).
- `name` → Constructor parameter.
- `this` always refers to the **current object**.




## Constructor

- A **Constructor** is a special method that is called **automatically** when an object is created.
- Its main purpose is to **initialize the object's data**.
- A constructor has the **same name as the class** and **does not have a return type**.
- A class can have **multiple constructors** (Constructor Overloading).

### Syntax

```csharp
class Person
{
    public Person()
    {
        Console.WriteLine("Object Created");
    }
}
```

### Constructor with Parameters

```csharp
class Person
{
    public string Name;

    public Person(string name)
    {
        Name = name;
    }
}

Person p = new Person("Hosam");
```

### Constructor Chaining

```csharp
class Person
{
    public string Name;
    public int Age;

    public Person() : this("Unknown", 0) { }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

### Key Notes
- Called automatically when using `new`.
- Used to initialize object data.
- Has the same name as the class.
- Has **no return type** (not even `void`).
- Can be overloaded with different parameters.
- Can call another constructor using `this(...)`.

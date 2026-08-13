# DIP — Dependency Inversion Principle

> **High-level modules should not depend on low-level modules. Both should depend on abstractions.**

### What does it mean?

A **High-Level Class** should not directly depend on a specific **Low-Level Class**.

Instead, both should depend on an **Abstraction** such as an Interface or Abstract Class.

```text
❌ High-Level → Low-Level

✅ High-Level → Abstraction ← Low-Level
```

---

### Example ❌

```csharp
class EmailService
{
    public void Send()
    {
        Console.WriteLine("Sending Email");
    }
}

class OrderService
{
    private EmailService emailService = new EmailService();

    public void PlaceOrder()
    {
        emailService.Send();
    }
}
```

`OrderService` is directly dependent on `EmailService`.

If we want to use `SmsService` instead, we have to modify `OrderService`.

This creates:

> **Tight Coupling**

---

### Example ✅

Create an abstraction:

```csharp
interface INotification
{
    void Send();
}
```

Then create different implementations:

```csharp
class EmailService : INotification
{
    public void Send()
    {
        Console.WriteLine("Sending Email");
    }
}

class SmsService : INotification
{
    public void Send()
    {
        Console.WriteLine("Sending SMS");
    }
}
```

Now `OrderService` depends on the abstraction:

```csharp
class OrderService
{
    private INotification notification;

    public OrderService(INotification notification)
    {
        this.notification = notification;
    }

    public void PlaceOrder()
    {
        notification.Send();
    }
}
```

Now we can use any implementation:

```csharp
OrderService order1 =
    new OrderService(new EmailService());

OrderService order2 =
    new OrderService(new SmsService());
```

`OrderService` does not care whether the notification is Email or SMS.

It only cares that it implements:

```text
INotification
```

---

### The Dependency Direction

#### Before DIP ❌

```text
OrderService
      ↓
EmailService
```

The High-Level Class depends directly on a Low-Level implementation.

#### After DIP ✅

```text
       INotification
        ↑         ↑
        |         |
EmailService   SmsService
        ↑
        |
 OrderService
```

Both the High-Level and Low-Level modules depend on the **Abstraction**.

---

### High-Level vs Low-Level

* **High-Level Module** → Contains the main business logic.

Examples:

```text
OrderService
PaymentService
UserService
```

* **Low-Level Module** → Contains implementation details.

Examples:

```text
EmailService
MySQLDatabase
FileStorage
```

---

### Important ⚠️

DIP does **not** mean:

> Every class must use an Interface.

Use abstractions when a dependency can change, has multiple implementations, or when you want to reduce coupling.

---

### Important ⚠️

**DIP ≠ Dependency Injection**

* **DIP** → A design principle.
* **Dependency Injection** → A technique used to provide dependencies from outside.

Example:

```csharp
public OrderService(INotification notification)
{
    this.notification = notification;
}
```

This is called:

> **Constructor Injection**

Constructor Injection is one way to implement **Dependency Injection**.

---

### Why DIP?

DIP helps us achieve:

* **Loose Coupling**
* Easier testing
* Easier maintenance
* Easier replacement of implementations
* More flexible code

---

### Real-Life Example

Instead of:

```text
❌ Car → BMWEngine
```

We use:

```text
✅ Car → IEngine ← BMWEngine
                     ← ToyotaEngine
                     ← ElectricEngine
```

The `Car` only knows:

> **"I need something that implements `IEngine`."**

It does not care whether it is a BMW, Toyota, or Electric engine.

---

### Quick Memory

> **DIP = Depend on Abstraction, not Implementation.**

### One-Line Summary

```text
❌ High-Level → Low-Level

✅ High-Level → Abstraction ← Low-Level
```


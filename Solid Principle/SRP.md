# SRP — Single Responsibility Principle

> **A class should have only one reason to change.**

### What does it mean?

A class should have **one responsibility** and should focus on doing **one specific job**.

### Example ❌

```csharp
class Employee
{
    public void CalculateSalary()
    {
    }

    public void SaveToDatabase()
    {
    }

    public void SendEmail()
    {
    }
}
```

This class has multiple responsibilities:

* Calculating salary
* Saving data to the database
* Sending emails

So, it has **multiple reasons to change**.

### Example ✅

Separate the responsibilities:

```csharp
class SalaryCalculator
{
    public void CalculateSalary()
    {
    }
}

class EmployeeRepository
{
    public void SaveToDatabase()
    {
    }
}

class EmailService
{
    public void SendEmail()
    {
    }
}
```

Now each class has **one clear responsibility**.

### Important ⚠️

SRP does **not** mean:

> A class should have only one method.

It means:

> **A class should have one responsibility and one reason to change.**

A class can have many methods as long as they are related to the same responsibility.

### Goal

SRP helps us achieve:

**High Cohesion + Low Coupling**

* **High Cohesion** → Everything inside the class is related to its responsibility.
* **Low Coupling** → Classes have minimal dependency on each other.

### Quick Memory

> **SRP = One Class → One Responsibility → One Reason to Change**

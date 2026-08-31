# Onion Architecture vs Clean Architecture

## Overview

**Onion Architecture** and **Clean Architecture** are very similar architectural patterns.

Both are designed to build applications that are:

* Maintainable
* Testable
* Independent from external frameworks
* Independent from infrastructure details
* Flexible and easier to change
* Built around business rules rather than technical details

The most important rule shared by both architectures is:

> **Source code dependencies should point inward, toward the core of the application.**

The main difference is **how they organize the code that follows this rule**:

* **Onion Architecture organizes the application primarily by layers.**
* **Clean Architecture organizes the application primarily around use cases.**

---

# 1. The Core Idea: Dependencies Point Inward

Both architectures follow the same dependency direction:

```text
Presentation
      ↓
Infrastructure
      ↓
Application / Services
      ↓
Domain
```

The outer layers can depend on the inner layers.

However, the inner layers should not depend on the outer layers.

For example:

```text
API → Application → Domain
Infrastructure → Domain
```

But this should not happen:

```text
Domain → Database
Domain → API
Domain → Framework
```

The core business logic should remain independent from technical implementation details.

---

## Why Is This Important?

External technologies can change.

For example:

```text
SQL Server → PostgreSQL
```

or:

```text
REST API → gRPC
```

or:

```text
ASP.NET Core → Another Framework
```

The business rules should ideally remain unchanged.

The goal is to make the core of the application independent from:

* Databases
* Frameworks
* UI technologies
* External services
* File systems
* Email providers

---

# 2. Onion Architecture

## What Is Onion Architecture?

Onion Architecture is a type of **layered architecture**.

It is visualized as a set of **concentric circles**, similar to the layers of an onion.

The application is organized around a central **Domain Model**, with other layers surrounding it.

```text
        Presentation
    ───────────────────
       Infrastructure
    ───────────────────
          Services
    ───────────────────
           Domain
```

The closer a layer is to the center, the more important it is to the core business logic.

The outer layers represent implementation details.

---

## Common Onion Architecture Layers

A common structure contains:

1. Domain Layer
2. Service Layer
3. Infrastructure Layer
4. Presentation Layer

---

# 3. Domain Layer

The **Domain Layer** is the center of the Onion.

It represents the core business concepts and rules of the application.

It does not depend on any other layer.

Common contents include:

* Business entities
* Core business rules
* Exceptions
* Repository interfaces
* Contracts
* Domain abstractions

Example:

```text
Domain
│
├── Entities
│   ├── Order
│   ├── Product
│   └── Customer
│
├── Interfaces
│   └── IOrderRepository
│
└── Exceptions
```

The Domain should not know:

* Which database is used
* Which framework is used
* How HTTP requests are handled
* Which UI exists

---

# 4. Service Layer in Onion Architecture

The Service Layer contains the application behavior.

It usually contains:

* Service interfaces
* Service implementations
* Application logic

Example:

```text
Services
│
├── IOrderService
├── OrderService
│
├── IProductService
└── ProductService
```

A service might contain multiple operations related to a particular business area.

Example:

```csharp
OrderService
{
    CreateOrder()
    CancelOrder()
    GetOrder()
    UpdateOrder()
}
```

This is an important characteristic of Onion Architecture.

New behavior is commonly added as:

> **A new method on an existing service.**

---

# 5. Infrastructure Layer

The Infrastructure Layer contains the technical implementations required by the application.

Examples include:

* Databases
* Repository implementations
* File storage
* Email services
* External APIs
* Third-party integrations

Example:

```text
Infrastructure
│
├── Persistence
│   ├── ApplicationDbContext
│   └── OrderRepository
│
├── Email
│   └── EmailService
│
└── ExternalServices
```

The Infrastructure Layer depends on abstractions defined in the inner layers.

For example:

```text
Domain

IOrderRepository
        ↑
        │ implemented by
        │
Infrastructure

OrderRepository
```

The Domain defines what it needs.

The Infrastructure Layer provides the implementation.

---

# 6. Presentation Layer

The Presentation Layer is responsible for interacting with users or external clients.

Examples include:

* Web APIs
* Controllers
* User interfaces
* HTTP endpoints

Example:

```text
Presentation
│
├── Controllers
├── Endpoints
├── Requests
└── Responses
```

This layer is responsible for:

* Receiving requests
* Calling application functionality
* Returning responses

It should not contain the core business logic.

---

# 7. Onion Architecture Dependency Direction

The dependency rule can be represented as:

```text
Presentation
      ↓
Infrastructure
      ↓
Services
      ↓
Domain
```

The Domain does not depend on:

```text
Infrastructure
Presentation
Database
Frameworks
```

The outer layers depend on the inner layers.

This keeps the core business logic protected from implementation details.

---

# 8. Onion Architecture and Hexagonal Architecture

Onion Architecture is closely related to **Hexagonal Architecture**, also known as **Ports and Adapters**.

Hexagonal Architecture surrounds the application core with:

* Ports
* Adapters

Ports are interfaces through which the application communicates with the outside world.

Adapters implement those interfaces and connect the application to external technologies.

For example:

```text
Application
      │
      │ Port / Interface
      ↓
IEmailService
      │
      │ Adapter / Implementation
      ↓
EmailService
```

A key difference is that Onion Architecture adds a stronger sense of ordered layers around the core.

---

# 9. Clean Architecture

## What Is Clean Architecture?

Clean Architecture is an architectural pattern designed to build applications that are:

* Maintainable
* Testable
* Scalable
* Independent from frameworks
* Independent from infrastructure

Like Onion Architecture, it divides the application into layers with specific responsibilities.

It also follows the rule:

> **Dependencies point inward.**

---

# 10. Common Clean Architecture Layers

A common Clean Architecture structure contains:

1. Domain
2. Application
3. Infrastructure
4. Presentation

```text
        Presentation
    ───────────────────
       Infrastructure
    ───────────────────
        Application
    ───────────────────
           Domain
```

---

# 11. Domain Layer in Clean Architecture

The Domain Layer represents:

* Core business entities
* Core business rules

It does not depend on other layers.

Example:

```text
Domain
│
├── Entities
│   ├── Order
│   ├── Product
│   └── Customer
│
└── Interfaces
```

The Domain remains at the center of the application.

---

# 12. Application Layer

The **Application Layer** is one of the main characteristics of Clean Architecture.

It contains the application's **Use Cases**.

A Use Case represents something the system can do.

Examples:

```text
CreateOrder
CancelOrder
GetOrder
UpdateOrder
```

Instead of grouping all operations inside a single service, Clean Architecture explicitly represents each operation as a separate use case.

Example:

```text
Application
│
├── CreateOrder
│   ├── CreateOrderCommand
│   └── CreateOrderHandler
│
├── CancelOrder
│   ├── CancelOrderCommand
│   └── CancelOrderHandler
│
└── GetOrder
    ├── GetOrderQuery
    └── GetOrderHandler
```

This makes the application's behavior explicit.

---

# 13. What Is a Use Case?

A Use Case answers the question:

> **What can the system do?**

Examples:

```text
User registers
User logs in
Customer creates an order
Customer cancels an order
Admin updates a product
```

Each operation can be represented by its own class or handler.

For example:

```text
CreateOrderUseCase
CancelOrderUseCase
GetOrderUseCase
```

A common approach is:

```text
One Request
      +
One Handler
      =
One Use Case
```

---

# 14. Infrastructure Layer in Clean Architecture

The Infrastructure Layer implements external services.

Examples:

* Database access
* File storage
* Email services
* External APIs

Example:

```text
Infrastructure
│
├── Persistence
│   ├── DbContext
│   └── Repositories
│
├── Email
│
└── External APIs
```

The Infrastructure Layer implements abstractions defined by the core layers.

---

# 15. Presentation Layer in Clean Architecture

The Presentation Layer handles user interaction.

Examples:

* Web API
* Controllers
* HTTP requests
* UI

Example:

```text
API
│
├── Controllers
├── Endpoints
└── Middleware
```

The Presentation Layer should focus on:

```text
Request
   ↓
Application / Use Case
   ↓
Response
```

It should not contain core business rules.

---

# 16. Clean Architecture Dependency Direction

```text
Presentation
      ↓
Infrastructure
      ↓
Application
      ↓
Domain
```

The inner layers remain independent from the outer layers.

The most important idea is:

> **Specific implementations should be replaceable without affecting the core business logic.**

---

# 17. Clean Code vs Clean Architecture

These are two different concepts.

## Clean Code

Clean Code focuses on writing readable and maintainable code.

Examples:

* Clear naming
* Small functions
* Readable classes
* Meaningful comments
* Good code structure

Clean Code is concerned with:

> **How code is written inside classes and methods.**

---

## Clean Architecture

Clean Architecture focuses on organizing dependencies between projects and layers.

It is concerned with:

> **Which parts of the application are allowed to depend on which other parts.**

Example:

```text
Clean Code
    ↓
How a method is written

Clean Architecture
    ↓
How projects and dependencies are organized
```

They are independent concepts.

You can have:

```text
Clean Architecture
+
Badly written methods
```

Or:

```text
Clean Code
+
Simple single-project application
```

---

# 18. The Main Difference Between Onion and Clean Architecture

Both architectures have the same dependency rule:

> **Dependencies point inward.**

The main difference is how they organize application behavior.

---

## Onion Architecture

Organizes primarily by:

> **Layers**

Example:

```text
Domain
Services
Infrastructure
Presentation
```

Behavior is commonly grouped inside services.

```text
OrderService
│
├── CreateOrder()
├── CancelOrder()
└── GetOrder()
```

---

## Clean Architecture

Organizes primarily by:

> **Use Cases**

Example:

```text
Application
│
├── CreateOrder
├── CancelOrder
└── GetOrder
```

Each operation is explicitly represented as its own application behavior.

---

# 19. Adding a New Feature

This is one of the easiest ways to understand the difference.

## Onion Architecture

A new feature commonly means:

```text
Existing Service
       +
New Method
```

Example:

```text
OrderService
│
├── CreateOrder()
├── CancelOrder()
└── RefundOrder() ← New Feature
```

---

## Clean Architecture

A new feature commonly means:

```text
New Use Case
```

Example:

```text
Application
│
├── CreateOrder
├── CancelOrder
└── RefundOrder ← New Feature
```

---

# 20. Dependency Inversion Principle

Both architectures rely heavily on:

> **Dependency Inversion Principle (DIP)**

The high-level business logic should not depend directly on low-level implementation details.

Instead, both should depend on abstractions.

Bad dependency:

```text
Domain
   ↓
SQL Server
```

Better:

```text
Domain
   ↓
IOrderRepository
   ↑
Infrastructure
```

The abstraction belongs closer to the core.

The implementation belongs to the outer layers.

Example:

```csharp
public interface IOrderRepository
{
    Order GetById(int id);
}
```

Infrastructure provides:

```csharp
public class SqlOrderRepository : IOrderRepository
{
}
```

This allows the implementation to change without changing the core business logic.

---

# 21. Typical Project Structure

## Onion Architecture

A typical structure may look like:

```text
MyApplication.Domain

MyApplication.Contracts

MyApplication.Services.Abstractions

MyApplication.Services

MyApplication.Persistence

MyApplication.API
```

The projects are organized around layers and services.

---

## Clean Architecture

A typical structure may look like:

```text
MyApplication.Domain

MyApplication.Application

MyApplication.Infrastructure

MyApplication.API
```

The Application project explicitly contains the use cases.

---

# 22. Onion Architecture Focus

The main focus of Onion Architecture is:

> **Clear layers and dependency direction.**

It emphasizes:

* Separation of concerns
* Domain-centered design
* Layer boundaries
* Dependency management

The structure is generally more flexible.

Different teams may organize the layers differently.

---

# 23. Clean Architecture Focus

The main focus of Clean Architecture is:

> **Explicit business behavior through use cases.**

It emphasizes:

* Business rule independence
* Use cases
* Explicit application behavior
* Clear boundaries

The structure is generally more prescriptive.

---

# 24. Structure and Flexibility

## Onion Architecture

Usually:

```text
More Flexible
More Layer-Oriented
Fewer Conventions
```

Teams can adapt the structure to their needs.

---

## Clean Architecture

Usually:

```text
More Structured
More Prescriptive
More Explicit Boundaries
```

This can help developers understand where different parts of the application belong.

However, it can reduce flexibility.

---

# 25. Number of Projects

Clean Architecture often uses:

```text
More Projects
More Classes
More Explicit Structure
```

For example:

```text
Domain
Application
Infrastructure
Presentation
```

And potentially many use case classes.

---

Onion Architecture can often use:

```text
Fewer Projects
Fewer Conventions
More Flexible Organization
```

However, the exact number of projects depends on the implementation.

---

# 26. When to Use Clean Architecture

Clean Architecture is useful when:

* Business logic is complex
* The application has many use cases
* Multiple entry points share the same behavior
* The team needs explicit architectural rules
* New developers frequently join the project
* Business behavior needs to be clearly separated

The additional structure can be valuable because the application behavior is explicitly organized.

---

## Trade-off

Clean Architecture introduces more ceremony.

For example:

```text
More Projects
+
More Classes
+
More Indirection
+
More Structure
```

This complexity should only be introduced when it provides value.

---

# 27. When to Use Onion Architecture

Onion Architecture is useful when:

* Clear layering is the priority
* The domain model is well understood
* The team wants more flexibility
* Many operations are ordinary reads and writes
* Fewer projects and conventions are preferred

It provides the same inward dependency direction while remaining lighter.

---

# 28. When Should You Avoid Both?

For a small application, both architectures may introduce unnecessary complexity.

They can add:

* Too many projects
* Too much indirection
* Too many abstractions
* Too much mapping
* Unnecessary structure

For a small application, a simpler structure may be enough:

```text
Application
│
├── Domain
├── Services
├── Infrastructure
└── API
```

The important thing is not to introduce architecture complexity without a reason.

---

# 29. Maintenance

## Clean Architecture

Clean Architecture makes it easier to organize business behavior explicitly.

Example:

```text
CreateOrder
CancelOrder
RefundOrder
```

Each behavior can be independently understood and extended.

---

## Onion Architecture

Onion Architecture provides clear separation of concerns through its layers.

This can make the overall application easier to understand and extend.

---

# 30. Team Experience

## Clean Architecture

The stricter structure can help:

* New developers
* Large teams
* Teams that require consistency

The rules make it clearer where code should go.

---

## Onion Architecture

The more flexible structure may suit:

* Experienced teams
* Teams that understand the domain
* Teams that prefer fewer conventions

---

# 31. Full Comparison

| Aspect               | Onion Architecture                    | Clean Architecture                 |
| -------------------- | ------------------------------------- | ---------------------------------- |
| Main focus           | Layers                                | Use Cases                          |
| Core                 | Domain Model                          | Domain / Entities                  |
| Organizing idea      | Concentric layers                     | Use cases around entities          |
| Application behavior | Services                              | Use Cases                          |
| New feature          | New method on a service               | New use case class                 |
| Dependency direction | Inward                                | Inward                             |
| Dependency Inversion | Yes                                   | Yes                                |
| Flexibility          | Higher                                | Lower                              |
| Structure            | Looser                                | More prescriptive                  |
| Number of projects   | Usually fewer                         | Usually more                       |
| Business behavior    | Grouped by services                   | Explicitly represented             |
| Best for             | Clear layered structure               | Complex business logic             |
| Team fit             | Experienced teams wanting flexibility | Teams needing stronger conventions |
| Complexity           | Lower                                 | Higher                             |
| Small applications   | Usually unnecessary                   | Usually unnecessary                |

---

# 32. The Most Important Concept to Remember

Both architectures share the same foundation:

```text
Outer Layers
      ↓
Inner Layers
      ↓
Domain
```

The core should not depend on implementation details.

The difference is:

```text
Onion Architecture
        ↓
Organizes primarily by Layers
```

```text
Clean Architecture
        ↓
Organizes primarily by Use Cases
```

---

# 33. Final Mental Model

## Onion Architecture

Think:

> **"How should I organize the layers around my Domain?"**

```text
Domain
   ↓
Services
   ↓
Infrastructure
   ↓
Presentation
```

The main focus is:

> **Layering and separation of concerns.**

---

## Clean Architecture

Think:

> **"What can my system do?"**

```text
Create Order
Cancel Order
Get Order
Update Order
```

Each system behavior becomes an explicit Use Case.

The main focus is:

> **Business behavior and use cases.**

---

# 34. One-Sentence Summary

> **Onion Architecture and Clean Architecture follow the same inward dependency rule; Onion primarily organizes code by layers around a domain core, while Clean Architecture primarily organizes application behavior around explicit use cases.**

---

# 35. Quick Revision

```text
Same Dependency Rule?
Yes
```

```text
Dependencies Direction?
Inward
```

```text
Onion Focus?
Layers
```

```text
Clean Focus?
Use Cases
```

```text
Onion New Feature?
New Method on Existing Service
```

```text
Clean New Feature?
New Use Case Class
```

```text
Onion Flexibility?
Higher
```

```text
Clean Structure?
Stricter
```

```text
Most Important Thing?
Protect the dependency direction.
```

> **The names of the layers can vary, but the dependency direction is the architectural rule that matters most.**

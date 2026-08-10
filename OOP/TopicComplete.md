# 🧠 C# OOP — Topics Completed

## 1. Procedural Programming

* يعني إيه Procedural Programming
* الفرق بينها وبين OOP
* فكرة الـ Functions
* إزاي البرنامج بيتبني حوالين خطوات وFunctions

---

## 2. C# Classes & Objects

* يعني إيه `class`
* يعني إيه `object`
* الـ Object كـ **instance** من الـ Class
* الفرق بين الـ Class والـ Object
* استخدام `new`
* إيه اللي بيحصل وقت الـ Runtime عند إنشاء Object
* Compile Time vs Runtime

---

## 3. Properties

* `get`
* `set`
* `private set`
* الفرق بين الـ Field والـ Property
* الـ Auto-Implemented Properties
* ليه مينفعش نكتب Assignment مباشرة داخل جسم الـ Class

---

## 4. Constructors

* يعني إيه Constructor
* Default Constructor
* Parameterized Constructor
* استخدام `this`
* Constructor Chaining
* استخدام `base`
* استدعاء Constructor من Constructor تاني

---

## 5. Memory Basics

* Stack
* Heap
* Value Types
* Reference Types
* الفرق بين Value Type و Reference Type
* علاقة الـ Objects بالـ Heap
* علاقة الـ Variables بالـ Stack والـ Heap

---

## 6. Association

* يعني إيه Association
* العلاقة بين Objects
* Object بيستخدم Object تاني
* الـ Objects ممكن يكونوا مستقلين عن بعض
* تطبيق Association باستخدام C#

---

## 7. Aggregation

* Aggregation كنوع من العلاقات بين الـ Objects
* مفهوم **Weak Ownership**
* الـ Parent بيحتوي على Objects
* الـ Child ممكن يعيش بشكل مستقل عن الـ Parent
* الفرق بين Aggregation و Association

---

## 8. Composition

* Composition كنوع من العلاقات بين الـ Objects
* مفهوم **Strong Ownership**
* الـ Parent مسؤول عن إنشاء وLifetime الـ Child
* الـ Child غالباً مينفعش يعيش بشكل مستقل عن الـ Parent
* الفرق بين Composition و Aggregation

---

## 9. Polymorphism 🔥

### يعني إيه Polymorphism؟

قدرة الـ Object أو الـ Method إنها تتعامل بأشكال مختلفة حسب الـ Context.

### Compile-Time Polymorphism

* Method Overloading
* نفس اسم الـ Method
* Parameters مختلفة
* القرار بيتم أثناء الـ Compile Time

### Runtime Polymorphism

* Method Overriding
* `virtual`
* `override`
* `base`
* الـ Parent Reference ممكن يشاور على Child Object
* تحديد الـ Method اللي هتتنفذ بيتم أثناء الـ Runtime

### Example

اشتغلنا على مثال:

```csharp
ShippingPlan
    ↓
ExpressPlan
```

والـ `ExpressPlan` عمل Override للـ `CalculateCost()`.

---

## 10. Abstraction

* يعني إيه Abstraction
* إخفاء تفاصيل الـ Implementation
* `abstract class`
* `abstract method`
* ليه مينفعش نعمل Object من `abstract class`
* الـ Abstract Class ممكن تحتوي على:

  * Abstract Methods
  * Normal Methods
  * Fields
  * Properties
  * Constructors
* الفرق بين الـ Abstract Class والـ Normal Class

---

## 11. Interface

* يعني إيه Interface
* فكرة الـ Contract
* الـ Class بتعمل `implement` للـ Interface
* استخدام `interface`
* الفرق بين Interface و Abstract Class
* إمتى نستخدم Interface
* إمتى نستخدم Abstract Class
* إمكانية تطبيق أكتر من Interface على نفس Class

---

# 📌 Current Progress

```text
Procedural Programming
        ↓
Classes & Objects
        ↓
Properties
        ↓
Constructors
        ↓
Stack & Heap
        ↓
Value & Reference Types
        ↓
Association
        ↓
Aggregation
        ↓
Composition
        ↓
Polymorphism
    ├── Overloading
    └── Overriding
        ↓
Abstraction
    ├── Abstract Class
    └── Abstract Method
        ↓
Interface
```

## ✅ Status

**C# OOP Fundamentals — Strong Foundation Built**


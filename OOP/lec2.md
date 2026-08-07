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

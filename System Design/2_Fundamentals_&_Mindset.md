# System Design — Fundamentals & Mindset

## What is System Design?

> **Defining how system components work together to meet requirements.**

* Translate **Requirements → Technical Solutions**
* Define **Data Flow**
* Choose **Technologies & Architecture**
* Anticipate **Growth, Failures & Constraints**

> Not about writing code line by line → **High-level decisions that shape the system at scale.**

---

## System Design vs Coding

* **Coding:** How does a component work internally?
* **System Design:** How do components interact?

Example:

* Coding → Implement a Queue
* System Design → Decide **When, Where & Why** to use it.

> Good Design can tolerate imperfect code.
> Poor Design can fail regardless of clean code.

---

## HLD vs LLD

### High-Level Design (HLD)

Focuses on:

* Overall Architecture
* Major Components & Interactions
* Data Flow
* Scalability & Reliability

> **What are the major parts and how do they communicate?**

### Low-Level Design (LLD)

Focuses on:

* Classes
* APIs
* Database Schemas
* Detailed Workflows
* Edge Cases

> **How exactly does each part work internally?**

### Key Point

> Stay at the right **level of abstraction** and don't jump into details too early.

---

## Common Misconceptions

### 1. System Design is only for Senior Engineers ❌

Every engineer makes System Design decisions:

* Choosing a Database
* Adding a Cache
* Adding a Background Worker

### 2. There is one "Correct" Architecture ❌

> **System Design = Trade-offs**

Every decision optimizes something while sacrificing something else.

There is usually no single correct answer → **Context matters.**

### 3. You need to memorize Architectures ❌

> **Understand WHY, don't memorize WHAT.**

Understanding the reasoning lets you design new systems instead of copying existing ones.

---

## System Designer Mindset 🧠

Always ask:

* What happens if this component fails?
* What happens if traffic increases **10x**?
* Where will bottlenecks appear?
* What assumptions am I making about usage?

> **System Design is less about perfection and more about Anticipation & Adaptability.**

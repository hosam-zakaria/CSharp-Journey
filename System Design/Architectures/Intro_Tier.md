# Tiered Architecture

## Service / System Design

**System Design** is about defining how the different components of a software system are organized and how they work together.

**Service Design** focuses on organizing the responsibilities and components within a service/application.

One way to organize a service is using a **Tiered Architecture**, where the system is divided into different tiers/layers based on responsibility.

---

## What Is a Tier?

A **Tier** represents the logical or functional distribution of components in a system.

It defines how responsibilities are **organized and separated** within an application.

> **Tier = dividing system components based on their responsibilities.**

---

## Types of Layers

### 1. Physical Layer

Responsible for the system's **hardware and infrastructure**.

Examples:

* Servers
* Databases
* Infrastructure

### 2. Logical Layer

Responsible for the **logical organization of software components**.

It provides a high-level view of the system's functionality and structure.

### 3. Data Layer

Responsible for **data management**:

* Storing data
* Retrieving data
* Processing data

Examples:

* Databases
* Data Warehouses
* Data Management Systems

### 4. UI Layer

Responsible for the **presentation and user interaction**.

Examples:

* User Interfaces
* Dashboards
* User Experience components

### 5. Other Layers

Depending on the architecture, additional layers may exist:

* Business Layer
* Application Layer
* Service Layer

---

## Key Idea

```text
Tier / Layer
     ↓
Divide the system
     ↓
Each part has a specific responsibility
```

The layers used depend on the **architecture and system requirements**.

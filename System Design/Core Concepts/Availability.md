# Availability

**Availability** is the ability of a system to remain **operational and accessible** to users, even when individual components fail.

> **Scalability** → Handle more load.
> 
> **Availability** → Stay operational during failures
> 
> **Reliability** → Produce correct results consistently

---

## Availability vs Reliability

They are related but different:

* **Availability:** Is the system up and accessible?
* **Reliability:** Does the system work correctly?

A system can be highly available but unreliable.

---

# Measuring Availability

```text
Availability = Uptime / (Uptime + Downtime)
```

Example:

```text
Uptime = 364 days
Downtime = 1 day

Availability = 364 / 365
             = 99.73%
```

---

# The Nines

Availability is commonly described using **nines**.

Each additional nine reduces the allowed downtime by roughly **10×**.

| Availability | Downtime / Year |
| ------------ | --------------: |
| 99%          |       3.65 days |
| 99.9%        |      8.76 hours |
| 99.99%       |    52.6 minutes |
| 99.999%      |    5.26 minutes |
| 99.9999%     |    31.5 seconds |

---

# Components in Series

In **series**, all components must work for the system to work.

```text
Web Server
    ↓
App Server
    ↓
Database
```

If each component has **99.9% availability**:

```text
Overall = 99.9% × 99.9% × 99.9%
        = 99.7%
```

> Adding more components in series decreases overall availability.

---

# Components in Parallel

In **parallel**, multiple components can handle the same workload.

```text
        ┌── Server 1
Request ┤
        └── Server 2
```

If one server fails, the other can continue serving requests.

For two servers with **99.9% availability**:

```text
Failure probability
= 0.1% × 0.1%
= 0.0001%

Availability
= 100% - 0.0001%
= 99.9999%
```

This is the power of **redundancy**.

> **Redundancy** = having backup components that can take over when another component fails.

---

# Common Failure Modes

## 1. Hardware Failures

Physical components can fail:

* HDD
* SSD
* Server
* Network Switch
* Power Supply

At large scale, hardware failures are **expected**, not exceptional.

---

## 2. Software Failures

Common examples:

* **Bugs** → Crashes or incorrect behavior
* **Memory Leaks** → Gradual resource exhaustion
* **Deadlocks** → Processes waiting for each other indefinitely
* **Cascading Failures** → One failure causes failures in dependent systems

---

## 3. Network Failures

* **Packet Loss** → Data does not reach its destination
* **Latency Spikes** → Communication becomes unusually slow
* **Network Partition** → Groups of servers become isolated
* **DNS Failure** → Domain names cannot be resolved

---

## 4. Human Errors

Production outages can also happen because of human mistakes:

* **Configuration Mistakes**
* **Failed Deployments**
* **Accidental Deletions**
* **Capacity Planning Errors**

Automation, testing, and operational safeguards help prevent or quickly recover from these mistakes.

---

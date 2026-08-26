# Scalability

## What is Scalability?

**Scalability** is the ability of a system to handle **increased load** by adding resources.

> A scalable system can grow to meet demand **without requiring a complete architectural overhaul**.

### Why is it Important?

As an application grows:
- More users
- More data
- More requests per second

A design that works for **1,000 users** may not work for **1,000,000 users**.

---

# Measuring Scalability

You cannot improve what you do not measure.

## Load Metrics

| Metric | Meaning | Example |
|---|---|---|
| **RPS** | Requests handled per second | 10,000 RPS |
| **Concurrent Users** | Users active at the same time | 50,000 |
| **Data Volume** | Amount of data stored/processed | 10 TB |
| **Throughput** | Data transferred per unit time | 1 GB/s |
| **Query Rate (QPS)** | Database queries per second | 50,000 QPS |
| **Message Rate** | Messages processed per second | 100,000 msg/s |

---

# Performance Under Load

A system **scales well** if it maintains acceptable performance as load increases.

| Load | Response Time | Meaning |
|---|---:|---|
| 1x | 50ms | Baseline |
| 2x | 55ms | Excellent |
| 5x | 70ms | Good |
| 10x | 150ms | Acceptable |
| 10x | 500ms | Concerning → Bottleneck |
| 10x | Timeout | Critical → Breaking point |

### Goal

Keep performance **relatively stable** as load increases.

- **Linear degradation** → predictable
- **Sublinear degradation** → even better
- **Superlinear degradation** → bottleneck forming

> If response time spikes or the system starts timing out → **Scalability Wall**

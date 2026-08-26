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


---
# Vertical Scaling (Scale Up)

**Vertical scaling** means adding more power to your existing machines.

Instead of adding more servers, you upgrade to a **bigger server**.

> **Scale Up = Make one server stronger**

### Common Actions

* **Add more CPU cores** → for compute-intensive workloads
* **Increase RAM** → to cache more data in memory
* **Use faster SSDs** → to reduce I/O bottlenecks
* **Upgrade network cards** → for higher bandwidth

### Pros

* **Simple:** No code changes required.
* **Lower latency:** Data is local, so there are no network hops.
* **No distributed complexity:** A single server means no data synchronization issues.

### Cons

* **Hardware limits:** Cannot scale beyond the largest available machine.
* **Single point of failure:** If the server goes down, everything goes down.
* **Cost:** Larger machines become disproportionately more expensive.
* **Downtime:** Moving to a bigger machine may require downtime.

### When to Use?

* **Databases** where data locality matters
* Applications with **strong consistency requirements**
* **Early-stage startups** that need simplicity
* Workloads with **predictable, moderate growth**

> Vertical scaling is still scalable. Many real-world systems use vertically scaled databases for years. The key is knowing when horizontal scaling becomes necessary.

---

# Horizontal Scaling (Scale Out)

**Horizontal scaling** means adding more machines instead of upgrading existing ones.

Instead of one powerful server, you distribute the load across **many servers**.

A **Load Balancer** distributes incoming requests across the servers.

> **Scale Out = Add more servers**

### Pros

* **No hard limit:** You can keep adding servers as needed.
* **Fault tolerance:** If one server fails, others continue serving traffic.
* **Cost-effective:** Many smaller machines can cost less than one giant machine.
* **Geographic distribution:** Servers can be placed closer to users for lower latency.

### Cons

* **Complexity:** Distributed systems are harder to build, debug, and maintain.
* **Data consistency:** Keeping data synchronized across servers is challenging.
* **Network overhead:** Communication between servers adds latency.
* **Stateless requirement:** Application servers typically need to be stateless.

---

# Stateless vs Stateful Services

For horizontal scaling to work effectively, services should be **stateless**.

## Stateful

A **stateful service** stores session data locally on a specific server.

```text
User
 ↓
Server 1
 ↓
User Session
```

If the user's next request goes to Server 2, Server 2 does not have the user's session.

> **Stateful = The server remembers the user.**

---

## Stateless

A **stateless service** does not store session data locally.

Instead, session data is stored in a **shared store** like Redis.

```text
              Redis
             ↗     ↖
User → Load Balancer
        ↙         ↘
   Server 1     Server 2
```

Now, any server can handle any request.

> **Stateless = The server does not remember the user; the shared store does.**

### Why Stateless Helps Scaling

With stateless services, the Load Balancer can freely distribute requests across servers.

With stateful services, requests may need to keep going to the same server, creating **hotspots** and making it harder to remove servers.

### How to Make Services Stateless

* Store session data in a shared cache (**Redis, Memcached**)
* Use **JWT tokens** instead of server-side sessions
* Store uploaded files in **object storage (S3)** instead of local disk
---

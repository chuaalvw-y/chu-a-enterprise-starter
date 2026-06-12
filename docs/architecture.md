# Architecture

`chu-a-enterprise-starter` is organized as a small Clean Architecture-friendly backend starter.

## Layers

| Layer | Responsibility |
| --- | --- |
| Domain | Core entities and business concepts with no dependency on ASP.NET Core, persistence, or infrastructure packages. |
| Application | Use cases, DTOs, validation, service contracts, repository contracts, and orchestration. |
| Infrastructure | Concrete adapters such as the in-memory repository and system clock. |
| API | HTTP composition root, endpoints, middleware, logging, health checks, and dependency registration. |

## Dependency Direction

```text
Api -> Application -> Domain
Api -> Infrastructure -> Application
Infrastructure -> Application -> Domain
```

The Domain layer does not know how data is stored or how HTTP requests are handled. The Application layer depends on abstractions. Infrastructure supplies adapters.

## Why This Shape

This structure keeps business behavior testable, keeps infrastructure replaceable, and lets a small application grow without rewriting its first boundaries. It is intentionally modest: enough structure to show discipline, not so much ceremony that the starter becomes difficult to understand.

## Public-Safe Scope

The sample feature uses generic project tracking concepts. It is not copied from any private application and does not represent a private business domain.

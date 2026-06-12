# ChuA Enterprise Starter

Public-safe .NET starter template for enterprise-style backend services.

This repository demonstrates how I like to start a backend application: clear boundaries, small layers, explicit contracts, validation close to the application layer, infrastructure behind interfaces, health checks, structured logging, basic automated tests, and documentation that explains the architecture.

This is a generic reference project. It does not contain private business logic, customer data, internal URLs, credentials, or proprietary implementation details.

## What It Shows

- Clean Architecture-friendly project structure
- Minimal API host with health checks and centralized error handling
- Domain model separated from application services and infrastructure
- DTOs, validation, service layer, repository abstraction, and in-memory persistence
- Unit-style and integration-style automated checks without third-party test packages
- GitHub Actions workflow for restore, build, and tests
- Architecture notes for reviewers

## Repository Structure

```text
src/
  EnterpriseStarter.Api/
  EnterpriseStarter.Application/
  EnterpriseStarter.Domain/
  EnterpriseStarter.Infrastructure/
tests/
  EnterpriseStarter.Tests/
  EnterpriseStarter.IntegrationTests/
docs/
  architecture.md
```

## Run

```powershell
dotnet run --project src\EnterpriseStarter.Api\EnterpriseStarter.Api.csproj
```

Then open:

```text
GET /health
GET /api/projects
POST /api/projects
GET /api/projects/{id}
```

Example request:

```json
{
  "name": "Reference Project",
  "description": "A public-safe example project."
}
```

## Test

```powershell
dotnet run --project tests\EnterpriseStarter.Tests\EnterpriseStarter.Tests.csproj
dotnet run --project tests\EnterpriseStarter.IntegrationTests\EnterpriseStarter.IntegrationTests.csproj
```

The test projects are small console-based test harnesses to keep this starter dependency-light and easy to run in restricted environments.

## Roadmap

- Add optional SQLite persistence variant
- Add Dockerfile and container health probe example
- Add optional OpenAPI examples
- Add template packaging notes

## License

This repository is proprietary and source-available only when shared by the copyright holder. See [LICENSE.txt](LICENSE.txt) for full license information.

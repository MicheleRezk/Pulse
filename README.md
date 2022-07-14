## Pulse API Solution

This is Api Solution with features like users management.
using a clean Onion Architecture with CQRS and MediatR.
Solution seperated in these following projects:

- Pulse.Core – contains the Domain

- Pulse.Application – contains Commands,Queries and Handlers, also contains logging and caching pipeline handlers
- Pulse.Infrastructure – contains the mocking data store for users, we can add real database to enhance the solution.
- Pulse.Api – contains users api services, regarding api versioning, I used this folder structure and this way for versioning to give us flexibility we need to add newer api versions in clean way and aslo ability to deprecate old versions.

Pulse.Api.IntegrationTests contains the basic integration tests for api services.

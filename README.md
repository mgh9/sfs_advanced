## Architecture

The SFSAdv API project is structured to follow modern software development best practices, including Clean Architecture principles and the Command Query Responsibility Segregation (CQRS) pattern. 
Below is an overview of the key components and their roles:

### Layers

1. **API Layer (Presentation)**:
   - This layer contains the ASP.NET Core Web API controllers.
   - It handles HTTP requests, interacts with the Application layer via MediatR, and returns HTTP responses.

2. **Application Layer**:
   - Contains application logic, commands, queries, and handlers.
   - Implements the CQRS pattern by separating read (query) and write (command) operations.
   - Uses MediatR to handle command and query dispatching.
   - Contains validation and some business (application) rules.

3. **Domain Layer**:
   - Contains the core business logic and domain entities.
   - Defines domain services, aggregate roots, value objects (currently we don't have any), and exceptions.
   - Implements business rules and invariants.

4. **Infrastructure Layer**:
   - Contains implementations of repository interfaces and other infrastructure-related services.
   - Handles data persistence and third-party service integrations.

### Key Components

- **CQRS (Command Query Responsibility Segregation)**:
  - Commands and Queries are handled separately to provide a clear separation between write and read operations.
  - Commands mutate the state, while Queries retrieve data.

- **MediatR**:
  - Used to decouple the dispatching of commands and queries from their handling.
  - Provides a clean and testable way to handle requests and responses.

- **Dependency Injection**:
  - Built-in support for dependency injection is used throughout the application.
  - Ensures loose coupling and easier testing.

- **Logging**:
  - Uses Microsoft.Extensions.Logging for logging application activities.
  - Provides insights and aids in troubleshooting.

- **Validation**:
  - Domain validation is implemented to enforce business rules.
  - Ensures that invalid data does not enter the system.

### Folder Structure

```
SFSAdv
├── SFSAdv.Api
│   ├── Controllers
│   └── Infrastructure
├── SFSAdv.Application
│   ├── Abstractions
│   ├── [Application Services Contain Command and Queries]
├── SFSAdv.Domain
│   ├── Abstractions
│   ├── Aggregates
│   ├── Utitilies
└── SFSAdv.Infrastructure
    ├── Persistence
    └── External Services (currently we don't have any)
```

### Flow of a Typical Request

1. **API Layer**: The controller receives an HTTP request and maps it to a command or query.
2. **Application Layer**: The command or query is dispatched via MediatR to the appropriate handler.
3. **Domain Layer**: The handler interacts with domain entities and services to perform business logic.
4. **Infrastructure Layer**: If data persistence is needed, the handler uses repository interfaces to save or retrieve data.
5. **API Layer**: The handler returns a response, which is then sent back to the client.

This architecture ensures that the application is modular, scalable, and maintainable, with a clear separation of concerns and responsibilities across different layers.

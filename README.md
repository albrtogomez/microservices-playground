<h1>Microservices Playground</h1>
  <p>
    This solution is a playground for testing and exploring different concepts and approaches in microservice pattern. It is built using [.NET 6](https://docs.microsoft.com/es-es/dotnet/core/whats-new/dotnet-6) along with other technologies. The application consist of a simplified video rental store website.
  <br />
  </p>
</div>

<!-- SETUP -->
## Deployment

* Install [Docker](https://docs.docker.com/get-docker/)
* You can run locally with docker compose. Go to the ```src``` directory and run:

```
docker compose up -d
```

<!-- MICROSERVICES -->
## Services Overview

Implemented microservices so far:

### Web App
Simple SPA application using:
- [Blazor Server](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-6.0#blazor-server)
- [Mud Blazor](https://mudblazor.com/) components

```
http://localhost:7100/
```

### Movie Catalog

Movie Catalog REST API service using:
- [ASP.NET Core Web API](https://learn.microsoft.com/es-es/aspnet/core/web-api/?view=aspnetcore-6.0)
- [Minimal APIs](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
- [MongoDb](https://www.mongodb.com/) for local storage.

```
http://localhost:7101/swagger/
```

### Shopping Cart

Shopping Cart REST API service using: 
- [ASP.NET Core Web API](https://learn.microsoft.com/es-es/aspnet/core/web-api/?view=aspnetcore-6.0)
- [Minimal APIs](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
- [RabbitMQ](https://www.rabbitmq.com/) for inter-service communication (in progress) 
- [Redis](https://redis.io/) for cache storage.

```
http://localhost:7101/swagger/
```

### Ordering

Ordering REST API service using:
- [ASP.NET Core Web API](https://learn.microsoft.com/es-es/aspnet/core/web-api/?view=aspnetcore-6.0)
- Clean Architecure design using DDD principles.
- CQRS implementation using [MediatR](https://github.com/jbogard/MediatR), [FluentValidation](https://github.com/FluentValidation/FluentValidation) and [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [RabbitMQ](https://www.rabbitmq.com/) for inter-service communication (in progress)
- [PostgreSQL](https://www.postgresql.org/) for local storage

```
http://localhost:7101/swagger/
```

<!-- ROADMAP -->
## Development Roadmap

- [ ] Asynchronous event driven communication between services using RabbitMQ
- [ ] API Gateway (BFF) service to hide hide complexity of the underlying microservices from client application
- [ ] Auth service and user management using Identity
- [ ] Unit, integration and E2E tests
- [ ] Add gRPC communication to some services
- [ ] Implement circuit braker and retry patterns for resilience improvements
- [ ] Health status website for monitoring the microservices
- [ ] Centralized log storage service

<!-- CONTACT -->
## Contact

Alberto Gómez - [@albrtogomez](https://twitter.com/albrtogomez)

Project Link: [https://github.com/albrtogomez/microservices-playground/](https://github.com/albrtogomez/microservices-playground/)

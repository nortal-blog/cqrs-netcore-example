# CQRS Example # 

This sample demonstrates CQRS style architecture with .NET Core 3.1 and excellent [MediatR](https://github.com/jbogard/MediatR) library. 

The code was prepared for Nortal's internal techie showcase on 5.6.2020. 

# Instructions # 

## Run in a Docker container

```bash
## Go to /src directory
cd src

## BUILD LOCAL DOCKER IMAGE
docker build -t cqrs-example .

# RUN YOUR IMAGE
docker run -dp 8080:80 cqrs-example

# OPEN http://localhost:8080/swagger/index.html in your browser
```

## Run in dotnet

Building and running in dotnet requires NET Core 3.1 SDK that can be downloaded from [here](https://dotnet.microsoft.com/download)


```bash
cd src/cqrs-netcore-example

dotnet run

# OPEN https://localhost:5001/swagger/index.html in your browser

```

## Background 

CQS - Command-query separation is a fundamental principle in imperative programming. It states that every method should be either a command that performs an **action** or a **query** that returns data to the caller.

>  Asking a question should not change the answer

In it's purest form command shouldn't return any value, but it may not be pragmatic in some use cases. For example, popping a stack returns an object and changes the state. Also, cases such as saving an object into the database and returning object Id violates the basic principle.

Command and Query Responsibility Segregation (CQRS) is an extension to the CQS principle, and it simply means segregating **command** and **query** operations into two different objects.

### Rationale

Typical enterprise applications are backed up with persistence storage, such as a relational database. Different persistent systems are designed to solve different challenges and using a single technology for all requirements can lead to non-optimal solutions. A typical example of the challenge is that it is usually possible to optimize for either **read** or **write** but not for both.

One way of solving the problem above is to move to a **polyglot persistence** model where an application uses multiple database technologies that are specifically designed to solve a specific problem. For example, this might mean using one database engine and data model for reads (e.g., Elasticsearch) and a relational database for writes.

CQRS fits very well into this conceptual model of polyglot persistence. Although it is considered complex and only useful in large scale systems it can give nice structural layout for smaller applications. 

### Pros and Cons

Pros
* Architectural support for distributed patterns 
* Supports adding cross-cutting concerns at later stage (e.g. audit trail, logging, retries)

Cons
* Adds additional complexity

### Related architectural patterns

* REST without PUT
* Task based UIs
* Event based architectures


### Tooling: 

* MediatR: https://github.com/jbogard/MediatR
* Java Axon Framework: https://axoniq.io/


### Useful resources: 

* [Greg Young CQRS Documents](https://cqrs.files.wordpress.com/2010/11/cqrs_documents.pdf)
* [Wikipedia article on Command–query separation](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation)
* Blog posts by Martin Fowler [CQS](https://martinfowler.com/bliki/CommandQuerySeparation.html) and 
[CQRS](https://martinfowler.com/bliki/CQRS.html)

* [Microsoft's article about CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

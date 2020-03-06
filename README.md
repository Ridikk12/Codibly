# Architecture Decision Record

POC - proof of concept 

# Interview project architecture

## Context:
1. Create a web api for sending emails. 
2. Web Service should be scalable as in future we plan to send even up to 10000 emails per day. 
3. User should have a possibility to add new mail, send it, get one by id or get all of them. 
4. Architecture should be modern and extensible.

## Decision:
1. Ports and Adapters application architecture style. Using this style gives us an extensible solution. Having in mind how many emails we want to send and fact that we can scale not only horizontal (docker) but also by adding new smpt servers or external emails providers Ports And Adapters fits that purpose the best.
2. Domain Driven Design - for Proof of concept application uses a DDD style but in my opinion for the as simple domain as we have here we should be more pragmatic.
3. I didn’t implement CQRS - too small project
4. Validation - in the normal scenario I would use FluentValidation but for POC I implemented my own version.
5. Repositories - in a normal scenario if we know that we stick to one DB type and it will not change in future we could use EF or MongoDb instead of having multiple providers. If we stick to EF instead of repository pattern we could use DBContext (Unit of Work) and DbSets (Repositories). 
6. For testing purpose - TestServer would be nice for integration tests. 
7. Logging - Log4Net or Serilog is quite nice.
8. For API Documentation we could use Swagger - we should add Produces attribute to methods
9. For sending emails - the best solution would be to delegate sending to separate background service that will fetch data from DB and send emails by selected providers (one or multiple).
10. If enough time we could add message broker and handle communication that way.
11. POC base on abstraction - I didn’t implement any concrete solution.
12. REST-style controller action routing
13. Core project could be moved to NuGet.
14. Dto/ViewModels depends on how many validations we want to have. 
15. For testing, I chose NUnit/AutoFixture and Moq
## Consequences
1. Ports and adapters are quite complex and if our solution didn’t need that kind of flexibility n-layer style would be better.
2. DDD adds extra complexity - not all dev know it so for newcomers it can be harder to adapt.

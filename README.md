# Account Owner API
    This is a basic api for managing customer account.The project is developed using C# languange and .NET 5 framework.The architecture use is Clean Code recommended by Uncle Bob. It is based on Use Case to make the code more maintanable and readable.It emphasises Single Responsibility Principle which is one of the principles of SOLID princiles.
    
### Project Structure
- Core
    - This is the layer where all business logic is applied.
    - Every use case is defined on the class library
    - The behaviour of the application is on this layer. It tells you what the project is about.
    - External Libraries installed - Ucle Bo recommendes that there should be no external depencendice on the project but I only used [Autofac](https://www.nuget.org/packages/Autofac/) a library used to register interfaces on container.This registration can also be done on the client project(Api,Mvc etc).
    - Entities defined in project:
        - Customer - An entity for storing customer information
        - Account - An entity for storing customer accounts
        - AccountType - An entity for defining types of accounts that a customer can create.This is just a lookup table which is loaded with data when the application start. It has this data SAVINGS,CHEQUE.
        - TransactionType - An entity for defining types transactions that can occur in an account.This is also a lookup table which is also loaded when the application starts. It has this data TRANSFER,WITHDRAWAL,DEPOSIT.
- Core.Tests
    - This is a projec for unit tests.The Use Cases are tested on this project.
    - There is one external dependency installed [Moq](https://www.nuget.org/packages/Moq/) which is used to registering interfaces.
- Infastructure
    - This is the data layer project where we define where are we going to store our data.
    - In this project we are using in memory data store meaning to run an application you don't need external data store.
    - .Net Core came with a library that can be used for in memory database [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/).
- Api
    - This is the client project where the users interact with to perform business work of the day.
    - According to Uncle Bob the client project has one responsibility to return information to the user after it has been processed by Core and allow user to send data back to Core. There should be no business logic on the client project.
    - This project has the following external dependencies:
       - [Autofac.Extensions.DependencyInjection](https://www.nuget.org/packages/Autofac.Extensions.DependencyInjection/) - A library for registering services from Core project.
       - [FluentValidation.AspNetCore](https://www.nuget.org/packages/FluentValidation.AspNetCore/) - A library for validating input coming from the user.This library is useful to make the code readable and has a single responsibility which is validation instead of using attribute validation on properties.
       - [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) - This librady for formating JSON data structure
       - [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) This is a very useful library for API interface.This library allows you to build test interface for API instead of installing external softwares like Postman.It also allow for documentation of your api calls.

# Project References
- Core 
    - This project does not reference any project because it a where business rules are defined.Without this project the other project will have no direction.
 - Core.Tests
    - This project references Core because we are performing unit tests of business logic before we decide where will data come from(data store).
 - Infastructure
    - This project references Core because since we defining data store on this project but we need to know what are we saving.
 - Api
   - This project references Core and Infastructure because after perfoming business rules we need to send them back to the user and we need to access then data what we stored on data store.
 
# API Test UI Review
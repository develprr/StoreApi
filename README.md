# StoreApi

## Description
This is a demo API showcasing an ASP.NET based online web store API that uses MongoDB as its database to store items.
The API's name is not BookStoreApi or PetShopApi like in typical examples. Instead, it's just boringly and simply "StoreApi".
This is because our imaginary entrepreneur hasn't figured out yet what he's going to sell in his store. 

In this initial implementation, the application only works in the localhost and provides a simple web API (without authentication)
to access a locally hosted MongoDB instance. It does not provide tools for configuring the MongoDB but assumes
that all configurations are done "manually" using Mongo CLI.

To update the API to use a cloud based MongoDB and automatically configure a Mongo DB to Cosmos DB in Azure cloud, checkout the 
follow-up branch [step-1-founding-a-food-store](https://github.com/develprr/StoreApi/blob/step-1-founding-a-food-store/README.md).

## Sources

This project was implemented by combining and applying instructions provided by exactly these three tutorials:

* [TodoApi tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&amp;tabs=visual-studio-code)
* [Bookstore API with MongoDB tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app)
* [Swagger with ASP.NET tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0)

## Instructions

Build:

```dotnet build```

Run:

```dotnet run --launch-profile https```

Swagger URL:

```
https://localhost:7097
```
![build-and-run-store-api](https://github.com/develprr/StoreApi/blob/main/Resources/build-and-run-store-api.gif)

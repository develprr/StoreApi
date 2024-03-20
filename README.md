# Food Store API

## Description
This branch contains an upgraded version of the Store API introduced in the previous branch 
[step-0-initial-implementation](https://github.com/develprr/StoreApi/tree/step-0-initial-implementation).

In this example, our imaginary entrepreneur's business idea has somewhat evolved and he has now figured out 
that he wants to be selling food in his store. Therefore he has updated the code structures related to handling "items" to handle "products" instead. 

The entrepreneur has also taken the technical implementation of the API one step forward. As the previous implementation
only worked with a locally configured MongoDB, this version contains a Bicep file allowing
to automatically create a MongoDB instance to Cosmos DB in Azure.

Please read this document further to see how to use the accompanied Bicep file to configure your food store database in Azure.

## Sources
This project was implemented by combining and applying instructions provided by the following tutorials:

* [TodoApi tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&amp;tabs=visual-studio-code)
* [Bookstore API with MongoDB tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app)
* [Swagger with ASP.NET tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0)
* [Quickstart: Azure Cosmos DB for MongoDB for .NET with the MongoDB driver](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/quickstart-dotnet?tabs=azure-cli%2Cwindows)
* [Quickstart: Create an Azure Cosmos DB and a container using Bicep](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/quickstart-template-bicep?tabs=CLI)
* [Quickstart: Create an Azure Cosmos DB for MongoDB vCore cluster by using a Bicep template](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/vcore/quickstart-bicep?tabs=azure-cli)
* [Manage Azure Cosmos DB for MongoDB resources using Bicep](https://learn.microsoft.com/en-us/azure/cosmos-db/mongodb/manage-with-bicep#api-for-mongodb-with-autoscale-provisioned-throughput)
* [Generate Bicep parameter file](https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/bicep-cli#generate-params)
* [How to list Azure resources](https://learn.microsoft.com/en-us/cli/azure/group?view=azure-cli-latest#az-group-list)

## Prerequisites
* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/en-us/free/)
* Azure command line interface. [Install Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
* .NET 8.0 [Install .NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Linux operating system (either a native Linux or a Linux subsystem in WSL2 on Windows)

## Instructions
### Create a resource group
First, create resource group in Azure to serve as the basement for your MongoDb in Cosmos DB:

```
az group create \
    --name foodStoreRG \
    --location eastus
```

### Verify the resource group
To be sure that you successfully created a resource group, type:
```
az group list
```
The group that you created should be listed now in the output.

### Create a MongoDB in Cosmos DB
Then, create a MongoDB instance in Cosmos DB with some collections, "products" and "customers":

```
az deployment group create --resource-group foodStoreRG --template-file 'main.bicep' --parameters main.parameters.json
```

### Find and update MongoDB connection string
To connect to MongoDB API, you need to find the connection string for the database that you just created.
List available connection strings for your database:
```
 az cosmosdb keys list --type connection-strings \
      --resource-group foodStoreRG \
      --name food-store-2024-03-20
```

Then, take the primary connection string (the first one on the list) and
update connectionString variable accordingly in your appsettings.json file. 

```
export COSMOS_CONNECTION_STRING="<your-connection-string-here>"
```

### Build and run the API

Build:

```dotnet build```

Run:

```dotnet run --launch-profile https```

Swagger URL:

```
https://localhost:7097
```

### Clean up
To remove the resource grup from Azure (and your MongoDB within):
```
az group delete --name foodStoreRG
```



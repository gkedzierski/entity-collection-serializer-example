# Entity Collection Serializer Example

Example source code for the blog post "Enum collection serialization in .NET Core and Entity Framework Core" (https://gregkedzierski.com/essays/enum-collection-serialization-in-dotnet-core-and-entity-framework-core/)

## Running an example

1. Add your SQLServer details to `appsettings.Development.json`.

2. Run the following from the command line:

```shell
dotnet restore
dotnet ef database update
dotnet run
```

The following endpoint will open in the browser: https://localhost:5001/users

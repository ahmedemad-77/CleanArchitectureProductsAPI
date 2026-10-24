# CleanArchitectureProductsAPI

Run from this folder (needs .NET 10 SDK and SQL Server / LocalDB):

    dotnet restore
    dotnet tool install --global dotnet-ef
    dotnet ef migrations add InitialCreate --project CleanArchitectureProductsAPI.Infrastructure --startup-project CleanArchitectureProductsAPI.API --output-dir Persistence/Migrations
    dotnet ef database update --project CleanArchitectureProductsAPI.Infrastructure --startup-project CleanArchitectureProductsAPI.API
    dotnet run --project CleanArchitectureProductsAPI.API --launch-profile https

Then open https://localhost:7080/swagger

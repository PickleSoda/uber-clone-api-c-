dotnet new sln -n UberClone
cd UberClone

# Create Core project
dotnet new classlib -n UberClone.Core
dotnet add UberClone.Core package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet sln add UberClone.Core/UberClone.Core.csproj

# Create Application project
dotnet new classlib -n UberClone.Application
dotnet add UberClone.Application package MediatR
dotnet add UberClone.Application package AutoMapper
dotnet sln add UberClone.Application/UberClone.Application.csproj

# Create Infrastructure project
dotnet new classlib -n UberClone.Infrastructure
dotnet add UberClone.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add UberClone.Infrastructure package Microsoft.Extensions.Configuration
dotnet add UberClone.Infrastructure package Microsoft.Extensions.DependencyInjection
dotnet sln add UberClone.Infrastructure/UberClone.Infrastructure.csproj

# Create WebUI project
dotnet new webapi -n UberClone.WebUI
dotnet add UberClone.WebUI package Swashbuckle.AspNetCore
dotnet sln add UberClone.WebUI/UberClone.WebUI.csproj

# Add project references
dotnet add UberClone.Application reference UberClone.Core
dotnet add UberClone.Infrastructure reference UberClone.Core
dotnet add UberClone.WebUI reference UberClone.Application
dotnet add UberClone.WebUI reference UberClone.Infrastructure

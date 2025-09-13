# =========================
# Stage 1: Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ProductServiceApp.sln ./
COPY ProductService.Domain/ProductService.Domain.csproj ProductService.Domain/
COPY ProductService.Application/ProductService.Application.csproj ProductService.Application/
COPY ProductService.Infrastructure/ProductService.Infrastructure.csproj ProductService.Infrastructure/
COPY ProductService.Api/ProductService.Api.csproj ProductService.Api/

# Restore dependencies (caches layers)
RUN dotnet restore ProductService.Api/ProductService.Api.csproj

# Copy all source code
COPY ProductService.Domain/ ProductService.Domain/
COPY ProductService.Application/ ProductService.Application/
COPY ProductService.Infrastructure/ ProductService.Infrastructure/
COPY ProductService.Api/ ProductService.Api/

# Build projects
WORKDIR /src/ProductService.Api
RUN dotnet build -c Release -o /app/build

# =========================
# Stage 2: Publish
# =========================
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# =========================
# Stage 3: Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published files from build
COPY --from=publish /app/publish .

# Expose ports
EXPOSE 80
EXPOSE 443

# Run the application
ENTRYPOINT ["dotnet", "ProductService.Api.dll"]

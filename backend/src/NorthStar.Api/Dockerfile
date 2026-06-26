# Multi-stage build for the North Star API. Build context: ./backend
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Restore (layer-cached on csproj changes only)
COPY src/NorthStar.Domain/NorthStar.Domain.csproj src/NorthStar.Domain/
COPY src/NorthStar.Application/NorthStar.Application.csproj src/NorthStar.Application/
COPY src/NorthStar.Infrastructure/NorthStar.Infrastructure.csproj src/NorthStar.Infrastructure/
COPY src/NorthStar.Api/NorthStar.Api.csproj src/NorthStar.Api/
RUN dotnet restore src/NorthStar.Api/NorthStar.Api.csproj

# Build & publish
COPY src/ ./src/
RUN dotnet publish src/NorthStar.Api/NorthStar.Api.csproj -c Release -o /app /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "NorthStar.Api.dll"]

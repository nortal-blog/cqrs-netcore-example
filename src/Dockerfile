FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build

# copy csproj and restore as distinct layers
COPY ./cqrs-netcore-example/*.csproj /app/cqrs-netcore-example/
WORKDIR /app/cqrs-netcore-example
RUN ls -la
RUN dotnet restore cqrs-netcore-example.csproj

# copy everything else and build app
COPY ./cqrs-netcore-example /app/cqrs-netcore-example/
RUN dotnet publish -c Release -o out

# Use Microsoft's official runtime .NET image.
# https://hub.docker.com/_/microsoft-dotnet-core-aspnet/
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime
WORKDIR /app
COPY --from=build /app/cqrs-netcore-example/out ./
ENTRYPOINT ["dotnet", "cqrs-netcore-example.dll"] 
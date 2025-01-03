# CasaCue.Auth Dockerfile (Authentication Service)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files
COPY CasaCue.Auth/*.csproj ./CasaCue.Auth/
COPY CasaCue.Shared/*.csproj ./CasaCue.Shared/
RUN dotnet restore ./CasaCue.Auth/CasaCue.Auth.csproj

# Copy the entire source code and build the app
COPY . .
WORKDIR /src/CasaCue.Auth
RUN dotnet build CasaCue.Auth.csproj -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish CasaCue.Auth.csproj -c Release -o /app/publish

# Runtime environment
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CasaCue.Auth.dll"]


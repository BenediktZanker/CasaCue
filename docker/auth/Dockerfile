# CasaCue.Auth Dockerfile (Authentication Service)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiere die Projektdateien
COPY CasaCue.Auth/*.csproj ./CasaCue.Auth/
COPY CasaCue.Shared/*.csproj ./CasaCue.Shared/
RUN dotnet restore ./CasaCue.Auth/CasaCue.Auth.csproj

# Kopiere den gesamten Quellcode und baue die App
COPY . .
WORKDIR /src/CasaCue.Auth
RUN dotnet build CasaCue.Auth.csproj -c Release -o /app/build

# Veröffentliche die Anwendung
FROM build AS publish
RUN dotnet publish CasaCue.Auth.csproj -c Release -o /app/publish

# Laufzeitumgebung
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CasaCue.Auth.dll"]

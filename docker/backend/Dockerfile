# CasaCue Dockerfile (Backend Service)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiere die Projektdateien
COPY CasaCue/*.csproj ./CasaCue/
COPY CasaCue.Shared/*.csproj ./CasaCue.Shared/
RUN dotnet restore ./CasaCue/CasaCue.csproj

# Kopiere den gesamten Quellcode und baue die App
COPY . .
WORKDIR /src/CasaCue
RUN dotnet build CasaCue.csproj -c Release -o /app/build

# Veröffentliche die Anwendung
FROM build AS publish
RUN dotnet publish CasaCue.csproj -c Release -o /app/publish

# Laufzeitumgebung
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CasaCue.dll"]

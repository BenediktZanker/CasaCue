# Build-Image für .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projektdateien kopieren und Wiederherstellen von Abhängigkeiten
COPY ["../../CasaCue/CasaCue.csproj", "./"]
RUN dotnet restore "CasaCue.csproj"

# Code kopieren und Projekt kompilieren
COPY ../../CasaCue/ ./
RUN dotnet publish "CasaCue.csproj" -c Release -o /app/publish

# Runtime-Image für .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CasaCue.dll"]

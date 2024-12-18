# Build-Image für .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Korrekte Pfadangabe zur CasaCue.csproj
COPY ../../CasaCue/CasaCue.csproj ./ 
RUN dotnet restore "CasaCue.csproj"

# Kopiere den gesamten Code
COPY ../../CasaCue/ ./ 
RUN dotnet publish "CasaCue.csproj" -c Release -o /app

# Runtime-Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "CasaCue.dll"]

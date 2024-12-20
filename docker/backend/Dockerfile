# Stage 1: Build Image for .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the Shared project and restore its dependencies
COPY ./CasaCue.Shared/CasaCue.Shared.csproj ./CasaCue.Shared/
COPY ./CasaCue/CasaCue.csproj ./CasaCue/
RUN dotnet restore ./CasaCue/CasaCue.csproj

# Copy the source code of both projects into the container
COPY ./CasaCue.Shared/ ./CasaCue.Shared/
COPY ./CasaCue/ ./CasaCue/

# Build and publish the Backend application
RUN dotnet publish ./CasaCue/CasaCue.csproj -c Release -o /app/publish

# Stage 2: Runtime Image for .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory for the runtime container
WORKDIR /app

# Copy the compiled application from the build stage
COPY --from=build /app/publish .

# Copy wait-for-it.sh into the container
COPY ../../docker/scripts/wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

# Define the entry point for the container
ENTRYPOINT ["dotnet", "CasaCue.dll"]

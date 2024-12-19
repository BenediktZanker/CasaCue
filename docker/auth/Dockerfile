# Stage 1: Build Image for .NET SDK
# This stage uses the .NET SDK image to build the authentication application.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the auth project file to the container
COPY ["./auth/CasaCue.Auth.csproj", "./"]
RUN dotnet restore "CasaCue.Auth.csproj"

# Copy the auth source code into the container
COPY ./auth/ ./

# Build and publish the auth application
RUN dotnet publish "CasaCue.Auth.csproj" -c Release -o /app/publish

# Stage 2: Runtime Image for .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory for the runtime container
WORKDIR /app

# Copy the compiled auth application from the build stage
COPY --from=build /app/publish .

# Define the entry point for the container
ENTRYPOINT ["dotnet", "CasaCue.Auth.dll"]

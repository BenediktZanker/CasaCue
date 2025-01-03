# CasaCue Dockerfile (Backend Service)

# Stage 1: Base Image
# Use the official ASP.NET Core runtime image as the base for the final runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app  # Set the working directory inside the container to /app
EXPOSE 5000  
EXPOSE 5001  

# Stage 2: Build Environment
# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src  # Set the working directory inside the container to /src

# Copy the project files to the build context
# This helps in leveraging Docker's caching mechanism to avoid restoring packages unnecessarily
COPY CasaCue/*.csproj ./CasaCue/
COPY CasaCue.Shared/*.csproj ./CasaCue.Shared/

# Restore the NuGet packages required by the project
# This step is cached unless the project files change
RUN dotnet restore ./CasaCue/CasaCue.csproj

# Copy the entire source code into the container
COPY . .  

# Set the working directory to the CasaCue project directory
WORKDIR /src/CasaCue

# Build the application in Release configuration and output the build artifacts to /app/build
RUN dotnet build CasaCue.csproj -c Release -o /app/build

# Stage 3: Publish the Application
FROM build AS publish

# Publish the application, compiling it and preparing it for deployment
# The output is placed in /app/publish
RUN dotnet publish CasaCue.csproj -c Release -o /app/publish

# Stage 4: Final Runtime Image
# Use the base runtime image to create a lightweight container for running the application
FROM base AS final
WORKDIR /app  # Set the working directory to /app

# Copy the published application from the publish stage to the final stage
COPY --from=publish /app/publish .

# Define the entry point for the container to run the application
ENTRYPOINT ["dotnet", "CasaCue.dll"]


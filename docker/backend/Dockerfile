# Stage 1: Build Image for .NET SDK
# This stage uses the .NET SDK image to build the backend application.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the backend project file to the container
COPY ["./backend/CasaCue.csproj", "./"]
RUN dotnet restore "CasaCue.Backend.csproj"

# Copy the backend source code into the container
COPY ./backend/ ./

# Build and publish the backend application
RUN dotnet publish "CasaCue.Backend.csproj" -c Release -o /app/publish

# Stage 2: Runtime Image for .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory for the runtime container
WORKDIR /app

# Copy the compiled backend application from the build stage
COPY --from=build /app/publish .

# Define the entry point for the container
ENTRYPOINT ["dotnet", "CasaCue.Backend.dll"]



# Use ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AircraftMaintenanceAPI/AircraftMaintenanceAPI.csproj", "AircraftMaintenanceAPI/"]
RUN dotnet restore "./AircraftMaintenanceAPI/AircraftMaintenanceAPI.csproj"
COPY . .
WORKDIR "/src/AircraftMaintenanceAPI"
RUN dotnet build "./AircraftMaintenanceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AircraftMaintenanceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AircraftMaintenanceAPI.dll"]

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["2d6-dungeon-client.sln", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["global.json", "./"]
COPY ["2d6-dungeon-web-client/2d6-dungeon-web-client.csproj", "2d6-dungeon-web-client/"]
COPY ["2d6-dungeon-service/2d6-dungeon-service.csproj", "2d6-dungeon-service/"]
COPY ["ServiceDefaults/ServiceDefaults.csproj", "ServiceDefaults/"]

# Restore dependencies
RUN dotnet restore "2d6-dungeon-web-client/2d6-dungeon-web-client.csproj"

# Copy everything else
COPY . .

# Build the project
WORKDIR "/src/2d6-dungeon-web-client"
RUN dotnet build "2d6-dungeon-web-client.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "2d6-dungeon-web-client.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "2d6-dungeon-web-client.dll"]

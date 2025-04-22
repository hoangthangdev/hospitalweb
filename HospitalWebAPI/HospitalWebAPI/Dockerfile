# Base image để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy file project và restore dependencies
COPY ["HospitalWebAPI/HospitalWebAPI.csproj", "HospitalWebAPI/"]
COPY ["BuildingCore/BuildingCore.csproj", "BuildingCore/"]
RUN dotnet restore "./HospitalWebAPI/HospitalWebAPI.csproj"

# Copy toàn bộ source code và build
COPY . .
WORKDIR "/src/HospitalWebAPI"
RUN dotnet build "./HospitalWebAPI.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "./HospitalWebAPI.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

# Final stage để chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "HospitalWebAPI.dll"]

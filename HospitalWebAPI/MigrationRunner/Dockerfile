FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY MigrationRunner/*.csproj MigrationRunner/
COPY HospitalWebAPI/*.csproj HospitalWebAPI/
RUN dotnet restore MigrationRunner/MigrationRunner.csproj

COPY . .
WORKDIR /src/MigrationRunner
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "MigrationRunner.dll"]

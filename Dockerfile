# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo el contenido del proyecto (incluyendo subcarpetas)
COPY . .

# Restaura dependencias (usa el .csproj o .sln adecuado)
RUN dotnet restore "BusinessService/BusinessService.csproj"

# Publica la app
RUN dotnet publish "BusinessService/BusinessService.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "BusinessService.dll"]
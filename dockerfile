# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos del proyecto
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Puerto expuesto (ajústalo si tu API usa otro)
EXPOSE 8081

# Variable de entorno opcional
ENV ASPNETCORE_URLS=http://+:8081

ENTRYPOINT ["dotnet", "BusinessService.dll"]

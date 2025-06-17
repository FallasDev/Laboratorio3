# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar y restaurar dependencias
COPY ["Laboratorio3.csproj", "."]
RUN dotnet restore "Laboratorio3.csproj"

# Copiar todo el código y compilar
COPY . .
RUN dotnet build "Laboratorio3.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "Laboratorio3.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Laboratorio3.dll"]  # Cambiado a Laboratorio3.dll
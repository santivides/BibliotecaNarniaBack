# Usar la imagen oficial de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar los archivos del proyecto a la carpeta TodoApi
COPY ./TodoApi ./TodoApi

# Establecer el directorio de trabajo en TodoApi
WORKDIR /app/TodoApi

# Restaurar dependencias
RUN dotnet restore

# Construir la aplicación
RUN dotnet publish -c Release -o out

# Ver el contenido de la carpeta de salida
RUN ls -la /app/TodoApi/out

# Usar la imagen de .NET Runtime para correr la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/TodoApi/out .

# Exponer el puerto en el que tu backend corre
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "TodoApi.dll"]


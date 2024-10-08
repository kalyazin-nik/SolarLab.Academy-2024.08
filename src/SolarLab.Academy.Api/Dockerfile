# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SolarLab.Academy.Api/SolarLab.Academy.Api.csproj", "src/SolarLab.Academy.Api/"]
COPY ["src/SolarLab.Academy.AppServices/SolarLab.Academy.AppServices.csproj", "src/SolarLab.Academy.AppServices/"]
COPY ["src/SolarLab.Academy.Contracts/SolarLab.Academy.Contracts.csproj", "src/SolarLab.Academy.Contracts/"]
COPY ["src/SolarLab.Academy.Domain/SolarLab.Academy.Domain.csproj", "src/SolarLab.Academy.Domain/"]
COPY ["src/SolarLab.Academy.ComponentRegistrar/SolarLab.Academy.ComponentRegistrar.csproj", "src/SolarLab.Academy.ComponentRegistrar/"]
COPY ["src/SolarLab.Academy.Infrastructure/SolarLab.Academy.Infrastructure.csproj", "src/SolarLab.Academy.Infrastructure/"]
COPY ["src/SolarLab.Academy.DataAccess/SolarLab.Academy.DataAccess.csproj", "src/SolarLab.Academy.DataAccess/"]
RUN dotnet restore "./src/SolarLab.Academy.Api/SolarLab.Academy.Api.csproj"
COPY . .
WORKDIR "/src/src/SolarLab.Academy.Api"
RUN dotnet build "./SolarLab.Academy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SolarLab.Academy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SolarLab.Academy.Api.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RMS - Main/RMS.Api/RMS.Api.csproj", "RMS.Api/"]
COPY ["RMS - Main/RMS.Domain/RMS.Domain.csproj", "RMS.Domain/"]
COPY ["RMS - Main/RMS.Application/RMS.Application.csproj", "RMS.Application/"]
COPY ["RMS - Main/RMS.Infrastructure/RMS.Infrastructure.csproj", "RMS.Infrastructure/"]
RUN dotnet restore "RMS - Main/RMS.Api/RMS.Api.csproj"
COPY . .
WORKDIR "/src/RMS.Api"
RUN dotnet build "RMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RMS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RMS.Api.dll"]

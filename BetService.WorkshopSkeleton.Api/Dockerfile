# build from solution foler => docker build -f "BetService.WorkshopSkeleton.Api\Dockerfile" -t workshopSkeleton .
# docker run -p 8080:8080 workshopSkeleton
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["BetService.WorkshopSkeleton.Api/BetService.WorkshopSkeleton.Api.csproj", "BetService.WorkshopSkeleton.Api/"]
COPY ["BetService.WorkshopSkeleton.Application/BetService.WorkshopSkeleton.Application.csproj", "BetService.WorkshopSkeleton.Application/"]
COPY ["BetService.WorkshopSkeleton.Domain/BetService.WorkshopSkeleton.Domain.csproj", "BetService.WorkshopSkeleton.Domain/"]
COPY ["BetService.WorkshopSkeleton.Infrastructure/BetService.WorkshopSkeleton.Infrastructure.csproj", "BetService.WorkshopSkeleton.Infrastructure/"]

RUN dotnet restore "BetService.WorkshopSkeleton.Api/BetService.WorkshopSkeleton.Api.csproj"

COPY . .

WORKDIR "/src/BetService.WorkshopSkeleton.Api"
RUN dotnet build "BetService.WorkshopSkeleton.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BetService.WorkshopSkeleton.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BetService.WorkshopSkeleton.Api.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 1060

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Catalog/VivaioInCloud.Catalog.Api/VivaioInCloud.Catalog.Api.csproj", "src/Catalog/VivaioInCloud.Catalog.Api/"]
COPY ["src/Common/VivaioInCloud.Common/VivaioInCloud.Common.csproj", "src/Common/VivaioInCloud.Common/"]
COPY ["src/Common/VivaioInCloud.Notificator/VivaioInCloud.Notificator.csproj", "src/Common/VivaioInCloud.Notificator/"]
COPY ["src/Catalog/VivaioInCloud.Catalog.Abstraction/VivaioInCloud.Catalog.Abstraction.csproj", "src/Catalog/VivaioInCloud.Catalog.Abstraction/"]
COPY ["src/Catalog/VivaioInCloud.Catalog.Entities/VivaioInCloud.Catalog.Entities.csproj", "src/Catalog/VivaioInCloud.Catalog.Entities/"]
COPY ["src/Identity/VivaioInCloud.Identity.Entities/VivaioInCloud.Identity.Entities.csproj", "src/Identity/VivaioInCloud.Identity.Entities/"]
COPY ["src/Catalog/VivaioInCloud.Catalog.Infrastructure/VivaioInCloud.Catalog.Infrastructure.csproj", "src/Catalog/VivaioInCloud.Catalog.Infrastructure/"]
COPY ["src/Catalog/VivaioInCloud.Catalog.Services/VivaioInCloud.Catalog.Services.csproj", "src/Catalog/VivaioInCloud.Catalog.Services/"]
RUN dotnet restore "src/Catalog/VivaioInCloud.Catalog.Api/VivaioInCloud.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/src/Catalog/VivaioInCloud.Catalog.Api"
RUN dotnet build "VivaioInCloud.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VivaioInCloud.Catalog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VivaioInCloud.Catalog.Api.dll"]

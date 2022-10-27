#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:1050"
EXPOSE 1050

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Identity/VivaioInCloud.Identity.Api/VivaioInCloud.Identity.Api.csproj", "src/Identity/VivaioInCloud.Identity.Api/"]
COPY ["src/Common/VivaioInCloud.Common/VivaioInCloud.Common.csproj", "src/Common/VivaioInCloud.Common/"]
COPY ["src/Common/VivaioInCloud.Notificator/VivaioInCloud.Notificator.csproj", "src/Common/VivaioInCloud.Notificator/"]
COPY ["src/Identity/VivaioInCloud.Identity.Abstraction/VivaioInCloud.Identity.Abstraction.csproj", "src/Identity/VivaioInCloud.Identity.Abstraction/"]
COPY ["src/Identity/VivaioInCloud.Identity.Entities/VivaioInCloud.Identity.Entities.csproj", "src/Identity/VivaioInCloud.Identity.Entities/"]
COPY ["src/Identity/VivaioInCloud.Identity.Infrastructure/VivaioInCloud.Identity.Infrastructure.csproj", "src/Identity/VivaioInCloud.Identity.Infrastructure/"]
COPY ["src/Identity/VivaioInCloud.Identity.Services/VivaioInCloud.Identity.Services.csproj", "src/Identity/VivaioInCloud.Identity.Services/"]
RUN dotnet restore "src/Identity/VivaioInCloud.Identity.Api/VivaioInCloud.Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/Identity/VivaioInCloud.Identity.Api"
RUN dotnet build "VivaioInCloud.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VivaioInCloud.Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VivaioInCloud.Identity.Api.dll"]
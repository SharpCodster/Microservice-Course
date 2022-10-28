#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:1070"
EXPOSE 1070

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Notification/VivaioInCloud.Notification.Api/VivaioInCloud.Notification.Api.csproj", "src/Notification/VivaioInCloud.Notification.Api/"]
COPY ["src/Common/VivaioInCloud.Common/VivaioInCloud.Common.csproj", "src/Common/VivaioInCloud.Common/"]
COPY ["src/Common/VivaioInCloud.Notificator/VivaioInCloud.Notificator.csproj", "src/Common/VivaioInCloud.Notificator/"]
COPY ["src/Identity/VivaioInCloud.Identity.Entities/VivaioInCloud.Identity.Entities.csproj", "src/Identity/VivaioInCloud.Identity.Entities/"]
COPY ["src/Notification/VivaioInCloud.Notification.Abstraction/VivaioInCloud.Notification.Abstraction.csproj", "src/Notification/VivaioInCloud.Notification.Abstraction/"]
COPY ["src/Notification/VivaioInCloud.Notification.Entities/VivaioInCloud.Notification.Entities.csproj", "src/Notification/VivaioInCloud.Notification.Entities/"]
COPY ["src/Notification/VivaioInCloud.Notification.Infrastructure/VivaioInCloud.Notification.Infrastructure.csproj", "src/Notification/VivaioInCloud.Notification.Infrastructure/"]
COPY ["src/Notification/VivaioInCloud.Notification.Services/VivaioInCloud.Notification.Services.csproj", "src/Notification/VivaioInCloud.Notification.Services/"]
RUN dotnet restore "src/Notification/VivaioInCloud.Notification.Api/VivaioInCloud.Notification.Api.csproj"
COPY . .
WORKDIR "/src/src/Notification/VivaioInCloud.Notification.Api"
RUN dotnet build "VivaioInCloud.Notification.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VivaioInCloud.Notification.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VivaioInCloud.Notification.Api.dll"]
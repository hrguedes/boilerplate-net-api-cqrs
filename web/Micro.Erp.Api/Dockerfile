FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

LABEL author="Hugo Guedes"
LABEL description="Micro ERP API"
LABEL version="1.0.0-beta"

ENV DOTNET_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["web/Micro.Erp.Api/Micro.Erp.Api.csproj", "web/Micro.Erp.Api/"]
COPY ["src/Micro.Erp.Domain/Micro.Erp.Domain.csproj", "src/Micro.Erp.Domain/"]
COPY ["src/Micro.Erp.Infra/Micro.Erp.Infra.csproj", "src/Micro.Erp.Infra/"]
COPY ["src/Micro.Erp.Infra.Data/Micro.Erp.Infra.Data.csproj", "src/Micro.Erp.Infra.Data/"]
COPY ["src/Micro.Erp.Utils/Micro.Erp.Utils.csproj", "src/Micro.Erp.Utils/"]
COPY ["src/Micro.Erp.Infra.Data.Queries/Micro.Erp.Infra.Data.Queries.csproj", "src/Micro.Erp.Infra.Data.Queries/"]
COPY ["src/Micro.Erp.Application/Micro.Erp.Application.csproj", "src/Micro.Erp.Application/"]
RUN dotnet restore "web/Micro.Erp.Api/Micro.Erp.Api.csproj"
COPY . .
WORKDIR "/src/web/Micro.Erp.Api"
RUN dotnet build "Micro.Erp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.Erp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.Erp.Api.dll"]

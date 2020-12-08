#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RockContent.API/RockContent.API.csproj", "RockContent.API/"]
COPY ["RockContent.DataAccessLayer/RockContent.DataAccessLayer.csproj", "RockContent.DataAccessLayer/"]
COPY ["RockContent.Core/RockContent.Core.csproj", "RockContent.Core/"]
RUN dotnet restore "RockContent.API/RockContent.API.csproj"
COPY . .
WORKDIR "/src/RockContent.API"
RUN dotnet build "RockContent.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RockContent.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RockContent.API.dll"]
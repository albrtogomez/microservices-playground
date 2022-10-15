#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/MovieCatalog.API/MovieCatalog.API.csproj", "Services/MovieCatalog.API/"]
RUN dotnet restore "Services/MovieCatalog.API/MovieCatalog.API.csproj"
COPY . .
WORKDIR "/src/Services/MovieCatalog.API"
RUN dotnet build "MovieCatalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieCatalog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieCatalog.API.dll"]
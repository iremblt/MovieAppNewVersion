#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MovieAppNewVersion/MovieAppNewVersion.csproj", "MovieAppNewVersion/"]
COPY ["MovieAppNewVersion.DTO/MovieAppNewVersion.DTO.csproj", "MovieAppNewVersion.DTO/"]
COPY ["MovieAppNewVersion.Entities/MovieAppNewVersion.Entities.csproj", "MovieAppNewVersion.Entities/"]
COPY ["MovieAppNewVersion.Business/MovieAppNewVersion.Business.csproj", "MovieAppNewVersion.Business/"]
COPY ["MovieAppNewVersion.DataAccess/MovieAppNewVersion.DataAccess.csproj", "MovieAppNewVersion.DataAccess/"]
RUN dotnet restore "MovieAppNewVersion/MovieAppNewVersion.csproj"
COPY . .
WORKDIR "/src/MovieAppNewVersion"
RUN dotnet build "MovieAppNewVersion.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieAppNewVersion.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieAppNewVersion.dll"]
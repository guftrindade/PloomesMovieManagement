#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Movie.Management.Api/Movie.Management.Api.csproj", "Movie.Management.Api/"]
COPY ["Movie.Management.Domain/Movie.Management.Domain.csproj", "Movie.Management.Domain/"]
COPY ["Movie.Management.Infra/Movie.Management.Infra.csproj", "Movie.Management.Infra/"]
RUN dotnet restore "Movie.Management.Api/Movie.Management.Api.csproj"
COPY . .
WORKDIR "/src/Movie.Management.Api"
RUN dotnet build "Movie.Management.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movie.Management.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movie.Management.Api.dll"]
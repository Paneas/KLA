#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KLA.API/KLA.API.csproj", "KLA.API/"]
COPY ["KLA.Conversion/KLA.Conversion.csproj", "KLA.Conversion/"]
COPY ["KLA.Models/KLA.Models.csproj", "KLA.Models/"]
RUN dotnet restore "./KLA.API/KLA.API.csproj"
COPY . .
WORKDIR "/src/KLA.API"
RUN dotnet build "./KLA.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KLA.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KLA.API.dll"]
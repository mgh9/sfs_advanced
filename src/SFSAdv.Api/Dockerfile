#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Stage 1: Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Stage 2: Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore dependencies
COPY ["src/SFSAdv.Api/SFSAdv.Api.csproj", "src/SFSAdv.Api/"]
COPY ["src/SFSAdv.Application/SFSAdv.Application.csproj", "src/SFSAdv.Application/"]
COPY ["src/SFSAdv.Domain/SFSAdv.Domain.csproj", "src/SFSAdv.Domain/"]
COPY ["src/SFSAdv.Infrastructure/SFSAdv.Infrastructure.csproj", "src/SFSAdv.Infrastructure/"]
RUN dotnet restore "./src/SFSAdv.Api/./SFSAdv.Api.csproj"

# Copy the rest of the source code and build
COPY . .
WORKDIR "/src/src/SFSAdv.Api"
RUN dotnet build "./SFSAdv.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SFSAdv.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SFSAdv.Api.dll"]
# 1. Use .NET 8 Runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app
EXPOSE 80

# 2. Use .NET SDK image to build app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
# RUN dotnet publish -c Release -o /app/publish
RUN dotnet publish -c Release -o /app

# 3. Use runtime image to run app
FROM base AS final
# WORKDIR /app
# COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ImageConvertorAPI.dll"]
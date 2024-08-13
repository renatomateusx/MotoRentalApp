# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 8080

# Copy the project file and restore dependencies
COPY MotoRentalApp.csproj ./
RUN dotnet restore MotoRentalApp.csproj

# Copy the rest of the source code and build
COPY . ./
RUN dotnet build MotoRentalApp.csproj -c Release -o /app/build

# Publish the application
RUN dotnet publish MotoRentalApp.csproj -c Release -o /app/publish

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MotoRentalApp.dll"]


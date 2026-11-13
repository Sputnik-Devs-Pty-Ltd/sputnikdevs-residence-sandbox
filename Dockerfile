
# Stage 1: Build and publish the API
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY ["SputnikDevs.Residence.SandboxApi/SputnikDevs.Residence.SandboxApi.csproj", "SputnikDevs.Residence.SandboxApi/"]

RUN dotnet restore "SputnikDevs.Residence.SandboxApi/SputnikDevs.Residence.SandboxApi.csproj"

# Copy the remaining source code
COPY . .

WORKDIR /src/SputnikDevs.Residence.SandboxApi

# Compile and publish the application
RUN dotnet publish "SputnikDevs.Residence.SandboxApi.csproj" \
    --configuration Release \
    --output /app/publish \
    --no-restore \
    /p:UseAppHost=false

# Stage 2: Run the published application
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

# Copy only the published output from the build stage
COPY --from=build /app/publish .

# Configure the application to listen on port 8080
ENV ASPNETCORE_HTTP_PORTS=8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "SputnikDevs.Residence.SandboxApi.dll"]

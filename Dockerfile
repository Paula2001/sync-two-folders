FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/sync.csproj", "src/"]
RUN dotnet restore "src/sync.csproj"

COPY . .
WORKDIR /src/src
RUN dotnet publish "sync.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

RUN mkdir -p /app/data/source /app/data/replica /app/logs

ENTRYPOINT ["dotnet", "sync.dll"]

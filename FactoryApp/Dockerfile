FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FactoryApp/FactoryApp.csproj", "FactoryApp/"]
RUN dotnet restore "FactoryApp/FactoryApp.csproj"
COPY . .
WORKDIR "/src/FactoryApp"
RUN dotnet build "FactoryApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FactoryApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FactoryApp.dll"]

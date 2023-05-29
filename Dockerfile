FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5010

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY [".", "."]
RUN dotnet restore "MarketPlace.api/MarketPlace.api.csproj"
COPY . .
WORKDIR "/src/MarketPlace.api"
RUN dotnet build "MarketPlace.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarketPlace.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketPlace.api.dll"]
EXPOSE 5010

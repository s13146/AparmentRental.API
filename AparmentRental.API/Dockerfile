FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AparmentRental.API/AparmentRental.API.csproj", "AparmentRental.API/"]
RUN dotnet restore "AparmentRental.API/AparmentRental.API.csproj"
COPY . .
WORKDIR "/src/AparmentRental.API"
RUN dotnet build "AparmentRental.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AparmentRental.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AparmentRental.API.dll"]

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SkodaApi.csproj", "./"]
RUN dotnet restore "SkodaApi.csproj"
COPY . .
RUN dotnet build "SkodaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkodaApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "SkodaApi.dll"]

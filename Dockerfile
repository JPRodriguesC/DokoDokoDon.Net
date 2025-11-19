FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src

COPY Doko.Rest/Doko.Rest.csproj Doko.Rest/
COPY Doko.Don/Doko.Don.csproj Doko.Don/
COPY Doko.Get/Doko.Get.csproj Doko.Get/
COPY Doko.Infra/Doko.Infra.csproj Doko.Infra/
COPY Doko.Mongo/Doko.Mongo.csproj Doko.Mongo/
RUN dotnet restore "Doko.Rest/Doko.Rest.csproj"

COPY . .
WORKDIR "/src/Doko.Rest"
RUN dotnet build "Doko.Rest.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Doko.Rest.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Doko.Rest.dll"]

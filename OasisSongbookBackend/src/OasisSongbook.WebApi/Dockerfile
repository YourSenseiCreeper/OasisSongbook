# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
# WORKDIR .
COPY *.csproj .
RUN dotnet restore
# COPY src .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "OasisSongbookBackend.WebApi.dll"]
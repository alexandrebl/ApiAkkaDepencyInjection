FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ApiAkkaDepencyInjection/ApiAkkaDepencyInjection.csproj", "ApiAkkaDepencyInjection/"]
RUN dotnet restore "ApiAkkaDepencyInjection/ApiAkkaDepencyInjection.csproj"
COPY . .
WORKDIR "/src/ApiAkkaDepencyInjection"
RUN dotnet build "ApiAkkaDepencyInjection.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiAkkaDepencyInjection.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiAkkaDepencyInjection.dll"]
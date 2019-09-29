FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Inventti.CodeChallenge.PrimeString.Api/Inventti.CodeChallenge.PrimeString.Api.csproj", "Inventti.CodeChallenge.PrimeString.Api/"]
RUN dotnet restore "Inventti.CodeChallenge.PrimeString.Api/Inventti.CodeChallenge.PrimeString.Api.csproj"
COPY . .
WORKDIR "/src/Inventti.CodeChallenge.PrimeString.Api"
RUN dotnet build "Inventti.CodeChallenge.PrimeString.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventti.CodeChallenge.PrimeString.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventti.CodeChallenge.PrimeString.Api.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Inventti.CodeChallenge.PrimeString/Inventti.CodeChallenge.PrimeString.csproj", "Inventti.CodeChallenge.PrimeString/"]
RUN dotnet restore "Inventti.CodeChallenge.PrimeString/Inventti.CodeChallenge.PrimeString.csproj"
COPY . .
WORKDIR "/src/Inventti.CodeChallenge.PrimeString"
RUN dotnet build "Inventti.CodeChallenge.PrimeString.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Inventti.CodeChallenge.PrimeString.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Inventti.CodeChallenge.PrimeString.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Softplan.CalcTest.InterestRateApi.csproj", "Softplan.CalcTest.InterestRateApi/"]
RUN dotnet restore "Softplan.CalcTest.InterestRateApi/Softplan.CalcTest.InterestRateApi.csproj"
COPY . .
#WORKDIR "/src/Softplan.CalcTest.InterestRateApi"
RUN dotnet build "Softplan.CalcTest.InterestRateApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Softplan.CalcTest.InterestRateApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Softplan.CalcTest.InterestRateApi.dll"]
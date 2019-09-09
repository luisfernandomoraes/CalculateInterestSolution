FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Softplan.CalcTest.CalculateInterestApi/Softplan.CalcTest.CalculateInterestApi.csproj", "Softplan.CalcTest.CalculateInterestApi/"]
RUN dotnet restore "Softplan.CalcTest.CalculateInterestApi/Softplan.CalcTest.CalculateInterestApi.csproj"
COPY . .
WORKDIR "/src/Softplan.CalcTest.CalculateInterestApi"
RUN dotnet build "Softplan.CalcTest.CalculateInterestApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Softplan.CalcTest.CalculateInterestApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Softplan.CalcTest.CalculateInterestApi.dll"]
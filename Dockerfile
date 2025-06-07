FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

COPY ["EmployeeApi.Api/EmployeeApi.Api.csproj", "EmployeeApi.Api/"]
RUN dotnet restore "EmployeeApi.Api/EmployeeApi.Api.csproj"

COPY . .

WORKDIR "/src/EmployeeApi.Api"
RUN dotnet publish "EmployeeApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EmployeeApi.Api.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY DatabaseInsurance/DatabaseInsurance.csproj DatabaseInsurance/
RUN dotnet restore "DatabaseInsurance.csproj"
RUN dotnet publish "DatabaseInsurance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DatabaseInsurance.dll"]

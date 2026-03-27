FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
RUN apt-get update && apt-get install -y libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY DatabaseInsurance/DatabaseInsurance.csproj DatabaseInsurance/
RUN dotnet restore "DatabaseInsurance/DatabaseInsurance.csproj"
COPY DatabaseInsurance/ DatabaseInsurance/
WORKDIR /src/DatabaseInsurance
RUN dotnet publish "DatabaseInsurance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DatabaseInsurance.dll"]
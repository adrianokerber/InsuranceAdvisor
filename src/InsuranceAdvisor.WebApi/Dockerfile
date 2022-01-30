FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /
COPY . .
RUN dotnet restore "InsuranceAdvisor.WebApi.csproj"

FROM build AS publish
RUN dotnet publish "InsuranceAdvisor.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsuranceAdvisor.WebApi.dll"]
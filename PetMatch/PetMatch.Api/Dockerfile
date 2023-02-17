FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /PetMatch.Api
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /PetMatch.Api
COPY ["PetMatch.Api.csproj", "."]
RUN dotnet restore "./PetMatch.Api.csproj"
COPY . .
WORKDIR "/PetMatch.Api/."
RUN dotnet build "PetMatch.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetMatch.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetMatch.Api.dll"]

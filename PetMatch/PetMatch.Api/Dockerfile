FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /PetMatch.Api
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /PetMatch.Api
COPY --from=build /app/out .
EXPOSE 8081
ENTRYPOINT ["dotnet", "PetMatch.Api.dll"]--host=0.0.0.0

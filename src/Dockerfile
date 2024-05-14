FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

COPY ["./NumberToWord.Api/NumberToWord.Api.csproj", "NumberToWord.Api/"]
RUN dotnet restore "NumberToWord.Api/NumberToWord.Api.csproj"
COPY . .
WORKDIR "/src/NumberToWord.Api"
RUN dotnet build "NumberToWord.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NumberToWord.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumberToWord.Api.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Noazul.Services.Api/Noazul.Services.Api.csproj", "src/Noazul.Services.Api/"]
RUN dotnet restore "src/Noazul.Services.Api/Noazul.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/Noazul.Services.Api"
RUN dotnet build "Noazul.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Noazul.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Noazul.Services.Api.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["service_music_streaming/service_music_streaming.csproj", "service_music_streaming/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["DataAccessLayer/DAL.csproj", "DataAccessLayer/"]
COPY ["Contract_Layer/Contract_Layer.csproj", "Contract_Layer/"]
RUN dotnet restore "service_music_streaming/service_music_streaming.csproj"
COPY . .
WORKDIR "/src/service_music_streaming"
RUN dotnet build "service_music_streaming.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "service_music_streaming.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service_music_streaming.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GrpcDotnet.Service/GrpcDotnet.Service.csproj", "src/GrpcDotnet.Service/"]
RUN dotnet restore "src/GrpcDotnet.Service/GrpcDotnet.Service.csproj"
COPY . .
WORKDIR "/src/src/GrpcDotnet.Service"
RUN dotnet build "GrpcDotnet.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcDotnet.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcDotnet.Service.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["consumidor_transacao/consumidor_transacao.csproj", "consumidor_transacao/"]
RUN dotnet restore "consumidor_transacao/consumidor_transacao.csproj"
COPY . .
WORKDIR "/src/consumidor_transacao"
RUN dotnet build "consumidor_transacao.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "consumidor_transacao.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "consumidor_transacao.dll"]
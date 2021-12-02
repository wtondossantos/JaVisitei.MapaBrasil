#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
MAINTAINER Wellington dos Santos Castor
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
COPY JaVisitei.MapaBrasil.Mapper/JaVisitei.MapaBrasil.Mapper.csproj JaVisitei.MapaBrasil.Mapper/
COPY JaVisitei.MapaBrasil.Data/JaVisitei.MapaBrasil.Data.csproj JaVisitei.MapaBrasil.Data/
COPY JaVisitei.MapaBrasil.Security/JaVisitei.MapaBrasil.Security.csproj JaVisitei.MapaBrasil.Security/
COPY JaVisitei.MapaBrasil.Service/JaVisitei.MapaBrasil.Service.csproj JaVisitei.MapaBrasil.Service/
COPY JaVisitei.MapaBrasil.Business/JaVisitei.MapaBrasil.Business.csproj JaVisitei.MapaBrasil.Business/
COPY JaVisitei.MapaBrasil.Repository/JaVisitei.MapaBrasil.Repository.csproj JaVisitei.MapaBrasil.Repository/
COPY JaVisitei.MapaBrasil.Api/JaVisitei.MapaBrasil.Api.csproj JaVisitei.MapaBrasil.Api/
RUN dotnet restore "JaVisitei.MapaBrasil.Api/JaVisitei.MapaBrasil.Api.csproj"
COPY . .
WORKDIR "/JaVisitei.MapaBrasil.Api"
RUN dotnet build "JaVisitei.MapaBrasil.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JaVisitei.MapaBrasil.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JaVisitei.MapaBrasil.Api.dll"]
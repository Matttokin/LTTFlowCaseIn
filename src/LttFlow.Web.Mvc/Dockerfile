#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/LttFlow.Web.Mvc/LttFlow.Web.Mvc.csproj", "src/LttFlow.Web.Mvc/"]
COPY ["src/LttFlow.Web.Core/LttFlow.Web.Core.csproj", "src/LttFlow.Web.Core/"]
COPY ["src/LttFlow.Application/LttFlow.Application.csproj", "src/LttFlow.Application/"]
COPY ["src/LttFlow.Core/LttFlow.Core.csproj", "src/LttFlow.Core/"]
COPY ["src/LttFlow.EntityFrameworkCore/LttFlow.EntityFrameworkCore.csproj", "src/LttFlow.EntityFrameworkCore/"]
RUN dotnet restore "src/LttFlow.Web.Mvc/LttFlow.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/LttFlow.Web.Mvc"
RUN dotnet build "LttFlow.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LttFlow.Web.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LttFlow.Web.Mvc.dll"]

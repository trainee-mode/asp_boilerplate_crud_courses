FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/test123.Web.Host/test123.Web.Host.csproj", "src/test123.Web.Host/"]
COPY ["src/test123.Web.Core/test123.Web.Core.csproj", "src/test123.Web.Core/"]
COPY ["src/test123.Application/test123.Application.csproj", "src/test123.Application/"]
COPY ["src/test123.Core/test123.Core.csproj", "src/test123.Core/"]
COPY ["src/test123.EntityFrameworkCore/test123.EntityFrameworkCore.csproj", "src/test123.EntityFrameworkCore/"]
WORKDIR "/src/src/test123.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/test123.Web.Host", "src/test123.Web.Host"]
COPY ["src/test123.Web.Core", "src/test123.Web.Core"]
COPY ["src/test123.Application", "src/test123.Application"]
COPY ["src/test123.Core", "src/test123.Core"]
COPY ["src/test123.EntityFrameworkCore", "src/test123.EntityFrameworkCore"]
WORKDIR "/src/src/test123.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "test123.Web.Host.dll"]

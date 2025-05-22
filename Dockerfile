# Aluskiht
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
# Tee kataloog /app vmis ja vaheta aktiivne kataloog sinna
WORKDIR /app

# Install PostgreSQL client
RUN apt-get update && apt-get install -y postgresql-client

# kopeeri solution hetke hosti kataloogist konteineri aktiivsesse kataloogi
# kuskohast -> kuhu
COPY *.sln .

# kopeerime kõik projektid solutionist

COPY Base.BLL/*.csproj ./Base.BLL/
COPY Base.BLL.Contracts/*.csproj ./Base.BLL.Contracts/
COPY Base.Contracts/*.csproj ./Base.Contracts/
COPY Base.DAL.Contracts/*.csproj ./Base.DAL.Contracts/
COPY Base.DAL.EF/*.csproj ./Base.DAL.EF/
COPY Base.Domain/*.csproj ./Base.Domain/
COPY Base.Helpers/*.csproj ./Base.Helpers/
COPY Base.Resources/*.csproj ./Base.Resources/

COPY App.BLL/*.csproj ./App.BLL/
COPY App.BLL.Contracts/*.csproj ./App.BLL.Contracts/
COPY App.BLL.DTO/*.csproj ./App.BLL.DTO/
COPY App.DAL.Contracts/*.csproj ./App.DAL.Contracts/
COPY App.DAL.DTO/*.csproj ./App.DAL.DTO/
COPY App.DAL.EF/*.csproj ./App.DAL.EF/
COPY App.Domain/*.csproj ./App.Domain/
COPY App.DTO/*.csproj ./App.DTO/
COPY App.Resources/*.csproj ./App.Resources/
COPY App.Test/*.csproj ./App.Test/

COPY WebApp/*.csproj ./WebApp/

# taasta nuget paketid konteineris
RUN dotnet restore

# kopeeri kogu lahtekood ja ehita rakendus

COPY Base.BLL/. ./Base.BLL/
COPY Base.BLL.Contracts/. ./Base.BLL.Contracts/
COPY Base.Contracts/. ./Base.Contracts/
COPY Base.DAL.Contracts/. ./Base.DAL.Contracts/
COPY Base.DAL.EF/. ./Base.DAL.EF/
COPY Base.Domain/. ./Base.Domain/
COPY Base.Helpers/. ./Base.Helpers/
COPY Base.Resources/. ./Base.Resources/

COPY App.BLL/. ./App.BLL/
COPY App.BLL.Contracts/. ./App.BLL.Contracts/
COPY App.BLL.DTO/. ./App.BLL.DTO/
COPY App.DAL.Contracts/. ./App.DAL.Contracts/
COPY App.DAL.DTO/. ./App.DAL.DTO/
COPY App.DAL.EF/. ./App.DAL.EF/
COPY App.Domain/. ./App.Domain/
COPY App.DTO/. ./App.DTO/
COPY App.Resources/. ./App.Resources/
COPY App.Test/. ./App.Test/

COPY WebApp/. ./WebApp/

RUN dotnet publish -c Release -o out

# tekita uus image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 8080
COPY --from=build /app/out ./
ENV ConnectionStrings:DefaultConnection="Host=host.docker.internal;Port=5432;Database=battlebrushprogress;Username=admin;Password=steady123"
ENTRYPOINT ["dotnet", "WebApp.dll"]

# Testimiseks lokaalselt
# docker build -t webapp .
# docker run --name webapp_docker --rm -it -p 8888:8080 webapp
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /WebApi

EXPOSE 80
EXPOSE 1996

#COPIAR ARCHIVO DEL PROYECTO
COPY ["Softtek.Service/Softtek.Service.csproj", "Softtek.Service/"]
RUN dotnet restore

#copiar el resto 
COPY . .
RUN dotnet publish -c Realese -o public


#contruir la imagen docker
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /WebApi
COPY --from=build /WebApi/public .
ENTRYPOINT ["dotnet","Softtek.Service.dll"]
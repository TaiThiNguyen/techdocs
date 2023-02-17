FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
LABEL maintainer="elvia@elvia.no"

WORKDIR /app
COPY . .
RUN dotnet publish \
    ../src/TestApi/TestApi.csproj \
    --configuration Release \
    --output ./out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
LABEL maintainer="elvia@elvia.no"

# Fikser CVE-2022-1292
USER root
RUN apt-get update
RUN apt-get install openssl -y

# https://aka.ms/dotnet-missing-libicu
#RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Workaround
# crit: Microsoft.AspNetCore.Server.Kestrel[0]
#       Unable to start Kestrel.
# System.Net.Sockets.SocketException (13): Permission denied
# https://github.com/dotnet/aspnetcore/issues/4699
ENV ASPNETCORE_URLS=http://*:8080

WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TestApi.dll"]

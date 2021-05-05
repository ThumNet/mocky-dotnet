# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-alpine AS build
WORKDIR /src
COPY Mocky.API/*.csproj ./
RUN dotnet restore "./Mocky.API.csproj" --runtime alpine-x64

# copy everything else and build app
COPY Mocky.API/. .
RUN dotnet publish "./Mocky.API.csproj" -c release -o /app \
    --no-restore \
    --runtime alpine-x64 \
    --self-contained true \
    /p:PublishTrimmed=true \
    /p:PublishSingleFile=true

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine
WORKDIR /app
EXPOSE 80
COPY --from=build /app ./
ENTRYPOINT ["./Mocky.API"]
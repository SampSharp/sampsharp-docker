FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY src/* ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM ghcr.io/sampsharp/sampsharp-docker:6.0.3
WORKDIR /samp
COPY --from=build-env /app/out ./gamemode

# Install SA-MP server with pawnctl
COPY pawn.json .
RUN sampctl package ensure

# Because these gamemodes were not created by pawnctl, we need to copy them after sampctl has initialized. In a future version of SampSharp
# the empty gamemode and filterscript will automatically be written to the corresponding directory if they are missing.
COPY gamemodes ./gamemodes
COPY filterscripts ./filterscripts

ENTRYPOINT ["sampctl", "package", "run"]
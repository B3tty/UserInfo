FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /app
EXPOSE 80

# Copy sln and restore
COPY *.sln ./
RUN dotnet restore

# Copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out


# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/src/UserInfo.Api/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet UserInfo.Api.dll

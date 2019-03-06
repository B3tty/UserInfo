# MadKudu

## Pre Requisites

Download and install the .NET Core SDK from [.NET Downloads](https://dotnet.microsoft.com/download).

## Run the app

> dotnet publish

Should output something like this

``` Microsoft (R) Build Engine version 15.9.20+g88f5fadfbe pour .NET Core
Copyright (C) Microsoft Corporation. Tous droits réservés.

  Restauration des packages pour src/UserInfo.Api.csproj...
  Génération du fichier MSBuild src/obj/UserInfo.Api.csproj.nuget.g.props.
  Restauration effectuée dans 1,25 sec pour src/UserInfo.Api.csproj.
  UserInfo.Api -> src/bin/Debug/netcoreapp2.0/UserInfo.Api.dll
  UserInfo.Api -> src/bin/Debug/netcoreapp2.0/publish/
  ```

  > dotnet src/bin/Debug/netcoreapp2.0/publish/UserInfo.Api.dll

  `http://localhost:5000/swagger/` should now display the endpoints (also available on respectively `http://localhost:5000/page` and `http://localhost:5000/user/{userId}`)
# MadKudu

## Running the app

### With the .NET Core SDK

Download and install the .NET Core SDK from [.NET Downloads](https://dotnet.microsoft.com/download).

> dotnet publish -c Release -o out

> dotnet src/out/UserInfo.Api.dll

### With Docker

>docker build -t mk .

> docker run --rm -it -p 5000:5000 mk

## Playing with the app

`http://localhost:5000/swagger/` should now display the endpoints (also available on respectively `http://localhost:5000/page` and `http://localhost:5000/user/{userId}`)

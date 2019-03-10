# User Info API

## Running the app on your computer

### With the .NET Core SDK

Download and install the .NET Core SDK from [.NET Downloads](https://dotnet.microsoft.com/download).

> dotnet publish -c Release -o out

> dotnet src/UserInfo.Api/out/UserInfo.Api.dll

### With Docker

The cached version is the one chosen from production because of Heroku deployment, but the Cassandra version would be a better choice for a real production environment.

#### Cached version

> docker build -t mk .

> docker run --rm -it -p 5000:5000 -e ASPNETCORE_ENVIRONMENT="Production" mk

#### Simple Cassandra version

> docker run -p 9042:9042 --name mk-cassandra -d cassandra:latest

> docker run --rm -it -d -p 5000:5000 -e ASPNETCORE_ENVIRONMENT="local" --link mk-cassandra:cassandra mk

## Deploy on Heroku

Install [Docker](https://www.docker.com/get-started)

``` sh
docker build -t mk .

# Be sure to have a heroku account, that the app is created there, and that you have Heroku CLI installed.
# 'mk-bettym' is the name of the heroku app

heroku login
heroku container:login
docker tag mk registry.heroku.com/mk-bettym/web
heroku container:push web -a mk-bettym
# OR docker push registry.heroku.com/mk-bettym/web
heroku container:release web -a mk-bettym
```

Re-Release quickly:

```sh
docker build -t mk .
heroku container:push web -a mk-bettym
heroku container:release web -a mk-bettym
```

## Accessing the API

* Local version

  * <http://localhost:5000/swagger/>
  * <http://localhost:5000/page>
  * <http://localhost:5000/user/{userId}>

* Heroku version

  * <https://mk-bettym.herokuapp.com/swagger/>
  * <https://mk-bettym.herokuapp.com/page>
  * <https://mk-bettym.herokuapp.com/user/{userId}>

# User Info API

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

## Deploy on Heroku

Install [Docker](https://www.docker.com/get-started)

``` sh
docker build -t mk .

# Be sure to have a heroku account, that the app is created there, and that you have Heroku CLI installed.

heroku login
heroku container:login
docker tag mk registry.heroku.com/mk-bettym/web
heroku container:push web -a mk-bettym
# OR docker push registry.heroku.com/mk-bettym/web
heroku container:release web -a mk-bettym
```


Re-Release quickly:

```
docker build -t mk .
heroku container:push web -a mk-bettym
heroku container:release web -a mk-bettym
```
Then go to https://mk-bettym.herokuapp.com/swagger/
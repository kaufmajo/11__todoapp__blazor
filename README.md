# ToDo-List

## App-Setup

### Dotnet new 

<https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new>

### .env

<https://dusted.codes/dotenv-in-dotnet>
<https://docs.docker.com/compose/how-tos/environment-variables/set-environment-variables/>

### create project

```ps
$ dotnet new blazor --output TodoList --language "C#" --use-program-main
```

### Git

<https://education.github.com/git-cheat-sheet-education.pdf>

create .gitignore file

```ps
$ dotnet new gitignore
```

```ps
$ git init
$ git add .
$ git commit -m "Initial commit"
```

Create dev branch

```ps
$ git checkout -b dev-zok
```

Push local branch to remote (if remote repository is already existing)

```ps
$ git checkout -b <branch>  # checkout a new branch

$ git push -u origin <branch> # git will set up the tracking information during the push "-u / --set-upstream"
```

Merge dev branch into main branch

```ps
(on branch development)
$ git merge master

(resolve any merge conflicts if there are any)
$ git checkout master

(there won't be any conflicts now)
$ git merge development or $ git merge --no-ff development
```

Another dev workflow looks like this:

One of my co-workers doesn't like having to switch branches so much and stays on the development branch with something similar to the following all executed from the development branch.

The first line makes sure he has any upstream commits that have been made to master since the last time updated his local repository.
The second pulls those changes (if any) from master into development.
The third pushes the development branch (now fully merged with master) up to origin/master.

```ps
$ git fetch origin master    
$ git merge master    
$ git push origin development:master
```

Bedeutung der letzen Befehlszeile:
git push
→ Du willst Änderungen (Commits) von deinem lokalen Repository in ein entferntes Repository hochladen (also „pushen“).

origin
→ Das ist der Name des Remote-Repositories. Standardmäßig heißt das Remote, das du beim Klonen bekommst, „origin“.

development:master
→ Das bedeutet:
→ Nimm den lokalen Branch development
→ und push ihn in den Remote-Branch master (also im origin-Repo).

### Mysql / MariaDB

<https://mysqlconnector.net/overview/installing/>

```ps
$ dotnet add package MySqlConnector
```

<https://github.com/DapperLib/Dapper>

Learn dapper: <https://www.learndapper.com/>

```ps
$ dotnet add package Dapper --version 2.1.66
```

### Hot reload command

run within project folder:

```ps
dotnet watch
```

## Docker

### with dockerfile

#### Create a shared network
```ps
$ docker network create app11_network
```

#### Mariadb - build and run

```ps
$ docker build --no-cache --tag mariadb_image --file mariadb.dockerfile .
$ docker run --env-file ./.env --rm --network=app11_network -p 3306:3306 --name mariadb_container --volume .\Data\mariadb:/var/lib/mysql mariadb_image
```

#### Phpmyadmin - build and run

```ps
$ docker build --no-cache --tag phpmyadmin_image --file phpmyadmin.dockerfile .
$ docker run --env-file ./.env --rm --network=app11_network -p 8082:80 --name phpmyadmin__container phpmyadmin_image
```

### with docker compose

build images and start containers

```ps
$ docker compose --env-file ./.env up
```

stop and remove containers

```ps
$ docker compose down
```

#### Misc

remove builder cache

```ps
$ docker builder prune
```

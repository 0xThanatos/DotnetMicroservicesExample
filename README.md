# Example Microservices - .NET Core 6.0

- Product Service
- Command Service

## .NET Core build a project

```
$ dotnet build
```

## Restore project dependencies

```
$ dotnet restore
```

## Initial migration

```
$ dotnet ef migrations add initialmigration
```

## Run Development Server

```
$ dotnet run
```

---

## Build Docker Image

```
$ docker build -t {DOCKER_HUB_USERNAME}/example-service .
```

## Push Docker Image to Docker Hub

```
$ docker push {DOCKER_HUB_USERNAME}/example-service
```

---

## Kubernetes create secret

```
$ kubectl create secret generic mssql --from-literal=SA_PASSWORD="P@ssw0rd"
```

## Kubernetes apply files

```
$ cd k8s
$ kubectl apply -f .
```

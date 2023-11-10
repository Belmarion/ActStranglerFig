# Api Gateway

## Proposito
Se pretende redireccionar el api monolitica y la api nueva, con el proceso por la api gateway sin afectar otros sitemas 
hasta que se encuentre estable la migración paulatina de los metodos correspodneintes de cada uno que dependen del servicio

## Comandos para desplegar a través de Docker

### Construcción de la imagen
```Docker
docker build -t gateway -f Dockerfile .
```

### Creación del nuevo Contenedor
```
docker create --name gateway gateway
```

### Listar el Contenedor creado anteriormente
```
docker ps -a
```

### Iniciar la nueva instancia apartir de la imagen en modo desasociado con la especificación de puerto interno y saliente
```
docker run -d --name ApiGateway -p 8080:8080 gateway
```



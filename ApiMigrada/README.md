# Api Migrada

## Propisito
Esta es la Api Migrada del procesamiento de la libreria de KML y GeoJson
## Comandos para desplegar a través de Docker

### Construcción de la imagen
```
docker build -t geokml -f Dockerfile .
```

### Creación del nuevo Contenedor
```
docker create --name geokml geokml
```
### Listar el Contenedor creado anteriormente
```
docker ps -a
```

### Iniciar la nueva instancia apartir de la imagen en modo desasociado con la especificación de puerto interno y saliente
```
docker run -d --name ApiGeoKml -p 8081:8081 geokml
```




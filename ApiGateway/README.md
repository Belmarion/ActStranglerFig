# Api Gateway

## Proposito
Se pretende redireccionar el api monolitica y la api nueva, con el proceso por la api gateway sin afectar otros sitemas 
hasta que se encuentre estable la migración paulatina de los metodos correspodneintes de cada uno que dependen del servicio

## Comandos para desplegar a través de Docker

### Crear Red Interna entre Containers
el nombre de la red se creara con el nombre "mi-red-containers"
````
docker network create mi-red-containers

````

### Construcción de la imagen
```
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
docker run -d --network=mi-red-containers --name apiagateway -p 8080:8080 gateway
```

### Verificación de la red interna creada
inspecciono las ips asignadas dentro de mi red para poder realizar la modificación
````
docker network inspect mi-red-containers
````

### Modifiación de apuntamiento
accedemos al bash de Docker despues del -it es el nombre del Container en mi caso es "apiagateway"
````
docker exec -it apiagateway /bin/bash
````
![image](https://github.com/Belmarion/ActStranglerFig/assets/63727266/c76846bc-fbff-4431-8c1a-c4937905da64)
Luego procederemos a buscar el archivo listamos el directorio
````
ls
````
![image](https://github.com/Belmarion/ActStranglerFig/assets/63727266/98523ad3-3e3c-42c7-b927-2583e9e119f1)

Ahora procederemos a modificar el archivo:
```
nano appsettings.json
```
> **Importante: <br>**
> en caso que al ejecutar el comando anteriror genere lo siguiente:
>```
>root@d6ee52edd8f5:/app# nano appsettings.json
>bash: nano: command not found
>```
>Procederemos a instalar nano con el siguiente comando:
>```
>apt update
>apt install nano
>```
>una vez termiando podemos volver a ejecutar el comando
>```
>nano appsettings.json
>```
![image](https://github.com/Belmarion/ActStranglerFig/assets/63727266/2f97a9eb-09be-44e0-b1e6-d889cdf77f6a)

Modificamos los Endpoint con las direcciones internas del la red que consultamos con el comando
````
docker network inspect mi-red-containers
````
![image](https://github.com/Belmarion/ActStranglerFig/assets/63727266/66009fed-8d76-4267-9d70-d688030510a3)

Deberia quedar algo como lo siguiente:
![image](https://github.com/Belmarion/ActStranglerFig/assets/63727266/3137c70f-afa3-40cd-9dc4-ef8c0940390b)

luego con presionamos "Ctrl + o" para escribirlo y luego "Enter"
![image](https://github.com/Belmarion/ActStranglerFig/assets/63727266/cdbe6fae-94c2-4c7e-bcb9-57d88c108d3c)

Luego precionamos "Ctrl + x" para salir del editor y luego escribiremos "exit" y presionaremos "Enter"
![image](https://github.com/Belmarion/ActStranglerFig/assets/63727266/32024b31-fa8f-4afd-b10d-96f2875dfdba)

ahora ejecutamos el comando:
```
docker restart apiagateway
```

### Probar sin implementarlo en Docker con los puertos establecidos
Debe ejecutar las 3 apis (ApiMigrada, ApiMonolitica y la Apigateway) y cambiar el "appsettings.json" correspondientes a los Endpoint con su respectivo protocolo y puerto
en el parametro "DownstreamPath"
````
{
  "Services": {
    "UniSabana.ApiLibreriaKml": {
      "DownstreamPath": "http://localhost:8081"
    },
    "ApiMonolitica": {
      "DownstreamPath": "http://localhost:8082"
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

````
### Implementación con un DNS con certificado no seguro
Para poder ejecutar las Apis con un DNS con certificado no valido TLS o SSL, se debe agregar a los archivos
"ocelot.EndPoint.*.json" en este caso seria "ocelot.EndPoint.ApiMonolitica.json" se debe agregar la linea:
````
"DangerousAcceptAnyServerCertificateValidator": true
````
deberia verse como el siguiente:
````
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/{everything}",
      "ServiceName": "ApiMonolitica",
      "UpstreamPathTemplate": "/ApiMonolitica/api/{everything}",
      "UpstreamHttpMethod": [ "Post", "Get", "Put", "Delete", "Patch" ],
      "SwaggerKey": "ApiMonolitica",
      "DangerousAcceptAnyServerCertificateValidator": true
    }
  ]
}
````





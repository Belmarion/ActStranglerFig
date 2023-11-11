# Api Gateway

## Proposito
Se pretende redireccionar el api monolitica y la api nueva, con el proceso por la api gateway sin afectar otros sitemas 
hasta que se encuentre estable la migración paulatina de los metodos correspodneintes de cada uno que dependen del servicio

## Comandos para desplegar a través de Docker

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
docker run -d --name ApiGateway -p 8080:8080 gateway
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





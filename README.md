# TestEcommerce

Una plataforma web API para la gestión de ofertas de productos y administración de órdenes.

## Tabla de Contenidos

- [Descripción](#descripción)
- [Requisitos Previos](#requisitos-previos)
- [Instalación](#instalación)
  - [Base de Datos](#base-de-datos)
  - [Backend](#backend)
- [Servicios en Azure](#servicios-en-azure)

## Descripción

Este proyecto está desarrollado en .NET 8.0 utilizando una arquitectura de microservicios. Se han creado tres servicios independientes:

1. **ProductCatalog**: Gestiona la información de los productos.
2. **OrderManagement**: Administra las órdenes y la cantidad de productos asociados.
3. **Identity**: Servicio de autenticación y autorización.

Además, se implementó un **API Gateway** para facilitar la comunicación entre los servicios.

### Servicios implementados:

- **ProductCatalog**: Gestión de productos.
- **OrderManagement**: Gestión de órdenes.
- **Identity**: Autenticación de usuarios.
- **API Gateway**: Orquesta las peticiones entre los servicios.

Los servicios están desplegados en Azure y se pueden probar a través de las siguientes URLs:

- [Servicio de Autenticación (Identity)](https://ts-autentication-bwhsgxducwfnetdh.canadacentral-01.azurewebsites.net/swagger/index.html)
- [Servicio de Gestión de Órdenes (OrderManagement)](https://ts-ordermanagement-fqb3ctg5gweabtc9.canadacentral-01.azurewebsites.net/swagger/index.html)
- [Servicio de Catálogo de Productos (ProductCatalog)](https://ts-productcatalog-hmewhvdud2akgkc7.canadacentral-01.azurewebsites.net/swagger/index.html)
- [API Gateway](https://ts-apigateway-cjb0dvhceafka0fg.canadacentral-01.azurewebsites.net/swagger/index.html)

## Requisitos Previos

- [.NET SDK](https://dotnet.microsoft.com/download) (versión recomendada: 8.0 o superior)

## Instalación

### Clonar el repositorio

Clona el repositorio del proyecto:

  ```bash
  git clone https://github.com/cruzrom21/TestEcommerce.git
  ```

### Base de Datos

1. Navega a la carpeta de la base de datos:
    ```bash
    cd Database
    ```

2. Ejecutar scripts para crear las bases de datos.

    - ScriptIdentityDB.sql
    - ScriptOrderDB.sql
    - ScriptIdentityDB.sql



### Backend

Se recomienda abrir el proyecto en Visual Studio.

1. Navegar a la carpeta raiz, donde se encuntra el archivo TestEcommerce.sln
    ```bash
    cd ./carpeta_raiz
    ```

2. Restaura las dependencias del proyecto:
    ```bash
    dotnet restore
    ```

o en Visual Studio, click derecho en la solicion y "Restaurar paquetes de NuGet"

3. Configura la ruta de la base de datos en cada microservicio:
   
    - Abre el archivo `appsettings.json`.
    - Busca la sección `ConnectionStrings`.
    - Cambia la ruta de la base de datos.
  
Deberia verse de esta forma:
  ```json
  {
      "ConnectionStrings": {
      "Connection": "Server=your_server_name;Database=your_database_name;Trusted_Connection=True;TrustServerCertificate=True"
      }
  }
  ```
    
## Servicios en Azure

- [Servicio de Autenticación (Identity)](https://ts-autentication-bwhsgxducwfnetdh.canadacentral-01.azurewebsites.net/swagger/index.html)
- [Servicio de Gestión de Órdenes (OrderManagement)](https://ts-ordermanagement-fqb3ctg5gweabtc9.canadacentral-01.azurewebsites.net/swagger/index.html)
- [Servicio de Catálogo de Productos (ProductCatalog)](https://ts-productcatalog-hmewhvdud2akgkc7.canadacentral-01.azurewebsites.net/swagger/index.html)
- [API Gateway](https://ts-apigateway-cjb0dvhceafka0fg.canadacentral-01.azurewebsites.net/swagger/index.html)

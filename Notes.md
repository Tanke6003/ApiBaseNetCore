### Application
- Carpeta que contiene la lógica de la aplicación, como interfaces y servicios.
    - **Interfaces**: Contiene interfaces para los servicios de la aplicación.
        - Las interfaces son contratos que definen los métodos que deben implementar las clases que las implementan.
    - **Services**: Contiene las implementaciones concretas de los servicios.
        - Los servicios son clases que contienen la lógica de la aplicación y se utilizan para realizar operaciones en la base de datos, como crear, leer, actualizar y eliminar registros.

### Domain
- Carpeta que contiene las clases de dominio y las interfaces de los repositorios.
    - **Dtos**: Contiene los Data Transfer Objects (DTOs) utilizados en la comunicación entre capas.
        - Los DTOs son clases que se utilizan para transferir datos entre capas de la aplicación.

### Infrastructure
- Carpeta que contiene la lógica de infraestructura, como implementaciones concretas de repositorios y plugins.
    - **Plugins**: Contiene las implementaciones concretas de los plugins.
        - Los plugins son clases que se utilizan para realizar operaciones específicas, como enviar correos electrónicos o generar tokens de autenticación.
    - **Repositories**: Contiene las implementaciones concretas de los repositorios.
        - Los repositorios son clases que se utilizan para interactuar con la base de datos y realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en los registros.
    - **Interfaces**: Contiene las interfaces de los repositorios, plugins y otros componentes de Infrastructure.
        - Las interfaces son contratos que definen los métodos que deben implementar las clases que las implementan.

### Presentation
- Carpeta que contiene la capa de presentación de la aplicación, como controladores de API.
    - **Controllers**: Contiene los controladores de la aplicación.
        - Los controladores son clases que se utilizan para manejar las solicitudes HTTP y devolver respuestas a los clientes.

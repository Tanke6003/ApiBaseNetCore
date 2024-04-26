### Application
- Carpeta que contiene la lógica de la aplicación, como interfaces y servicios.
    - **Interfaces**: Contiene interfaces para los servicios de la aplicación.
    - **Services**: Contiene las implementaciones concretas de los servicios.

### Domain
- Carpeta que contiene las clases de dominio y las interfaces de los repositorios.
    - **Dtos**: Contiene los Data Transfer Objects (DTOs) utilizados en la comunicación entre capas.

### Infrastructure
- Carpeta que contiene la lógica de infraestructura, como implementaciones concretas de repositorios y plugins.
    - **Plugins**: Contiene las implementaciones concretas de los plugins.
    - **Repositories**: Contiene las implementaciones concretas de los repositorios.
    - **Interfaces**: Contiene las interfaces de los repositorios, plugins y otros componentes de Infrastructure.

### Presentation
- Carpeta que contiene la capa de presentación de la aplicación, como controladores de API.
    - **Controllers**: Contiene los controladores de la aplicación.

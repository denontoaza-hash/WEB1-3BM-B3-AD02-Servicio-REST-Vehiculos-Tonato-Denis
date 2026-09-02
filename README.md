**Vehículos REST**



**Descripción**



Proyecto desarrollado para la asignatura Programación Web I.

El proyecto implementa un servicio web REST para la gestión de vehículos utilizando .NET, SQL Server y Entity Framework Core.

El servicio permite realizar operaciones de consulta, registro, actualización y eliminación de vehículos mediante una API REST.



**Tecnologías utilizadas**



\- C#

\- .NET

\- API REST

\- Entity Framework Core

\- SQL Server

\- Postman

\- Visual Studio



**Estructura del repositorio**



VehiculosREST/

│

├── VehiculosREST.slnx

│

├── VehiculosREST/

│   └── Proyecto .NET

│

├── SQL SERVER/

│   └── VehiculosRESTB.sql

│

├── POSTMAN/

│   └── VehiculosRESTB.postman\_collection.json

│

├── README.md



***Instrucciones de uso***

**1. Crear la base de datos**



Abra SQL Server Management Studio y conéctese a la instancia local de SQL Server.



Ejecute el archivo ubicado en:

SQL SERVER/VehiculosRESTB.sql



El script creará la base de datos:



&#x20;VehiculosRESTB



La base de datos contiene las tablas principales:



\- Categoria

\- Vehiculo

\- Mantenimiento



Estas tablas permiten almacenar la información relacionada con los vehículos, sus categorías y sus mantenimientos.



**2. Configurar la conexión a la base de datos**



Antes de ejecutar el proyecto se debe revisar la cadena de conexión ubicada en:

VehiculosRESTB/appsettings.json



La cadena de conexión debe modificarse de acuerdo con la configuración local de SQL Server del equipo donde se ejecuta el proyecto.



Ejemplo de configuración:



&#x20; "ConnectionStrings": {

&#x20;   "VehiculosConnection": "Server=localhost\\\\SQLEXPRESS;Database=BD\_VehiculosSOAP;Trusted\_Connection=True;TrustServerCertificate=True;Encrypt=False;"

&#x20; }

}



(Nota: El nombre del servidor puede variar entre computadoras).



**3. Abrir el proyecto**



Abrir la solución:

VehiculosREST.slnx

utilizando Visual Studio .



Esperar a que Visual Studio restaure las dependencias necesarias del proyecto.



**4. Ejecutar el servicio REST**



Ejecutar el proyecto desde Visual Studio (se abrirá en el puerto configurado, por ejemplo http://localhost:5174).



**5. Importar la colección de Postman**



Abrir Cartero y seleccionar la opción:

Import



Importar el archivo ubicado en:

POSTMAN/VehiculosRESTB.postman\_collection.json



La colección contiene las peticiones REST estructuradas en formato XML para probar todas las operaciones del servicio.



**6. Ejecutar y comprobar el funcionamiento**



Las solicitudes REST se realizan utilizando diferentes métodos HTTP, dependiendo de la operación que se desea realizar.

URL Base del Servicio:  http://localhost:5174/api/Mantenimiento (ajustar según el puerto que asigna tu Visual Studio)



Métodos disponibles en la colección:



ObtenerMantenimientos: Lista todos los mantenimientos.



ObtenerMantenimiento: Consulta un mantenimiento específico por su identificador.



ObtenerMantenimientosPorVehiculo: Filtra los mantenimientos según el vehículo especificado.



AgregarMantenimiento: Registra un nuevo mantenimiento.



ActualizarMantenimiento: Modifica la información de un mantenimiento existente.



EliminarMantenimiento: Da de baja un mantenimiento del sistema.



**Orden de ejecución**



Para ejecutar correctamente el proyecto se recomienda seguir este orden:



Iniciar SQL Server

&#x20;       ↓

Ejecutar el script ubicado en SQL SERVER/VehiculosRESTB.sql

&#x20;       ↓

Verificar la base de datos y sus tablas

&#x20;       ↓

Revisar appsettings.json

&#x20;       ↓

Abrir VehiculosREST.slnx

&#x20;       ↓

Ejecutar el proyecto .NET en Visual Studio

&#x20;       ↓

Comprobar la URL y el puerto

&#x20;       ↓

Abrir Postman

&#x20;       ↓

Importar la colección desde POSTMAN/VehiculosRESTB.postman\_collection.json

&#x20;       ↓

Realizar las peticiones REST

&#x20;       ↓

Comprobar las respuestas



**Autor**

Estudiante: Denis Tonato

Asignatura: Programación Web I

Paralelo: Tercero B Matutina










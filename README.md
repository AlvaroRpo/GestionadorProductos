# GestionadorProductos
Prueba técnica gestionador de proyecto

Buenos días,

Para ejecutar correctamente el proyecto, se deben seguir los siguientes pasos:

1. Descargar el InsumoBD que se encuentra cargado en el GIT https://github.com/AlvaroRpo/GestionadorProductos/blob/3970b25ef80aec650475c8a1833fc0ce902b24ad/InsumoBD
2. Ejecutar este insumo en el servidor SQL, para mi caso, el servidor se llama HOME y no tiene usuario o contraseña
3. El proyecto tiene 2 capas, la primera es la capa del back, construída en "ASP.NET Core Web API" (.NET 8.0), la segunda es la capa del front construída en "Aplicación web de ASP.NET Core" (.NET 8.0)
4. El proyecto se puede descargar desde https://github.com/AlvaroRpo/GestionadorProductos.git (rama master) o desde el visual studio con la url del proyecto
5. En el proyecto GestionadorProductosBack, appsettings.json, existe una llave llamada "CadenaSQL", en esta se debe configurar el servidor del sql server, en caso de ser SQL express, o en caso de tener usuario y contraseña se debe dejar configurado en este archivo
6. Para el proyecto GestionadorProductos (el front), Program.cs, se debe tener certeza de que la url del proyecto de los servicios esté configurada correctamente (url y puerta de enlace) en client.BaseAddress

Eso sería toda la configuración o pasos anteriores a la ejecución del proyecto, quedo atento a cualquier duda, mil gracias.

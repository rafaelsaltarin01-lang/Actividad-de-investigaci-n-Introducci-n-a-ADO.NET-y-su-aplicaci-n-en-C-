# Catálogo de Videojuegos con ADO.NET y SQLite

Aplicación de consola desarrollada en C# (.NET 8) como parte de la actividad práctica de fundamentos de acceso a datos con ADO.NET y bases de datos SQLite.

## Descripción del Proyecto
El programa demuestra el flujo completo de acceso a datos utilizando el proveedor oficial `Microsoft.Data.Sqlite`:
1. **Conexión:** Establece una conexión administrada hacia un archivo local (`catalogo_juegos.db`) mediante `SqliteConnection`.
2. **Definición de Esquema:** Crea automáticamente una tabla relacional (`Videojuegos`) con cuatro columnas (`Id`, `Titulo`, `Genero`, `AnioLanzamiento`) si no existe previamente.
3. **Inserción Segura:** Inserta registros de ejemplo utilizando comandos parametrizados (`SqliteParameter`) para prevenir inyecciones SQL.
4. **Consulta de Datos:** Lee los registros almacenados de forma secuencial y de alto rendimiento utilizando `SqliteDataReader`.
5. **Gestión de Recursos:** Aplica bloques `using` para garantizar la liberación determinista de las conexiones y comandos.

## Requisitos Previos
* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado en tu equipo.

## Instrucciones de Ejecución

1. Clona este repositorio o descarga los archivos fuente:
   ```bash
   git clone https://github.com/tu-usuario/tu-repositorio.git
   cd tu-repositorio
   ```

2. Restaura las dependencias y compila el proyecto:
   ```bash
   dotnet restore
   ```

3. Ejecuta la aplicación:
   ```bash
   dotnet run
   ```

## Estructura del Código
* `Program.cs`: Contiene la lógica principal, la definición de la cadena de conexión, la creación de la tabla, la inserción parametrizada y la lectura de registros en formato de tabla por consola.
* `CatalogoVideojuegosAdoNet.csproj`: Archivo de proyecto .NET con la referencia al paquete `Microsoft.Data.Sqlite`.

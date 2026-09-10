# Biblioteca — Autores y Libros

Proyecto ASP.NET Core Razor Pages (.NET 10) con Entity Framework Core y SQLite.

## Requisitos del enunciado

- Modelos `Autor` y `Libro` con relación uno a muchos
- Registro y listado de autores
- CRUD de libros (alta, listado, edición y eliminación)
- Select de autores al registrar/editar libros
- `[BindProperty]`, `OnGet`, `OnPost` y handler `asp-page-handler="Eliminar"` → `OnPostEliminar`
- Validaciones: nombre de autor obligatorio; título obligatorio; año entre 1450 y el año actual; autor válido
- Sin scaffolding automático
- Base de datos SQLite

## Cómo abrir en Visual Studio

1. Abrir la carpeta `BibliotecaAutoresLibros`
2. Abrir el archivo `BibliotecaAutoresLibros.slnx` (o el `.csproj`)
3. Pulsar F5 para ejecutar

## Cómo ejecutar desde terminal

```powershell
cd BibliotecaAutoresLibros
dotnet restore
dotnet ef database update
dotnet run
```

La base SQLite `biblioteca.db` se crea automáticamente al iniciar la aplicación.

## Cómo comprimir el proyecto

Desde la carpeta padre (excluyendo `bin` y `obj`):

```powershell
# PowerShell (Windows)
Compress-Archive -Path BibliotecaAutoresLibros -DestinationPath BibliotecaAutoresLibros.zip -Force
```

O en el Explorador de Windows: clic derecho sobre la carpeta → Enviar a → Carpeta comprimida.

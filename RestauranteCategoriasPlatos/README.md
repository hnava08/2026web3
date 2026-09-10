# Restaurante — Categorías y Platos

Proyecto ASP.NET Core Razor Pages (.NET 10) con Entity Framework Core y SQLite.

## Requisitos del enunciado

- Modelos `Categoria` y `Plato` con relación uno a muchos
- Registro y listado de categorías
- CRUD de platos (alta, listado, edición y eliminación)
- Select de categorías al registrar/editar platos
- `[BindProperty]`, `OnGet`, `OnPost` y handler `asp-page-handler="Eliminar"` → `OnPostEliminar`
- Validaciones: nombre de categoría obligatorio; nombre de plato obligatorio; precio > 0; categoría válida
- Sin scaffolding automático
- Base de datos SQLite

## Cómo abrir en Visual Studio

1. Abrir la carpeta `RestauranteCategoriasPlatos`
2. Abrir el archivo `RestauranteCategoriasPlatos.slnx` (o el `.csproj`)
3. Pulsar F5 para ejecutar

## Cómo ejecutar desde terminal

```powershell
cd RestauranteCategoriasPlatos
dotnet restore
dotnet run
```

La base SQLite `restaurante.db` se crea automáticamente al iniciar.

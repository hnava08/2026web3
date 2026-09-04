# 2026web3

Aplicacion ASP.NET Core Razor Pages con .NET 10.

## Entity Framework Core

El proyecto esta preparado para trabajar con Entity Framework Core 10 y SQL Server.

Paquetes instalados en el proyecto:

- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.Tools`

El `ApplicationDbContext` esta en `Data/ApplicationDbContext.cs` y se registra en `Program.cs` usando la cadena `ConnectionStrings:DefaultConnection`.

La cadena de conexion vive en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TODO_SQL_SERVER;Database=2026web3;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Cambiar `TODO_SQL_SERVER` cuando ya se sepa a que servidor SQL Server debe apuntar la aplicacion.

## Comandos de instalacion

Ejecutar desde la raiz del proyecto:

```powershell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 10.*
dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.*
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 10.*
```

Instalar la herramienta de EF Core si aun no existe:

```powershell
dotnet tool install --global dotnet-ef --version 10.*
```

Actualizar la herramienta si ya estaba instalada:

```powershell
dotnet tool update --global dotnet-ef --version 10.*
```

## Comandos de verificacion

```powershell
dotnet restore
dotnet ef --version
dotnet build
```

La version esperada de `dotnet-ef` para este proyecto es `10.x`.

## Migraciones

Cuando ya exista un `DbContext` configurado, crear una migracion inicial:

```powershell
dotnet ef migrations add InitialCreate
```

Aplicar migraciones a la base de datos:

```powershell
dotnet ef database update
```

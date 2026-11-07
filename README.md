# 📚 Sistema de Gestión de Biblioteca

ACA Final – **Programación Avanzada** · Aplicación de escritorio en **C# + Windows Forms + SQL Server**.

Permite administrar libros, autores, editoriales y usuarios, registrar préstamos y devoluciones con control de existencias, y consultar reportes de la biblioteca.

---

## ✨ Funcionalidades

| Módulo | Qué permite |
|---|---|
| **Inicio** | Pantalla de bienvenida con totales generales (libros, ejemplares, autores, editoriales, usuarios y préstamos). |
| **Libros** | CRUD completo, búsqueda por ISBN, título o autor, relación con autor y editorial, control de existencias. |
| **Autores** | CRUD completo. No permite duplicados ni eliminar autores que tengan libros. |
| **Editoriales** | CRUD completo. No permite duplicados ni eliminar editoriales que tengan libros. |
| **Usuarios** | CRUD completo con validación de documento único y formato del correo. |
| **Préstamos** | Registrar préstamo, registrar devolución, editar la fecha, eliminar y filtrar por estado (Prestado / Devuelto). |
| **Reportes** | 10 reportes: listados, préstamos activos/devueltos/historial, libros más prestados, libros sin existencias y resumen consolidado. |

### Reglas de negocio de los préstamos

1. El usuario y el libro seleccionados deben existir.
2. No se presta un libro sin existencias.
3. Un usuario no puede tener el mismo libro prestado dos veces a la vez.
4. Un usuario puede tener como máximo **3 préstamos activos**.
5. La fecha del préstamo no puede ser futura; la devolución no puede ser anterior al préstamo ni futura.
6. Al prestar se descuenta un ejemplar y al devolver se suma (en una **transacción SQL**, para no dejar datos a medias).

---

## 🧱 Arquitectura por capas

```
Presentación (Windows Forms)   Frm*.cs
        │
Lógica de negocio              Negocio/    → validaciones y reglas
        │
Acceso a datos                 Datos/      → consultas parametrizadas, transacciones
        │
Base de datos (SQL Server)     BaseDatos/Script_AcaBiblioteca.sql

Entidades/ (Persona, Autor, Usuario, Editorial, Libro, Prestamo) y Comun/ (mensajes y excepciones)
las usan todas las capas.
```

Los formularios **no contienen SQL**: llaman a las clases de `Negocio`, que validan y delegan en `Datos`.
Más detalle y diagramas en [`Documentacion.md`](Documentacion.md).

---

## 🛠️ Tecnologías

- C# / **.NET 10** (Windows Forms)
- **SQL Server** (probado con instancia local `SQL2022`, también sirve Express o LocalDB)
- `Microsoft.Data.SqlClient` y `FontAwesome.Sharp` (paquetes NuGet, se restauran solos)
- Git y GitHub

---

## 🚀 Cómo ejecutarlo

### 1. Requisitos
- Windows 10/11
- Visual Studio 2022/2026 con la carga de trabajo *Desarrollo de escritorio de .NET* y el **SDK de .NET 10**
- SQL Server (Express, Developer o LocalDB) + SSMS o Azure Data Studio

### 2. Crear la base de datos
1. Abre `BaseDatos/Script_AcaBiblioteca.sql` en SSMS.
2. Ejecútalo completo (F5). Crea la base `AcaBiblioteca`, las 5 tablas, las restricciones y los datos de prueba.

> ⚠️ El script **recrea las tablas**: si lo vuelves a ejecutar, se pierden los datos que hayas agregado.

### 3. Configurar la conexión
Por defecto se usa la instancia `.\SQL2022` con autenticación de Windows. Si la tuya es distinta, edita `AcaBiblioteca/AcaBiblioteca/conexion.config.json`:

```json
{
  "ConnectionString": "Server=.\\SQLEXPRESS;Database=AcaBiblioteca;Integrated Security=true;TrustServerCertificate=true;"
}
```

Ejemplos de `Server`: `.\SQLEXPRESS` · `(localdb)\MSSQLLocalDB` · `localhost`.
También se puede definir la variable de entorno `ACA_BIBLIOTECA_CONN` (tiene prioridad sobre el archivo).

### 4. Ejecutar
1. Abre `AcaBiblioteca/AcaBiblioteca.slnx` en Visual Studio.
2. Presiona **F5**.

---

## 📁 Estructura del repositorio

```
AcaBiblioteca/
├── README.md
├── Documentacion.md                  Documento técnico (entregable)
├── Documentacion/
│   ├── diagramas/                    Casos de uso, clases, MER, arquitectura (.mmd y .png)
│   └── capturas/                     Capturas de pantalla del sistema
├── BaseDatos/
│   └── Script_AcaBiblioteca.sql      Script de creación + datos de prueba
├── Actividad Semana 5/               Interfaces y códigos CRUD de la actividad previa
├── Plantilla Markdown/               Plantilla de la documentación
└── AcaBiblioteca/                    Solución de Visual Studio
    └── AcaBiblioteca/
        ├── Comun/                    Mensajes y ReglaNegocioException
        ├── Entidades/                Persona, Autor, Usuario, Editorial, Libro, Prestamo
        ├── Negocio/                  Reglas y validaciones
        ├── Datos/                    Conexión y acceso a SQL Server
        ├── Frm*.cs                   Formularios (presentación)
        └── conexion.config.json      Cadena de conexión
```

---

## 🗄️ Modelo de datos

`Autores (1)──(N) Libros (N)──(1) Editoriales` · `Usuarios (1)──(N) Prestamos (N)──(1) Libros`

Diagrama entidad-relación y diccionario de datos completos en [`Documentacion.md`](Documentacion.md#7-modelo-entidad-relación).

---

## 🖼️ Capturas

Las capturas del sistema están en [`Documentacion/capturas`](Documentacion/capturas) y en la sección 11 de la documentación.

---

## 🔀 Control de versiones

Se recomienda hacer commits pequeños y descriptivos, por ejemplo:

```
feat: agrega CRUD de autores
feat: registra préstamos con control de existencias
fix: corrige el botón de reportes que abría préstamos
docs: completa el diccionario de datos
```

---

## 👥 Integrantes

- Andrés Felipe Tejada Caraballo
- _[Agregar los demás integrantes del grupo]_

**Docente:** _[Nombre del docente]_ · **Institución:** CUN · **Año:** 2026

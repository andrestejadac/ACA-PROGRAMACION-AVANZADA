# ACA -- Programación Avanzada

# Sistema de Gestión de Biblioteca

------------------------------------------------------------------------

## PORTADA

**CORPORACION UNIFICADA NACIONAL DE EDUCACION SUPERIOR**

**INGENIERIA DE SISTEMAS / PROGRAMACION AVANZADA**

### ACA -- Programación Avanzada

### Sistema de Gestión de Biblioteca

**Presentado por:**\

ANDRES FELIPE TEJADA CARABALLO - 54465

SEBASTIAN CIFUENTES SILVA - 54463

CARLOS ERWIN HURTATIZ GOMEZ - 54463

**Docente:**\

**VERONICA CASTRO**

**Fecha:**\
Bogota, 30, Octubre  2026

------------------------------------------------------------------------

# CONTRAPORTADA

**Sistema de Gestión de Biblioteca**

Proyecto desarrollado como evidencia del curso de **Programación
Avanzada**, aplicando Programación Orientada a Objetos, base de datos
relacional, arquitectura por capas, operaciones CRUD, validaciones,
manejo de excepciones y conexión con SQL Server.

**Estudiantes:** Andres Felipe Tejada Caraballo
Sebastian Cifuentes Silva
Carlos Erwin Hurtatiz Gomez


**Programa:** Ingenieria de Sistemas

**Grupo:** 54465 - 54463

**Docente:** **Veronica Castro**

**Institución:** CORPORACION UNIFICADA NACIONAL DE EDUCACION SUPERIOR

**Año:** 2026

------------------------------------------------------------------------

# TABLA DE CONTENIDO



1.  Introducción
2.  Objetivos
    -   2.1 Objetivo general
    -   2.2 Objetivos específicos
3.  Planteamiento del problema
4.  Análisis de requerimientos
5.  Casos de uso
6.  Diagrama de clases
7.  Modelo entidad-relación
8.  Diccionario de datos
9.  Arquitectura del sistema
10. Explicación de los módulos desarrollados
11. Capturas de pantalla del sistema
12. Pruebas de funcionamiento
13. Conclusiones
14. Recomendaciones
15. Referencias bibliográficas

------------------------------------------------------------------------

# 1. INTRODUCCIÓN

El presente documento describe el desarrollo del Sistema de Gestión de Biblioteca, una aplicación de escritorio
cuyo propósito es facilitar la administración de los procesos de una biblioteca institucional: el registro de libros,
autores, editoriales y usuarios, el control de los préstamos y las devoluciones, y la consulta de información
mediante reportes.

El sistema fue desarrollado con C#, .NET 10, Windows Forms y SQL Server, aplicando los principios de la
Programación Orientada a Objetos y una arquitectura por capas (presentación, lógica de negocio, acceso a
datos y base de datos). Las consultas a la base de datos son parametrizadas, las operaciones críticas se
ejecutan dentro de transacciones y la información que ingresa el usuario se valida antes de almacenarse.

La aplicación permite gestionar libros, autores, editoriales, usuarios, préstamos y devoluciones, y genera diez
reportes de consulta. El código fuente se versionó con Git y se publicó en GitHub junto con el script SQL y esta
documentación.



------------------------------------------------------------------------

# 2. OBJETIVOS

## 2.1 Objetivo general

Desarrollar una aplicación de escritorio para la gestión integral de una biblioteca utilizando C#, Windows Forms y
SQL Server, que permita administrar libros, autores, editoriales y usuarios, gestionar préstamos y devoluciones, y
generar reportes mediante operaciones conectadas a una base de datos relacional, aplicando los principios de la
Programación Orientada a Objetos y una arquitectura por capas.


## 2.2 Objetivos específicos

-   Aplicar los principios de la Programación Orientada a Objetos (clases, constructores, encapsulamiento,
herencia y colecciones).
- Diseñar e implementar una base de datos relacional en SQL Server con claves primarias, foráneas y
restricciones de integridad.
- Implementar operaciones CRUD para libros, autores, editoriales y usuarios.
- Implementar el registro de préstamos y devoluciones manteniendo la coherencia de las existencias.
- Validar la información ingresada por el usuario y manejar las excepciones de forma controlada.
- Implementar una arquitectura por capas que separe la presentación, la lógica de negocio y el acceso a datos.
- Implementar un módulo de reportes para consultar la información de la biblioteca.
- Utilizar Git y GitHub como sistema de control de versiones.
- Documentar técnicamente el proyecto.


------------------------------------------------------------------------

# 3. PLANTEAMIENTO DEL PROBLEMA

## 3.1 Descripción del problema

Una institución educativa requiere administrar los procesos de su biblioteca. La gestión manual de libros, autores,
editoriales y usuarios, junto con el control de los préstamos y devoluciones, puede generar errores, información
duplicada, pérdida de datos y dificultad para saber qué libros están disponibles y quién los tiene.

Por esta razón se propone una aplicación de escritorio que centralice la información bibliográfica, administre a los
usuarios, gestione los préstamos y devoluciones y permita consultar la información mediante reportes,
garantizando la integridad y la consistencia de los datos almacenados.

## 3.2 Justificación

Un sistema de información para la biblioteca reduce los errores de registro, evita duplicados, mantiene
actualizadas las existencias de cada libro y permite conocer en cualquier momento el estado de los préstamos.
Además, la aplicación permite poner en práctica los conocimientos de Programación Orientada a Objetos, bases de
datos relacionales y arquitectura por capas vistos en el curso.

## 3.3 Alcance

El sistema permitirá:

-   Gestionar libros.
-   Gestionar autores.
-   Gestionar categorías.
-   Gestionar usuarios.
-   Registrar préstamos.
-   Registrar devoluciones.
-   Consultar disponibilidad.
-   Consultar historial de préstamos.
-   \[Agregar otras funcionalidades implementadas\].

### Fuera del alcance

El sistema de gestión de la biblioteca no incluirá las siguientes funcionalidades:

- Gestión de pagos, multas o cobros por retrasos en la devolución de libros.



- Compra, venta o adquisición de material bibliográfico.



- Consulta de libros en bibliotecas externas o bases de datos de otras instituciones.



- Préstamo de libros digitales o descarga de documentos electrónicos.



- Envío automático de notificaciones por correo electrónico o mensajes de texto.



- Integración con plataformas externas o sistemas de otras bibliotecas.



- Generación de códigos de barras o lectores RFID para identificar los libros.



- Administración de nómina o información financiera del personal de la biblioteca.

------------------------------------------------------------------------

# 4. ANÁLISIS DE REQUERIMIENTOS

## 4.1 Descripción general

El Sistema de Gestión de Biblioteca administra la información de libros, autores, editoriales y usuarios y controla
los procesos de préstamo y devolución, manteniendo la integridad de las relaciones entre libros, usuarios y préstamos.

## 4.2 Actores del sistema

  -----------------------------------------------------------------------
  Actor                               Descripción
  ----------------------------------- -----------------------------------
  **Bibliotecario / Administrador**  Único actor que usa la aplicación. Registra y mantiene libros, autores, editoriales y usuarios, registra préstamos y devoluciones y consulta los reportes.



  -----------------------------------------------------------------------

## 4.3 Requerimientos funcionales

  -----------------------------------------------------------------------
  Código                  Requerimiento           Descripción
  ----------------------- ----------------------- -----------------------
  RF01                    Gestionar libros        Registrar, consultar,
                                                  actualizar, eliminar y
                                                  buscar libros.

  RF02                    Gestionar autores       Registrar, consultar,
                                                  actualizar y eliminar
                                                  autores.

  RF03                    Gestionar categorías    Registrar, consultar,
                                                  actualizar y eliminar
                                                  categorías.

  RF04                    Gestionar usuarios      Registrar, consultar,
                                                  actualizar y eliminar
                                                  usuarios.

  RF05                    Registrar préstamos     Registrar préstamos y
                                                  actualizar la
                                                  disponibilidad de los
                                                  libros.

  RF06                    Registrar devoluciones  Registrar devoluciones,
                                                  calcular retrasos y
                                                  multa cuando aplique.

  RF07                    Realizar consultas      Consultar libros
                                                  disponibles, libros
                                                  prestados, historial y
                                                  usuarios con préstamos
                                                  activos.

  RF08                    Generar reportes        Permitir generar reportes
                                                  sobre los libros registrados, 
                                                  préstamos realizados, 
                                                  devoluciones, disponibilidad 
                                                  del inventario y actividad 
                                                  de los usuarios para facilitar 
                                                  el control y la administración 
                                                  de la biblioteca.
  -----------------------------------------------------------------------


## 4.4 Requerimientos no funcionales

  -----------------------------------------------------------------------
  Código                  Requerimiento           Descripción
  ----------------------- ----------------------- -----------------------
  RNF01                   Usabilidad              La interfaz debe ser
                                                  clara, sencilla y fácil
                                                  de utilizar.

  RNF02                   Validación              El sistema debe validar
                                                  la información
                                                  ingresada por el
                                                  usuario.

  RNF03                   Mantenibilidad          El código debe estar
                                                  organizado y
                                                  documentado.

  RNF04                   Arquitectura            El sistema debe
                                                  utilizar una
                                                  arquitectura por capas.

  RNF05                   Manejo de excepciones   Las operaciones deben
                                                  manejar errores de
                                                  forma controlada.

  RNF06                   Integridad de datos     La información debe
                                                  mantenerse consistente
                                                  en la base de datos.

  RNF07                   Consultas               Las consultas a la base
                          parametrizadas          de datos deben utilizar
                                                  parámetros.

  RNF08                   Seguridad              El sistema debe controlar 
                                                 el acceso mediante credenciales 
                                                 de usuario y contraseña, 
                                                 garantizando que únicamente 
                                                 las personas autorizadas 
                                                 puedan ingresar y realizar 
                                                 operaciones sobre la información 
                                                 de la biblioteca.
  -----------------------------------------------------------------------

## 4.5 Reglas de negocio

### RN01 -- Código único del libro

No se permitirá registrar dos libros con el mismo código.

### RN02 -- Datos obligatorios

No se permitirá almacenar registros con campos obligatorios vacíos.

### RN03 -- Usuario existente

No se podrá registrar un préstamo para un usuario inexistente.

### RN04 -- Libro existente

No se podrá registrar un préstamo para un libro inexistente.

### RN05 -- Disponibilidad

No se podrá prestar un libro cuando no existan ejemplares disponibles.

### RN06 -- Actualización de disponibilidad

Al registrar un préstamo, la disponibilidad del libro deberá
actualizarse.

### RN07 -- Devolución

Al registrar una devolución, la disponibilidad deberá actualizarse
nuevamente.

### RN08 -- Multa

La multa se calculará únicamente cuando exista retraso en la devolución.

### RN09 -- Préstamo activo

Un usuario no podrá registrar un nuevo préstamo del mismo libro si ya tiene un préstamo activo de ese ejemplar y no ha realizado su devolución.

------------------------------------------------------------------------

# 5. CASOS DE USO

## 5.1 Descripción

Los actores interactúan con el sistema de gestión de la biblioteca de acuerdo con las funciones y responsabilidades que desempeñan. Cada uno tiene acceso a diferentes funcionalidades que permiten administrar, consultar y mantener organizada la información.

1. Bibliotecario / Administrador

Es el actor principal del sistema y se encarga de realizar las operaciones administrativas. Puede registrar, consultar, modificar y eliminar libros, autores, categorías y usuarios. También gestiona los préstamos y las devoluciones, verifica la disponibilidad de los libros y consulta el historial de movimientos.

2. Usuario / Lector

Interactúa con el sistema principalmente para consultar la información de los libros. Puede buscar ejemplares por título, autor o categoría, verificar cuáles están disponibles y revisar su historial de préstamos y devoluciones.

3. Administrador de la base de datos

Se encarga de supervisar el almacenamiento de la información, realizar copias de seguridad, verificar la integridad de los datos y controlar los permisos de acceso para proteger la información de la biblioteca.

4. Desarrollador del sistema

Es responsable de implementar y mantener las funcionalidades de la aplicación. Configura la conexión con la base de datos, realiza pruebas, corrige errores y desarrolla mejoras para garantizar el correcto funcionamiento del sistema.

En general, la interacción entre los actores permite mantener actualizada la información de la biblioteca, facilitar el control de los préstamos y las devoluciones, y garantizar que los datos estén organizados y disponibles para su consulta.

## 5.2 Diagrama de casos de uso

![Diagrama de casos de uso](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Diagrama%20De%20Casos%20De%20Uso%20-%20Biblioteca%20.png)

## 5.3 Descripción de casos de uso

### CU01 -- Gestionar libros

**Actor principal:** Bibliotecario / Administrador

**Descripción:** Permite registrar, consultar, actualizar, eliminar y
buscar libros.

**Precondiciones:** - El usuario debe tener acceso al sistema. - La base de datos debe estar disponible.

**Flujo principal:** 1. El actor ingresa al módulo de libros. 2. El
sistema muestra los libros registrados. 3. El actor selecciona la
operación que desea realizar. 4. El sistema procesa la solicitud. 5. El
sistema muestra el resultado.

**Flujos alternativos:** 
- Si existen campos obligatorios vacíos, el sistema solicita completar la información.



- Si el código del libro ya está registrado, el sistema impide guardar el registro duplicado.



- Si el libro que se desea buscar no existe, el sistema informa que no se encontraron resultados.



- Si ocurre un error de conexión con la base de datos, el sistema muestra un mensaje de error.



- Si el actor intenta eliminar un libro que tiene préstamos activos, el sistema impide su eliminación.

**Postcondiciones:** 
- El libro queda registrado, actualizado o eliminado según la operación realizada.
- La información queda almacenada y organizada en la base de datos.
- El inventario de libros refleja los cambios realizados.
------------------------------------------------------------------------

### CU02 -- Registrar préstamo

**Actor principal:** Bibliotecario / Administrador

**Descripción:** Permite registrar el préstamo de uno o varios libros a
un usuario.

**Precondiciones:** - El usuario debe existir. - El libro debe
existir. - Debe existir disponibilidad.

**Flujo principal:** 1. Seleccionar usuario. 2. Seleccionar libro. 3.
Verificar disponibilidad. 4. Registrar préstamo. 5. Actualizar
disponibilidad. 6. Mostrar confirmación.

**Flujos alternativos:** - Usuario inexistente. - Libro inexistente. -
Libro sin disponibilidad. - Usuario con préstamo activo

**Postcondiciones:** - El préstamo queda registrado. - La disponibilidad
del libro queda actualizada.

------------------------------------------------------------------------

### CU03 -- Registrar devolución

**Actor principal:** Bibliotecario / Administrador

**Descripción:** Permite registrar la devolución de un libro prestado.

**Precondiciones:** - Debe existir un préstamo activo.

**Flujo principal:** 1. Seleccionar el préstamo. 2. Registrar la
devolución. 3. Calcular días de retraso. 4. Calcular multa cuando
corresponda. 5. Actualizar disponibilidad. 6. Actualizar el estado del
préstamo. 7. Mostrar confirmación.

**Flujos alternativos:**
- Si el usuario deja campos obligatorios vacíos, el sistema muestra un mensaje solicitando completar la información.


- Si el ISBN ya se encuentra registrado, el sistema informa que el libro ya existe.


- Si el año de publicación no tiene un formato válido, el sistema solicita corregirlo.


- Si ocurre un problema de conexión con SQL Server, el sistema muestra un mensaje de error y no registra la información.

**Postcondiciones:** 
- La devolución queda registrada. 
- El libro vuelvea estar disponible según corresponda.

------------------------------------------------------------------------

# 6. DIAGRAMA DE CLASES

## 6.1 Descripción

Las clases se organizan por responsabilidad: las entidades representan los datos del dominio, las clases de
negocio aplican las reglas y validaciones, las clases de datos ejecutan las consultas sobre SQL Server y los
formularios presentan la información.

## 6.2 Diagrama de clases

![Diagrama de Clases](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Diagrama%20De%20Clases%20-%20Biblioteca.png)

`![Diagrama de clases](ruta/al/diagrama-clases.png)`

## 6.3 Principales clases

  ----------------- --------------------------------------------------------
| Clase | Responsabilidad |
|---|---|
| `Persona` | Clase base con nombre y apellido; calcula `NombreCompleto`. |
| `Autor` | Hereda de `Persona`; agrega `IdAutor`. |
| `Usuario` | Hereda de `Persona`; agrega documento, teléfono y correo. |
| `Editorial` | Representa una editorial (id y nombre). |
| `Libro` | Representa un libro con su autor, editorial y existencias. |
| `Prestamo` | Representa un préstamo: usuario, libro, fechas y estado. |
| `LibroNegocio`, `AutorNegocio`, `EditorialNegocio`, `UsuarioNegocio` | Validan y coordinan el CRUD de cada entidad. |
| `PrestamoNegocio` | Reglas de préstamos y devoluciones (RN04–RN10). |
| `ReporteNegocio` | Catálogo de reportes y su generación. |
| `Validador` | Validaciones reutilizables (obligatorio, longitud, correo, números). |
| `LibroDatos`, `AutorDatos`, `EditorialDatos`, `UsuarioDatos` | Consultas parametrizadas de cada tabla. |
| `PrestamoDatos` | Préstamos y devoluciones con transacciones. |
| `ReporteDatos` | Consultas de solo lectura para los reportes. |
| `Conexion` | Crea las conexiones a SQL Server (cadena configurable). |
| `ErroresSql` | Traduce errores de SQL Server (duplicados, llaves foráneas) a mensajes claros. |
| `ReglaNegocioException` | Excepción propia para errores de validación y reglas de negocio. |
| `Mensajes` | Centraliza los cuadros de mensaje de la interfaz. |
| `Frm*` | Formularios de Windows Forms (presentación). |
  
  ----------------- --------------------------------------------------------
  ## 6.4 Aplicación de POO

Explicar cómo se aplicaron:

- **Clases y objetos**: cada entidad del dominio es una clase y los formularios crean objetos (new Autor(...) , new
Prestamo(...) ) que viajan entre las capas.

- **Constructores**: las entidades tienen un constructor vacío (para el mapeo desde la base de datos) y otro con
parámetros; es decir, hay sobrecarga de constructores. Autor y Usuario llaman al constructor base con :
base(nombre, apellido) .

- **Encapsulamiento y propiedades**: los datos se guardan en campos privados y se exponen por
propiedades; por ejemplo, Persona.Nombre elimina los espacios sobrantes al asignar el valor.

- **Métodos**: cada clase de negocio y de datos agrupa sus operaciones (Guardar , Actualizar , Eliminar , Registrar ,
Devolver …).

- **Colecciones**: los listados se manejan con List<T> (List<Libro> , List<Autor> , etc.) y se enlazan a los
DataGridView y ComboBox.

- **Herencia**: Autor y Usuario heredan de Persona , que concentra los atributos comunes (justificación de diseño:
evitar repetir nombre y apellido).

- **Organización de responsabilidades**: cada clase tiene una sola función (presentar, validar, acceder a
datos o representar un dato).


------------------------------------------------------------------------
# 7. MODELO ENTIDAD-RELACIÓN

## 7.1 Descripción

El modelo de datos tiene cinco tablas normalizadas hasta tercera forma normal: **Autores, Editoriales, Libros,
Usuarios y Préstamos**. Cada tabla tiene clave primaria, las relaciones se implementan con claves foráneas y los
campos que no se deben repetir tienen restricciones de unicidad.

## 7.2 Diagrama entidad-relación

![Diagrama Entidad Relación](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Diagramas%20Entidad%20Relacion.png)

`![Modelo entidad-relación](ruta/al/modelo-entidad-relacion.png)`

## 7.3 Relaciones principales

Describir las relaciones entre las entidades.


- Un autor puede tener muchos libros; cada libro tiene un autor (1:N).
- Una editorial puede publicar muchos libros; cada libro tiene una editorial (1:N).
- Un usuario puede realizar muchos préstamos; cada préstamo es de un usuario (1:N).
- Un libro puede ser prestado muchas veces (según las existencias); cada préstamo es de un libro (1:N).



------------------------------------------------------------------------
# 8. DICCIONARIO DE DATOS

## 8.1 Convenciones

  Abreviatura   Significado
  ------------- -----------------------------
  PK            Clave primaria
  FK            Clave foránea
  UQ            Campo con valor único
  NULL          Campo que puede estar vacío
  NOT NULL      Campo obligatorio

## 8.2 Tabla: Autor

  Campo             Tipo de dato   Clave   Nulo   Descripción
  ----------------- -------------- ------- ------ --------------------------------
  idAutor           INT            PK      No     Identificador único del autor.
  nombre            VARCHAR(100)   \-      No     Nombre del autor.
  apellidos         VARCHAR(100)   \-      No     Apellidos del autor.
  nacionalidad      VARCHAR(50)    \-      Sí     Nacionalidad del autor.
  fechaNacimiento   DATE           \-      Sí     Fecha de nacimiento.

## 8.3 Tabla: Categoria

  Campo         Tipo de dato   Clave   Nulo   Descripción
  ------------- -------------- ------- ------ --------------------------------------
  idCategoria   INT            PK      No     Identificador único de la categoría.
  nombre        VARCHAR(50)    UQ      No     Nombre de la categoría.
  descripcion   VARCHAR(200)   \-      Sí     Descripción de la categoría.

## 8.4 Tabla: Libro

  Campo             Tipo de dato   Clave   Nulo   Descripción
  ----------------- -------------- ------- ------ -----------------------------------
  idLibro           INT            PK      No     Identificador único del libro.
  codigo            VARCHAR(20)    UQ      No     Código único del libro.
  titulo            VARCHAR(200)   \-      No     Título del libro.
  anioPublicacion   INT            \-      Sí     Año de publicación.
  idAutor           INT            FK      No     Autor asociado al libro.
  idCategoria       INT            FK      No     Categoría del libro.
  cantidad          INT            \-      No     Cantidad de ejemplares.
  estado            VARCHAR(20)    \-      No     Estado del libro.
  sinopsis          VARCHAR(500)   \-      Sí     Descripción o sinopsis del libro.

## 8.5 Tabla: Usuario

  Campo             Tipo de dato   Clave   Nulo   Descripción
  ----------------- -------------- ------- ------ ----------------------------------
  idUsuario         INT            PK      No     Identificador único del usuario.
  documento         VARCHAR(20)    UQ      No     Número de documento.
  tipoDocumento     VARCHAR(20)    \-      No     Tipo de documento.
  nombre            VARCHAR(100)   \-      No     Nombre del usuario.
  apellidos         VARCHAR(100)   \-      No     Apellidos del usuario.
  direccion         VARCHAR(150)   \-      Sí     Dirección del usuario.
  telefono          VARCHAR(20)    \-      Sí     Teléfono de contacto.
  correo            VARCHAR(100)   \-      Sí     Correo electrónico.
  fechaNacimiento   DATE           \-      Sí     Fecha de nacimiento.
  estado            VARCHAR(20)    \-      No     Estado del usuario.

## 8.6 Tabla: Prestamo

  Campo           Tipo de dato   Clave   Nulo   Descripción
  --------------- -------------- ------- ------ -----------------------------------
  idPrestamo      INT            PK      No     Identificador único del préstamo.
  idUsuario       INT            FK      No     Usuario que realiza el préstamo.
  fechaPrestamo   DATETIME       \-      No     Fecha del préstamo.
  estado          VARCHAR(20)    \-      No     Estado del préstamo.

## 8.7 Tabla: DetallePrestamo

  ---------------------------------------------------------------------------------------
  Campo                     Tipo de dato    Clave          Nulo           Descripción
  ------------------------- --------------- -------------- -------------- ---------------
  idDetalle                 INT             PK             No             Identificador
                                                                          único del
                                                                          detalle.

  idPrestamo                INT             FK             No             Préstamo al que
                                                                          pertenece.

  idLibro                   INT             FK             No             Libro prestado.

  fechaDevolucionEstimada   DATE            \-             No             Fecha estimada
                                                                          de devolución.

  fechaDevolucionReal       DATE            \-             Sí             Fecha real de
                                                                          devolución.

  valor                     DECIMAL(10,2)   \-             No             Valor asociado
                                                                          al préstamo, si
                                                                          aplica.

  multa                     DECIMAL(10,2)   \-             Sí             Valor de la
                                                                          multa generada.

  estado                    VARCHAR(20)     \-             No             Estado del
                                                                          detalle.
  ---------------------------------------------------------------------------------------

## 8.8 Tabla: Devolucion

  Campo             Tipo de dato    Clave   Nulo   Descripción
  ----------------- --------------- ------- ------ ---------------------------------------
  idDevolucion      INT             PK      No     Identificador único de la devolución.
  idDetalle         INT             FK      No     Detalle del préstamo devuelto.
  fechaDevolucion   DATETIME        \-      No     Fecha de devolución.
  diasRetraso       INT             \-      No     Número de días de retraso.
  multa             DECIMAL(10,2)   \-      Sí     Valor de la multa, si aplica.

![alt text](<Diccionario De Datos - Biblioteca .png>)

------------------------------------------------------------------------
# 9. ARQUITECTURA DEL SISTEMA

## 9.1 Descripción general

El Sistema de Gestión de Biblioteca se desarrolla utilizando una
**arquitectura por capas**, con el propósito de separar las
responsabilidades del sistema y facilitar su mantenimiento, organización
y evolución.

La arquitectura está compuesta por:

1.  Capa de Presentación.
2.  Capa de Lógica de Negocio.
3.  Capa de Acceso a Datos.
4.  Capa de Base de Datos.

## 9.2 Diagrama de arquitectura


![Arquitectura del sistema](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Arquitectura%20del%20sistema.png)

## 9.3 Capa de Presentación

**Responsabilidad:**

Es la capa mediante la cual el usuario interactúa con el sistema.

**Componentes:**

-   \[FrmPrincipal\]
-   \[FrmLibros\]
-   \[FrmAutores\]
-   \[FrmCategorias\]
-   \[FrmUsuarios\]
-   \[FrmPrestamos\]
-   \[FrmDevoluciones\]

**Tecnología utilizada:**

-   C#
-   Windows Forms
-   .NET 10.0

## 9.4 Capa de Lógica de Negocio

**Responsabilidad:**

Procesa las solicitudes provenientes de la interfaz, aplica las reglas
de negocio y coordina las operaciones.

**Componentes:**

-   \[LibroController\]
-   \[AutorController\]
-   \[CategoriaController\]
-   \[UsuarioController\]
-   \[PrestamoController\]
-   \[DevolucionController\]

**Ejemplos de reglas:**

-   Validar disponibilidad.
-   Validar existencia del usuario.
-   Validar existencia del libro.
-   Calcular días de retraso.
-   Calcular multa.
-   Actualizar estados.

## 9.5 Capa de Acceso a Datos

**Responsabilidad:**

Gestiona la comunicación entre la aplicación y SQL Server.

**Componentes:**

-   \[Conexion\]
-   \[LibroDAO\]
-   \[AutorDAO\]
-   \[CategoriaDAO\]
-   \[UsuarioDAO\]
-   \[PrestamoDAO\]
-   \[DevolucionDAO\]

**Tecnologías utilizadas:**

- SQL Server: motor de base de datos.

- SQL Server Management Studio (SSMS): administración de la base de datos.

- ADO.NET mediante Microsoft.Data.SqlClient: conexión entre C# y SQL Server.

- Consultas SQL parametrizadas: ejecución segura de consultas.

## 9.6 Capa de Base de Datos

La información del sistema se almacena en:

**Base de datos:** `SQL Server`

**Tablas principales:**

-   Autor
-   Categoria
-   Libro
-   Usuario
-   Prestamo
-   DetallePrestamo
-   Devolucion

## 9.7 Flujo de información

``` text
Usuario
   ↓
Presentación
   ↓
Lógica de Negocio
   ↓
Acceso a Datos
   ↓
SQL Server
```

Las respuestas de la base de datos realizan el recorrido inverso hasta
llegar nuevamente a la interfaz.

------------------------------------------------------------------------
# 10. EXPLICACIÓN DE CADA MÓDULO DESARROLLADO

## 10.1 Módulo de libros

**Objetivo:** Formulario con ISBN, título, autor y editorial (listas desplegables), categoría, año y existencias. Permite guardar,
editar (doble clic sobre la fila), eliminar y buscar por ISBN, título o autor. El ISBN debe tener 10 o 13 caracteres y
no se puede repetir.

**Funcionalidades:** - Registrar. - Consultar. - Actualizar. -
Eliminar. - Buscar.

**Validaciones:** 
- Registrar

![Registro de libros](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Registro%20libros.png)

- Consultar

![Consulta Libros](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Consulta%20Libros.png)

- Eliminar

![Libro eliminado](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Libro%20eliminado.png)

- Buscar

![Buscar libro](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Buscar%20libro.png)

## 10.2 Módulo de autores

**Objetivo:** CRUD de autores. No permite repetir nombre y apellido ni eliminar un autor con libros registrados.

**Funcionalidades:** - Registrar. - Consultar. - Actualizar. - Eliminar.

## 10.3 Módulo de categorías

**Objetivo:** CRUD de categorías. Permite registrar, consultar, editar y eliminar categorías utilizadas para clasificar los libros. No permite repetir el nombre de una categoría ni eliminar una categoría que tenga libros asociados.

**Funcionalidades:** - Registrar. - Consultar. - Actualizar. - Eliminar.

## 10.4 Módulo de usuarios

**Objetivo:** CRUD de usuarios. El documento es obligatorio, solo numérico y único; el teléfono es numérico y el correo, si se
escribe, debe tener un formato válido.

**Funcionalidades:** - Registrar. - Consultar. - Actualizar. - Eliminar.

## 10.5 Módulo de préstamos

**Objetivo:** Permite elegir usuario, libro (con sus ejemplares disponibles) y fecha, y registrar el préstamo. La tabla muestra
todos los préstamos y se puede filtrar por estado. Al seleccionar un préstamo se puede editar su fecha (si sigue
activo) o eliminarlo.

**Funcionalidades:** - Registrar préstamo. - Consultar préstamos
activos. - Consultar historial. - Actualizar disponibilidad.

## 10.6 Módulo de devoluciones

**Objetivo:** Está en el mismo formulario de préstamos: se selecciona el préstamo, se elige la fecha de devolución y se pulsa
Registrar devolución. El sistema cambia el estado a Devuelto y suma un ejemplar al libro.

**Funcionalidades:** - Registrar devolución. - Calcular días de
retraso. - Calcular multa cuando aplique. - Actualizar disponibilidad.

## 10.7 Módulo de consultas

**Consultas implementadas:**

-   Total de libros registrados.
-   Total de usuarios registrados.
-   Libros disponibles.
-   Libros prestados.
-   Usuarios con préstamos activos.
-   Historial de préstamos.
-   Libros más prestados.

------------------------------------------------------------------------
# 11. CAPTURAS DE PANTALLA DEL SISTEMA

En esta sección se deben incluir evidencias de las principales
funcionalidades.

## 11.1 Menú principal

![alt text](<Menu Inicial.png>)

**Descripción:** Presenta la pantalla principal del sistema ACABiblioteca, desde la cual el usuario puede acceder a los diferentes módulos de la aplicación. Permite navegar entre las opciones de gestión de libros, autores, categorías, usuarios, préstamos, devoluciones y consultas, facilitando el acceso organizado a las funcionalidades del sistema.

## 11.2 Gestión de libros

![Menú Inicial](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Menu%20Inicial.png)

**Descripción:** Esta pantalla permite administrar la información de los libros registrados en la biblioteca. Ofrece las opciones de registrar nuevos libros, consultar, buscar, modificar y eliminar registros. También permite visualizar información como ISBN, título, categoría, año de publicación, autor, editorial y existencias disponibles.

## 11.3 Gestión de autores

![Gestión Autores](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Gestion%20Autores.png)

**Descripción:** Permite administrar la información de los autores asociados a los libros de la biblioteca. Desde este módulo se pueden registrar nuevos autores, consultar los existentes, modificar sus datos y eliminar registros cuando no tengan libros asociados. Además, evita la duplicidad de autores mediante la validación del nombre y apellido.



## 11.4 Gestión de usuarios

![Gestión Autores](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Gestion%20Autores.png)

**Descripción:** Permite administrar la información de los usuarios registrados en el sistema, quienes pueden solicitar préstamos de libros. Incluye las opciones de registro, consulta, modificación y eliminación de usuarios, validando que el documento de identidad sea obligatorio, numérico y único. También verifica el formato del correo electrónico cuando se proporciona.

## 11.5 Registro de préstamos

![Gestión Préstamos](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Gestion%20Prestamos.png)

**Descripción:** Esta pantalla permite registrar los préstamos de libros realizados por los usuarios de la biblioteca. Para ello, se selecciona el usuario, el libro y la fecha correspondiente. El sistema verifica la disponibilidad de ejemplares y permite consultar los préstamos registrados, filtrarlos por estado y modificar o eliminar préstamos que continúen activos.

## 11.6 Registro de devoluciones

![Gestión Préstamos](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Gestion%20Prestamos.png)

**Descripción:** Es el mismo modulo de Prestamos Este módulo permite registrar la devolución de los libros que se encuentran en préstamo. El usuario selecciona el préstamo correspondiente, establece la fecha de devolución y confirma la operación. Una vez registrada, el sistema actualiza el estado del préstamo a "Devuelto" y aumenta la cantidad de ejemplares disponibles del libro.

## 11.7 Consultas

![Gestión Consultas](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Gestion%20Consultas.png)

**Descripción:** Esta sección permite consultar información general y específica de la biblioteca mediante diferentes reportes. Incluye listados de libros, autores, editoriales y usuarios, historial de préstamos, préstamos activos y devueltos, libros más prestados, libros sin existencias e información consolidada. Cada consulta presenta el total de registros obtenidos, facilitando el seguimiento y la gestión de la información.

------------------------------------------------------------------------

# 12. PRUEBAS DE FUNCIONAMIENTO

## 12.1 Estrategia de pruebas

Describir cómo se verificó el funcionamiento del sistema.

## 12.2 Casos de prueba

  ------------------------------------------------------------------------------------------
  ID          Funcionalidad   Entrada / Acción Resultado        Resultado       Estado
                                               esperado         obtenido        
  ----------- --------------- ---------------- ---------------- --------------- ------------
  CP01        Registrar libro Datos válidos    Libro registrado El libro se registró correctamente y apareció en el listado de libros.   Aprobado
                                               correctamente                    

  CP02        Registrar libro Código repetido  Mostrar mensaje  El sistema identificó el ISBN duplicado y mostró un mensaje de validación, impidiendo guardar el registro.   Aprobado
                                               de validación                    

  CP03        Registrar       Datos válidos    Usuario          El usuario se registró correctamente y su información quedó almacenada en la base de datos.   Aprobado
              usuario                          registrado                       

  CP04        Registrar       Libro disponible Préstamo         El préstamo se registró correctamente y la cantidad de ejemplares disponibles disminuyó.   Aprobado
              préstamo                         registrado y                     
                                               disponibilidad                   
                                               actualizada                      

  CP05        Registrar       Libro sin        No permitir el   El sistema impidió registrar el préstamo porque no había ejemplares disponibles del libro seleccionado.   Aprobado
              préstamo        disponibilidad   préstamo                         

  CP06        Registrar       Préstamo activo  Registrar        La devolución se registró correctamente, el préstamo cambió al estado «Devuelto» y aumentó la disponibilidad del libro.   Aprobado
              devolución                       devolución y                     
                                               actualizar                       
                                               disponibilidad                   

  CP07        Devolución con  Fecha posterior  Calcular retraso El sistema identificó el retraso en la devolución y calculó la multa correspondiente.   Aprobado
              retraso         a la estimada    y multa                          

  CP08        Consulta        Consultar libros Mostrar libros   El sistema mostró correctamente el listado de libros disponibles para consulta.   Aprobado
                              disponibles      disponibles                      

  CP09        Buscar libro

Ingresar un ISBN registrado y presionar el botón Buscar.     Mostrar la información del libro correspondiente al ISBN ingresado.El sistema localizó el libro y mostró correctamente su información en los campos correspondientes. Aprobado
                                                                      
  ------------------------------------------------------------------------------------------

## 12.3 Evidencias de pruebas


### Prueba CP01

![Registro de libros](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Registro%20libros.png)

**Resultado:** Se evidencia el registro exitoso de un nuevo libro en el sistema. La información ingresada fue almacenada correctamente en la base de datos y se encuentra disponible en el listado general de libros.

### Prueba CP02

![Libro repetido](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Libro%20repetido.png)

**Resultado:** Se evidencia que el sistema identifica un ISBN que ya se encuentra registrado en la base de datos. Al intentar ingresar nuevamente el mismo código, muestra un mensaje de validación e impide la duplicación del registro.

------------------------------------------------------------------------

# 13. CONCLUSIONES

## Conclusión 1

Con el desarrollo del proyecto ACABiblioteca se logró construir una aplicación de escritorio orientada a la gestión y administración de los procesos básicos de una biblioteca. El sistema permite registrar, consultar, modificar y eliminar información de libros, autores, categorías, editoriales y usuarios, además de gestionar préstamos, devoluciones y generar reportes. Esto permite organizar la información bibliográfica, facilitar las consultas y mejorar el seguimiento de los recursos disponibles.

## Conclusión 2

Durante el desarrollo del proyecto se aplicaron conceptos fundamentales de la Programación Orientada a Objetos mediante el lenguaje C#, utilizando clases, métodos, atributos, encapsulamiento y organización del código. También se implementaron formularios de Windows Forms para facilitar la interacción con el usuario, permitiendo desarrollar una aplicación estructurada, funcional y de fácil manejo.

## Conclusión 3

La implementación de SQL Server como sistema gestor de base de datos permitió almacenar y administrar de manera organizada la información de la biblioteca. Mediante ADO.NET y Microsoft.Data.SqlClient se estableció la comunicación entre la aplicación y la base de datos, utilizando consultas SQL parametrizadas para realizar las operaciones de registro, actualización, eliminación y consulta. Asimismo, la organización por capas permitió separar las responsabilidades del sistema, facilitando su mantenimiento, comprensión y futuras modificaciones.

## Conclusión 4

Durante el desarrollo del proyecto se presentaron dificultades relacionadas con la conexión a la base de datos, la programación de eventos en Windows Forms, la validación de información y la integración de los diferentes módulos. Estas situaciones se solucionaron mediante la revisión del código, la identificación de errores, la realización de pruebas y los ajustes necesarios en los formularios y consultas SQL. Este proceso permitió fortalecer las habilidades de programación, análisis y solución de problemas, así como comprender la importancia de realizar pruebas durante el desarrollo de software.

------------------------------------------------------------------------

# 15. REFERENCIAS BIBLIOGRÁFICAS


**Página web:**

Microsoft. (s. f.). Microsoft.Data.SqlClient para SQL Server. Microsoft Learn. https://learn.microsoft.com/es-es/sql/connect/ado-net/

------------------------------------------------------------------------

# ANEXOS

## Anexo A. Repositorio GitHub

**Repositorio:** (https://github.com/andrestejadac/ACA-PROGRAMACION-AVANZADA)

## Anexo B. Script de base de datos

**Archivo:** `Script BD.sql`

## Anexo C. Evidencia de Git y GitHub


-   Creación del repositorio.

Git Hub local

![Repositorio local GitHub](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Repositorio%20local%20Git%20Hub.png)

Git Hub WEB

![Repositorio WEB GitHub](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Repositorio%20WEB%20Git%20Hub.png)

-   Commits realizados.**887**

![Commits realizados](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Commits%20realizados.png)

![Commit GitHub](https://raw.githubusercontent.com/andrestejadac/ACA-PROGRAMACION-AVANZADA/main/Documentacion/diagramas/Commit%20Git%20Hub.png)

# LISTA DE VERIFICACIÓN ANTES DE ENTREGAR

-   [X] Portada.
-   [X] Contraportada.
-   [X] Introducción.
-   [X] Objetivos.
-   [X] Tabla de contenido.
-   [X] Numeración de páginas.
-   [X] Planteamiento del problema.
-   [X] Análisis de requerimientos.
-   [X] Casos de uso.
-   [X] Diagrama de casos de uso.
-   [X] Diagrama de clases.
-   [X] Modelo entidad-relación.
-   [X] Diccionario de datos.
-   [X] Arquitectura del sistema.
-   [X] Explicación de cada módulo.
-   [X] Capturas de pantalla.
-   [X] Pruebas de funcionamiento.
-   [X] Conclusiones.
-   [X] Recomendaciones.
-   [X] Referencias bibliográficas en formato APA.
-   [X] Código fuente completo.
-   [X] Script SQL.
-   [X] Datos de prueba.
-   [X] Repositorio GitHub.
-   [X] Evidencia de commits.

------------------------------------------------------------------------



/* =====================================================================
   ACA Programación Avanzada - Sistema de Gestión de Biblioteca
   Script SQL Server: base de datos, tablas, claves, restricciones y
   datos de prueba.

   Se puede ejecutar varias veces: recrea las tablas desde cero
   (ATENCIÓN: borra los datos existentes de AcaBiblioteca).
   ===================================================================== */

-- 1. Creación de la base de datos --------------------------------------
IF DB_ID(N'AcaBiblioteca') IS NULL
    CREATE DATABASE AcaBiblioteca;
GO

USE AcaBiblioteca;
GO

-- 2. Limpieza (orden inverso a las dependencias) -----------------------
IF OBJECT_ID(N'dbo.Prestamos',   N'U') IS NOT NULL DROP TABLE dbo.Prestamos;
IF OBJECT_ID(N'dbo.Libros',      N'U') IS NOT NULL DROP TABLE dbo.Libros;
IF OBJECT_ID(N'dbo.Usuarios',    N'U') IS NOT NULL DROP TABLE dbo.Usuarios;
IF OBJECT_ID(N'dbo.Editoriales', N'U') IS NOT NULL DROP TABLE dbo.Editoriales;
IF OBJECT_ID(N'dbo.Autores',     N'U') IS NOT NULL DROP TABLE dbo.Autores;
GO

-- 3. Creación de tablas -------------------------------------------------
CREATE TABLE Autores
(
    IdAutor  INT IDENTITY(1,1) NOT NULL,
    Nombre   VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,

    CONSTRAINT PK_Autores PRIMARY KEY (IdAutor),
    CONSTRAINT UQ_Autores_NombreCompleto UNIQUE (Nombre, Apellido)
);

CREATE TABLE Editoriales
(
    IdEditorial INT IDENTITY(1,1) NOT NULL,
    Nombre      VARCHAR(150) NOT NULL,

    CONSTRAINT PK_Editoriales PRIMARY KEY (IdEditorial),
    CONSTRAINT UQ_Editoriales_Nombre UNIQUE (Nombre)
);

CREATE TABLE Libros
(
    ISBN        VARCHAR(20)  NOT NULL,
    Titulo      VARCHAR(200) NOT NULL,
    IdAutor     INT          NOT NULL,
    IdEditorial INT          NOT NULL,
    Categoria   VARCHAR(100) NULL,
    Anio        INT          NULL,
    Existencias INT          NOT NULL CONSTRAINT DF_Libros_Existencias DEFAULT 0,

    CONSTRAINT PK_Libros PRIMARY KEY (ISBN),
    CONSTRAINT FK_Libros_Autores
        FOREIGN KEY (IdAutor) REFERENCES Autores(IdAutor),
    CONSTRAINT FK_Libros_Editoriales
        FOREIGN KEY (IdEditorial) REFERENCES Editoriales(IdEditorial),
    CONSTRAINT CK_Libros_Existencias CHECK (Existencias >= 0),
    CONSTRAINT CK_Libros_Anio CHECK (Anio IS NULL OR Anio BETWEEN 1 AND 2100)
);

CREATE TABLE Usuarios
(
    IdUsuario INT IDENTITY(1,1) NOT NULL,
    Nombre    VARCHAR(100) NOT NULL,
    Apellido  VARCHAR(100) NOT NULL,
    Documento VARCHAR(30)  NOT NULL,
    Telefono  VARCHAR(30)  NULL,
    Correo    VARCHAR(150) NULL,

    CONSTRAINT PK_Usuarios PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuarios_Documento UNIQUE (Documento)
);

CREATE TABLE Prestamos
(
    IdPrestamo      INT IDENTITY(1,1) NOT NULL,
    IdUsuario       INT         NOT NULL,
    ISBN            VARCHAR(20) NOT NULL,
    FechaPrestamo   DATE        NOT NULL,
    FechaDevolucion DATE        NULL,
    Estado          VARCHAR(20) NOT NULL CONSTRAINT DF_Prestamos_Estado DEFAULT 'Prestado',

    CONSTRAINT PK_Prestamos PRIMARY KEY (IdPrestamo),
    CONSTRAINT FK_Prestamos_Usuarios
        FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    CONSTRAINT FK_Prestamos_Libros
        FOREIGN KEY (ISBN) REFERENCES Libros(ISBN),
    CONSTRAINT CK_Prestamos_Estado CHECK (Estado IN ('Prestado', 'Devuelto')),
    CONSTRAINT CK_Prestamos_Fechas
        CHECK (FechaDevolucion IS NULL OR FechaDevolucion >= FechaPrestamo),
    -- Coherencia estado/fecha: un préstamo devuelto tiene fecha de devolución
    CONSTRAINT CK_Prestamos_EstadoFecha CHECK
        ((Estado = 'Prestado' AND FechaDevolucion IS NULL) OR
         (Estado = 'Devuelto' AND FechaDevolucion IS NOT NULL))
);
GO

-- 4. Datos de prueba ------------------------------------------------------
INSERT INTO Usuarios (Nombre, Apellido, Documento, Telefono, Correo)
VALUES
    ('Ana',       'Pérez',      '1001001001', '3001234567', 'ana@gmail.com'),
    ('Carlos',    'Gómez',      '1001001002', '3012345678', 'carlos@gmail.com'),
    ('María',     'Rodríguez',  '1001001003', '3023456789', 'maria@gmail.com'),
    ('Laura',     'Martínez',   '1001001004', '3034567890', 'laura.martinez@gmail.com'),
    ('Andrés',    'López',      '1001001005', '3045678901', 'andres.lopez@gmail.com'),
    ('Sofía',     'Hernández',  '1001001006', '3056789012', 'sofia.hernandez@gmail.com'),
    ('Daniel',    'Torres',     '1001001007', '3067890123', 'daniel.torres@gmail.com'),
    ('Mariana',   'Ramírez',    '1001001008', '3078901234', 'mariana.ramirez@gmail.com'),
    ('Felipe',    'Castro',     '1001001009', '3089012345', 'felipe.castro@gmail.com'),
    ('Valentina', 'Morales',    '1001001010', '3090123456', 'valentina.morales@gmail.com');

INSERT INTO Autores (Nombre, Apellido)
VALUES
    ('Gabriel',    'García Márquez'),   -- 1
    ('Julio',      'Cortázar'),         -- 2
    ('Isabel',     'Allende'),          -- 3
    ('George',     'Orwell'),           -- 4
    ('Miguel',     'de Cervantes'),     -- 5
    ('Jane',       'Austen'),           -- 6
    ('Mario',      'Vargas Llosa'),     -- 7
    ('Jorge Luis', 'Borges'),           -- 8
    ('Antoine',    'de Saint-Exupéry'), -- 9
    ('Ernest',     'Hemingway');        -- 10

INSERT INTO Editoriales (Nombre)
VALUES
    ('Planeta'),               -- 1
    ('Alfaguara'),             -- 2
    ('Penguin Random House'),  -- 3
    ('Debolsillo'),            -- 4
    ('Anagrama'),              -- 5
    ('Seix Barral'),           -- 6
    ('Tusquets Editores');     -- 7

-- Existencias = ejemplares totales; más abajo se descuentan los préstamos activos
INSERT INTO Libros (ISBN, Titulo, IdAutor, IdEditorial, Categoria, Anio, Existencias)
VALUES
    ('9780307474728', 'Cien años de soledad',               1, 1, 'Novela',               1967, 5),
    ('9780451524935', '1984',                               4, 3, 'Distopía',             1949, 4),
    ('9780060934347', 'Don Quijote de la Mancha',           5, 1, 'Novela',               1605, 3),
    ('9780141439518', 'Orgullo y prejuicio',                6, 4, 'Novela romántica',     1813, 5),
    ('9788437604947', 'Rayuela',                            2, 2, 'Novela',               1963, 2),
    ('9788401352836', 'La casa de los espíritus',           3, 1, 'Realismo mágico',      1982, 4),
    ('9788420471839', 'La ciudad y los perros',             7, 6, 'Novela',               1963, 3),
    ('9788420633114', 'Ficciones',                          8, 7, 'Cuentos',              1944, 2),
    ('9780156012195', 'El principito',                      9, 3, 'Literatura infantil',  1943, 6),
    ('9780684830490', 'El viejo y el mar',                 10, 5, 'Novela',               1952, 3),
    ('9780307389732', 'El amor en los tiempos del cólera',  1, 1, 'Novela',               1985, 4);

-- Préstamos de prueba (se usa el título para no depender del ISBN)
INSERT INTO Prestamos (IdUsuario, ISBN, FechaPrestamo, FechaDevolucion, Estado)
SELECT U.IdUsuario, L.ISBN, V.FechaPrestamo, V.FechaDevolucion, V.Estado
FROM
(
    VALUES
        (1,  'Cien años de soledad',              CAST('2026-10-20' AS DATE), CAST(NULL AS DATE),         'Prestado'),
        (2,  '1984',                              CAST('2026-08-05' AS DATE), CAST('2026-08-14' AS DATE), 'Devuelto'),
        (3,  'Don Quijote de la Mancha',          CAST('2026-10-25' AS DATE), CAST(NULL AS DATE),         'Prestado'),
        (5,  'El amor en los tiempos del cólera', CAST('2026-08-08' AS DATE), CAST('2026-08-16' AS DATE), 'Devuelto'),
        (6,  'El principito',                     CAST('2026-10-28' AS DATE), CAST(NULL AS DATE),         'Prestado'),
        (7,  'El viejo y el mar',                 CAST('2026-08-10' AS DATE), CAST('2026-08-15' AS DATE), 'Devuelto'),
        (8,  'Ficciones',                         CAST('2026-10-30' AS DATE), CAST(NULL AS DATE),         'Prestado'),
        (9,  'La casa de los espíritus',          CAST('2026-08-12' AS DATE), CAST('2026-08-17' AS DATE), 'Devuelto'),
        (10, 'La ciudad y los perros',            CAST('2026-11-01' AS DATE), CAST(NULL AS DATE),         'Prestado'),
        (4,  'Orgullo y prejuicio',               CAST('2026-08-14' AS DATE), CAST('2026-08-18' AS DATE), 'Devuelto')
) AS V(IdUsuario, Titulo, FechaPrestamo, FechaDevolucion, Estado)
INNER JOIN Usuarios U ON U.IdUsuario = V.IdUsuario
INNER JOIN Libros   L ON L.Titulo    = V.Titulo;

-- Coherencia: cada préstamo activo descuenta un ejemplar disponible
UPDATE L
SET    L.Existencias = L.Existencias - P.Activos
FROM   Libros L
INNER JOIN (SELECT ISBN, COUNT(*) AS Activos
            FROM Prestamos
            WHERE Estado = 'Prestado'
            GROUP BY ISBN) P ON P.ISBN = L.ISBN;
GO

-- 5. Verificación rápida --------------------------------------------------
SELECT 'Autores'     AS Tabla, COUNT(*) AS Registros FROM Autores
UNION ALL SELECT 'Editoriales', COUNT(*) FROM Editoriales
UNION ALL SELECT 'Libros',      COUNT(*) FROM Libros
UNION ALL SELECT 'Usuarios',    COUNT(*) FROM Usuarios
UNION ALL SELECT 'Prestamos',   COUNT(*) FROM Prestamos;
GO

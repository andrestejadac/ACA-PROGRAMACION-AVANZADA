using System.Data;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Consultas de solo lectura para el módulo de reportes.
    /// Cada método devuelve un DataTable listo para mostrar en un DataGridView.
    /// </summary>
    public class ReporteDatos
    {
        private readonly Conexion conexion = new Conexion();

        public DataTable ListadoLibros() => Consultar(@"
            SELECT L.ISBN, L.Titulo, A.Nombre + ' ' + A.Apellido AS Autor, E.Nombre AS Editorial,
                   L.Categoria, L.Anio AS [Año], L.Existencias
            FROM Libros L
            INNER JOIN Autores A ON A.IdAutor = L.IdAutor
            INNER JOIN Editoriales E ON E.IdEditorial = L.IdEditorial
            ORDER BY L.Titulo");

        public DataTable ListadoAutores() => Consultar(@"
            SELECT A.IdAutor, A.Nombre, A.Apellido, COUNT(L.ISBN) AS [Libros registrados]
            FROM Autores A
            LEFT JOIN Libros L ON L.IdAutor = A.IdAutor
            GROUP BY A.IdAutor, A.Nombre, A.Apellido
            ORDER BY A.Nombre, A.Apellido");

        public DataTable ListadoEditoriales() => Consultar(@"
            SELECT E.IdEditorial, E.Nombre, COUNT(L.ISBN) AS [Libros registrados]
            FROM Editoriales E
            LEFT JOIN Libros L ON L.IdEditorial = E.IdEditorial
            GROUP BY E.IdEditorial, E.Nombre
            ORDER BY E.Nombre");

        public DataTable ListadoUsuarios() => Consultar(@"
            SELECT U.IdUsuario, U.Nombre, U.Apellido, U.Documento, U.Telefono, U.Correo,
                   SUM(CASE WHEN P.Estado = 'Prestado' THEN 1 ELSE 0 END) AS [Préstamos activos]
            FROM Usuarios U
            LEFT JOIN Prestamos P ON P.IdUsuario = U.IdUsuario
            GROUP BY U.IdUsuario, U.Nombre, U.Apellido, U.Documento, U.Telefono, U.Correo
            ORDER BY U.Nombre, U.Apellido");

        /// <summary>Relación de préstamos. El estado puede ser null (todos), Prestado o Devuelto.</summary>
        public DataTable Prestamos(string? estado)
        {
            string sql = @"
                SELECT P.IdPrestamo AS [N.º], U.Nombre + ' ' + U.Apellido AS Usuario, U.Documento,
                       L.Titulo AS Libro, P.ISBN, P.FechaPrestamo AS [Fecha préstamo],
                       P.FechaDevolucion AS [Fecha devolución], P.Estado
                FROM Prestamos P
                INNER JOIN Usuarios U ON U.IdUsuario = P.IdUsuario
                INNER JOIN Libros L ON L.ISBN = P.ISBN";

            if (estado != null)
                sql += " WHERE P.Estado = @Estado";

            sql += " ORDER BY P.FechaPrestamo DESC, P.IdPrestamo DESC";

            return Consultar(sql, estado == null ? null : new SqlParameter("@Estado", estado));
        }

        public DataTable LibrosMasPrestados() => Consultar(@"
            SELECT TOP 10 L.Titulo, A.Nombre + ' ' + A.Apellido AS Autor, COUNT(P.IdPrestamo) AS [Veces prestado]
            FROM Libros L
            INNER JOIN Autores A ON A.IdAutor = L.IdAutor
            LEFT JOIN Prestamos P ON P.ISBN = L.ISBN
            GROUP BY L.Titulo, A.Nombre, A.Apellido
            ORDER BY COUNT(P.IdPrestamo) DESC, L.Titulo");

        public DataTable LibrosSinExistencias() => Consultar(@"
            SELECT L.ISBN, L.Titulo, A.Nombre + ' ' + A.Apellido AS Autor, L.Existencias
            FROM Libros L
            INNER JOIN Autores A ON A.IdAutor = L.IdAutor
            WHERE L.Existencias = 0
            ORDER BY L.Titulo");

        /// <summary>Totales generales de la biblioteca (una sola fila).</summary>
        public DataTable Resumen() => Consultar(@"
            SELECT
                (SELECT COUNT(*) FROM Libros)                                  AS [Libros registrados],
                (SELECT ISNULL(SUM(Existencias), 0) FROM Libros)               AS [Ejemplares disponibles],
                (SELECT COUNT(*) FROM Autores)                                 AS [Autores],
                (SELECT COUNT(*) FROM Editoriales)                             AS [Editoriales],
                (SELECT COUNT(*) FROM Usuarios)                                AS [Usuarios],
                (SELECT COUNT(*) FROM Prestamos WHERE Estado = 'Prestado')     AS [Préstamos activos],
                (SELECT COUNT(*) FROM Prestamos WHERE Estado = 'Devuelto')     AS [Préstamos devueltos]");

        private DataTable Consultar(string sql, SqlParameter? parametro = null)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            using SqlCommand cmd = new SqlCommand(sql, cn);
            if (parametro != null)
                cmd.Parameters.Add(parametro);

            using SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
    }
}

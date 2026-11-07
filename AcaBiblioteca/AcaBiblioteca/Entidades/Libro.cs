namespace AcaBiblioteca.Entidades
{
    public class Libro
    {
        private string isbn = string.Empty;
        private string titulo = string.Empty;
        private string categoria = string.Empty;

        public Libro()
        {
        }

        public Libro(string isbn, string titulo, int idAutor, int idEditorial,
                     string categoria, int? anio, int existencias)
        {
            ISBN = isbn;
            Titulo = titulo;
            IdAutor = idAutor;
            IdEditorial = idEditorial;
            Categoria = categoria;
            Anio = anio;
            Existencias = existencias;
        }

        public string ISBN
        {
            get => isbn;
            set => isbn = (value ?? string.Empty).Trim();
        }

        public string Titulo
        {
            get => titulo;
            set => titulo = (value ?? string.Empty).Trim();
        }

        public int IdAutor { get; set; }

        public int IdEditorial { get; set; }

        public string Categoria
        {
            get => categoria;
            set => categoria = (value ?? string.Empty).Trim();
        }

        public int? Anio { get; set; }

        public int Existencias { get; set; }

        // Datos de apoyo para mostrar en las tablas (vienen del JOIN)
        public string Autor { get; set; } = string.Empty;

        public string Editorial { get; set; } = string.Empty;
    }
}

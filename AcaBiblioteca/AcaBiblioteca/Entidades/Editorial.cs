namespace AcaBiblioteca.Entidades
{
    public class Editorial
    {
        private string nombre = string.Empty;

        public Editorial()
        {
        }

        public Editorial(int idEditorial, string nombre)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
        }

        public int IdEditorial { get; set; }

        public string Nombre
        {
            get => nombre;
            set => nombre = (value ?? string.Empty).Trim();
        }

        public override string ToString() => Nombre;
    }
}

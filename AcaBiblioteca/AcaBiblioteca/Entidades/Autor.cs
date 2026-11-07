namespace AcaBiblioteca.Entidades
{
    public class Autor : Persona
    {
        public Autor()
        {
        }

        public Autor(int idAutor, string nombre, string apellido) : base(nombre, apellido)
        {
            IdAutor = idAutor;
        }

        public int IdAutor { get; set; }
    }
}

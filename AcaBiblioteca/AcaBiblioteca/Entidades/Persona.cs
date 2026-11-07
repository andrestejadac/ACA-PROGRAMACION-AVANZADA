using System.ComponentModel;

namespace AcaBiblioteca.Entidades
{
    /// <summary>
    /// Clase base para las entidades que representan personas (autores y usuarios).
    /// Se usa herencia porque ambas comparten nombre y apellido.
    /// </summary>
    public class Persona
    {
        private string nombre = string.Empty;
        private string apellido = string.Empty;

        public Persona()
        {
        }

        public Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = (value ?? string.Empty).Trim();
        }

        public string Apellido
        {
            get => apellido;
            set => apellido = (value ?? string.Empty).Trim();
        }

        [Browsable(false)]
        public string NombreCompleto => $"{Nombre} {Apellido}".Trim();
    }
}

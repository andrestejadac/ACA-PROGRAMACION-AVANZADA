namespace AcaBiblioteca.Entidades
{
    public class Usuario : Persona
    {
        private string documento = string.Empty;
        private string telefono = string.Empty;
        private string correo = string.Empty;

        public Usuario()
        {
        }

        public Usuario(int idUsuario, string nombre, string apellido,
                       string documento, string telefono, string correo)
            : base(nombre, apellido)
        {
            IdUsuario = idUsuario;
            Documento = documento;
            Telefono = telefono;
            Correo = correo;
        }

        public int IdUsuario { get; set; }

        public string Documento
        {
            get => documento;
            set => documento = (value ?? string.Empty).Trim();
        }

        public string Telefono
        {
            get => telefono;
            set => telefono = (value ?? string.Empty).Trim();
        }

        public string Correo
        {
            get => correo;
            set => correo = (value ?? string.Empty).Trim();
        }
    }
}

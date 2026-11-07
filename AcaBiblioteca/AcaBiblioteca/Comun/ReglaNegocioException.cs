namespace AcaBiblioteca.Comun
{
    /// <summary>
    /// Error esperado por incumplir una regla de negocio o una validación
    /// (campo vacío, duplicado, libro sin existencias, etc.).
    /// Su mensaje es claro y se puede mostrar directamente al usuario.
    /// </summary>
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(string mensaje) : base(mensaje)
        {
        }

        public ReglaNegocioException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}

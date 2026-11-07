namespace AcaBiblioteca.Comun
{
    /// <summary>
    /// Centraliza los cuadros de mensaje de la aplicación para que todos
    /// los formularios informen de la misma manera.
    /// </summary>
    public static class Mensajes
    {
        private const string Titulo = "Biblioteca";

        public static void Informacion(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Advertencia(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void Error(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool Confirmar(string pregunta) =>
            MessageBox.Show(pregunta, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        /// <summary>
        /// Muestra una excepción: las reglas de negocio como advertencia
        /// y cualquier otro error como error técnico.
        /// </summary>
        public static void Excepcion(Exception ex, string contexto)
        {
            if (ex is ReglaNegocioException)
                Advertencia(ex.Message);
            else
                Error(contexto + ":\n" + ex.Message);
        }
    }
}

namespace SSEL.MONTERREY.Domain.Entities
{
    /// <summary>
    /// Representa a un usuario dentro del sistema SSEL MONTERREY.
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        /// <summary>
        /// Documento Nacional de Identidad del usuario.
        /// </summary>
        public string DNI { get; set; } = string.Empty;

        public string? Direccion { get; set; }

        public string? Celular { get; set; }

        public string? Correo { get; set; }

        /// <summary>
        /// Indica si el usuario está activo en el sistema.
        /// </summary>
        public bool Estado { get; set; } = true;
    }
}

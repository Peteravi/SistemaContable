using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Models
{
    public class Usuario
    {
        // Propiedades correspondientes a la tabla Usuarios
        public string Login_Usuario { get; set; }       // Clave primaria
        public string Pass_Usuario { get; set; }        // Contraseña del usuario
        public string Nivel_Acceso { get; set; }        // Nivel de acceso (cambiado a string)
        public string Nombre_Usuario { get; set; }      // Nombre del usuario
        public string Apellidos_Usuario { get; set; }   // Apellidos del usuario
        public string? Email_Usuario { get; set; }      // Email del usuario (opcional)

        // Constructor con parámetros
        public Usuario(string login, string password, string nivelAcceso, string nombre, string apellidos, string? email)
        {
            Login_Usuario = login;
            Pass_Usuario = password;
            Nivel_Acceso = nivelAcceso;  // Cambiado para aceptar un string
            Nombre_Usuario = nombre;
            Apellidos_Usuario = apellidos;
            Email_Usuario = email;
        }
    }
}

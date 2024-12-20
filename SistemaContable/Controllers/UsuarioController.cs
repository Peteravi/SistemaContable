using SistemaContable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Controllers
{
    public class UsuarioController
    {
        private List<Usuario> _usuarios;  // Simulamos una base de datos en memoria

        public UsuarioController()
        {
            _usuarios = new List<Usuario>();
        }

        // Crear un nuevo usuario
        public void CrearUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
            Console.WriteLine("Usuario creado exitosamente.");
        }

        // Obtener todos los usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

        // Buscar un usuario por Login
        public Usuario ObtenerUsuarioPorLogin(string login)
        {
            return _usuarios.FirstOrDefault(u => u.Login_Usuario == login);
        }

        // Actualizar usuario
        public void ActualizarUsuario(string login, Usuario usuarioActualizado)
        {
            var usuario = ObtenerUsuarioPorLogin(login);
            if (usuario != null)
            {
                usuario.Nombre_Usuario = usuarioActualizado.Nombre_Usuario;
                usuario.Apellidos_Usuario = usuarioActualizado.Apellidos_Usuario;
                usuario.Email_Usuario = usuarioActualizado.Email_Usuario;
                usuario.Nivel_Acceso = usuarioActualizado.Nivel_Acceso;

                Console.WriteLine("Usuario actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }

        // Eliminar usuario
        public void EliminarUsuario(string login)
        {
            var usuario = ObtenerUsuarioPorLogin(login);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
                Console.WriteLine("Usuario eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
    }
}

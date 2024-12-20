using MySql.Data.MySqlClient;
using System;

namespace SistemaContable.ConexionDB
{
    internal class Conexion
    {
        private static string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";

        private MySqlConnection? connection; // Permite valores null

        public MySqlConnection AbrirConexion()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            return connection!;
        }

        public void CerrarConexion()
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}

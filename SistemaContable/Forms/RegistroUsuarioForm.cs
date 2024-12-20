using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Para conectar con MySQL

namespace SistemaContable.Forms
{
    public partial class RegistroUsuarioForm : Form
    {
        public RegistroUsuarioForm()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string nivelAcceso = txtNivelAcceso.Text; // Cambiado a string
            string email = txtEmail.Text;

            // Validaciones básicas
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nivelAcceso)) // Añadido nivelAcceso
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Agregar el usuario a la base de datos
            string connectionString = "Server=localhost;Database=sistemcontable;Uid=root;Pwd=piteravi07;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Usuarios (Login_Usuario, Pass_Usuario, Nombre_Usuario, Apellidos_Usuario, Nivel_Acceso, Email_Usuario) " +
                                   "VALUES (@Login, @Password, @Nombre, @Apellidos, @NivelAcceso, @Email)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@NivelAcceso", nivelAcceso); // Tratado como string
                    cmd.Parameters.AddWithValue("@Email", email);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Cierra el formulario de registro después de agregar el usuario
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

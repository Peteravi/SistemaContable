using SistemaContable.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaContable.Forms
{
    public partial class FormularioUsuarios : Form
    {
        private List<Usuario> usuarios;

        // Cadena de conexión a la base de datos
        private string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";

        public FormularioUsuarios()
        {
            InitializeComponent();
            usuarios = new List<Usuario>();

            // Asociar el evento Load del formulario con el método de carga
            this.Load += new EventHandler(FormularioUsuarios_Load);
        }

        // Método para cargar usuarios desde la base de datos
        private void CargarUsuarios()
        {
            try
            {
                // Limpiar las columnas y filas existentes
                dgvUsuarios.Columns.Clear();
                dgvUsuarios.Rows.Clear();

                // Definir columnas del DataGridView si no existen
                dgvUsuarios.Columns.Add("Login_Usuario", "Login");
                dgvUsuarios.Columns.Add("Nombre_Usuario", "Nombre");
                dgvUsuarios.Columns.Add("Apellidos_Usuario", "Apellidos");
                dgvUsuarios.Columns.Add("Nivel_Acceso", "Nivel de Acceso");
                dgvUsuarios.Columns.Add("Email_Usuario", "Correo");

                // Conexión a la base de datos
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM usuarios";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Leer los datos y agregarlos al DataGridView
                            while (reader.Read())
                            {
                                dgvUsuarios.Rows.Add(
                                    reader["Login_Usuario"].ToString(),
                                    reader["Nombre_Usuario"].ToString(),
                                    reader["Apellidos_Usuario"].ToString(),
                                    reader["Nivel_Acceso"].ToString(),
                                    reader["Email_Usuario"].ToString()
                                );
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron usuarios en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método llamado cuando se carga el formulario
        private void FormularioUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios(); // Cargar los usuarios desde la base de datos
        }

        // Agregar un nuevo usuario
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de datos de entrada
                if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                    string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellidos.Text) ||
                    string.IsNullOrEmpty(txtNivelAcceso.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar en la base de datos
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Usuarios (Login_Usuario, Pass_Usuario, Nivel_Acceso, Nombre_Usuario, Apellidos_Usuario, Email_Usuario) " +
                                   "VALUES (@Login_Usuario, @Pass_Usuario, @Nivel_Acceso, @Nombre_Usuario, @Apellidos_Usuario, @Email_Usuario)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Login_Usuario", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@Pass_Usuario", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Nivel_Acceso", txtNivelAcceso.Text);
                    cmd.Parameters.AddWithValue("@Nombre_Usuario", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Apellidos_Usuario", txtApellidos.Text);
                    cmd.Parameters.AddWithValue("@Email_Usuario", string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios(); // Recargar la lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualizar un usuario seleccionado
        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvUsuarios.SelectedRows[0];
                string login = selectedRow.Cells[0].Value.ToString();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Usuarios SET Pass_Usuario = @Pass_Usuario, Nivel_Acceso = @Nivel_Acceso, Nombre_Usuario = @Nombre_Usuario, " +
                                   "Apellidos_Usuario = @Apellidos_Usuario, Email_Usuario = @Email_Usuario WHERE Login_Usuario = @Login_Usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Pass_Usuario", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Nivel_Acceso", txtNivelAcceso.Text);
                    cmd.Parameters.AddWithValue("@Nombre_Usuario", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Apellidos_Usuario", txtApellidos.Text);
                    cmd.Parameters.AddWithValue("@Email_Usuario", string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Login_Usuario", login);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar un usuario seleccionado
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvUsuarios.SelectedRows[0];
                string login = selectedRow.Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Usuarios WHERE Login_Usuario = @Login_Usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Login_Usuario", login);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpiar campos de texto
        private void LimpiarCampos()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtNivelAcceso.Clear();
            txtEmail.Clear();
        }
    }
}

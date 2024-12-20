using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace SistemaContable.Forms
{
    public partial class LoginForm : Form
    {
        private MySqlConnection conexion;

        public LoginForm()
        {
            InitializeComponent();
            InicializarConexion();
        }

        private void InicializarConexion()
        {
            // Cadena de conexión para MySQL
            string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";
            conexion = new MySqlConnection(connectionString);
        }

        private void InitializeComponent()
        {
            this.txtUsuario = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnRegistrarUsuario = new Button();
            this.lblTitulo = new Label();
            this.panelContainer = new Panel();

            this.SuspendLayout();

            // Configuración del formulario
            this.ClientSize = new Size(420, 400);
            this.BackColor = Color.FromArgb(240, 243, 255);
            this.Text = "Sistema Contable - Login";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel contenedor
            this.panelContainer.BackColor = Color.White;
            this.panelContainer.Size = new Size(350, 300);
            this.panelContainer.Location = new Point(35, 50);

            // Título
            this.lblTitulo.Text = "Iniciar Sesión";
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitulo.Dock = DockStyle.Top;

            // txtUsuario
            this.txtUsuario.Location = new Point(50, 80);
            this.txtUsuario.Size = new Size(250, 30);
            this.txtUsuario.PlaceholderText = "Usuario";

            // txtPassword
            this.txtPassword.Location = new Point(50, 130);
            this.txtPassword.Size = new Size(250, 30);
            this.txtPassword.PlaceholderText = "Contraseña";
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Location = new Point(50, 180);
            this.btnLogin.Size = new Size(250, 40);
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // btnRegistrarUsuario
            this.btnRegistrarUsuario.Text = "Registrar Usuario";
            this.btnRegistrarUsuario.BackColor = Color.FromArgb(39, 174, 96);
            this.btnRegistrarUsuario.ForeColor = Color.White;
            this.btnRegistrarUsuario.FlatStyle = FlatStyle.Flat;
            this.btnRegistrarUsuario.Location = new Point(50, 230);
            this.btnRegistrarUsuario.Size = new Size(250, 40);
            this.btnRegistrarUsuario.Click += new EventHandler(this.btnRegistrarUsuario_Click);

            // Añadir controles
            this.panelContainer.Controls.Add(this.txtUsuario);
            this.panelContainer.Controls.Add(this.txtPassword);
            this.panelContainer.Controls.Add(this.btnLogin);
            this.panelContainer.Controls.Add(this.btnRegistrarUsuario);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelContainer);

            this.ResumeLayout(false);
        }

        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegistrarUsuario;
        private Label lblTitulo;
        private Panel panelContainer;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            try
            {
                conexion.Open();
                string query = "SELECT Nivel_Acceso FROM usuarios WHERE Login_Usuario = @usuario AND Pass_Usuario = @password";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@password", password);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    string nivelAcceso = resultado.ToString();

                    // Ahora pasamos el nivel de acceso al FormularioPrincipal
                    MessageBox.Show($"Login exitoso como {nivelAcceso}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FormularioPrincipal mainForm = new FormularioPrincipal(nivelAcceso);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }


        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            RegistroUsuarioForm registroForm = new RegistroUsuarioForm();
            registroForm.Show();
        }
    }
}

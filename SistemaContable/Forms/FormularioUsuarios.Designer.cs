using System;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaContable.Forms
{
    partial class FormularioUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvUsuarios = new DataGridView();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtNombre = new TextBox();
            txtApellidos = new TextBox();
            txtNivelAcceso = new TextBox();
            txtEmail = new TextBox();
            btnAgregarUsuario = new Button();
            btnActualizarUsuario = new Button();
            btnEliminarUsuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(20, 20);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(600, 200);
            dgvUsuarios.TabIndex = 9;
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.WhiteSmoke;
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Font = new Font("Arial", 10F);
            txtLogin.ForeColor = Color.DimGray;
            txtLogin.Location = new Point(20, 240);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Login";
            txtLogin.Size = new Size(200, 23);
            txtLogin.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.WhiteSmoke;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Arial", 10F);
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(20, 270);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.WhiteSmoke;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Arial", 10F);
            txtNombre.ForeColor = Color.DimGray;
            txtNombre.Location = new Point(20, 300);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtApellidos
            // 
            txtApellidos.BackColor = Color.WhiteSmoke;
            txtApellidos.BorderStyle = BorderStyle.FixedSingle;
            txtApellidos.Font = new Font("Arial", 10F);
            txtApellidos.ForeColor = Color.DimGray;
            txtApellidos.Location = new Point(20, 330);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.PlaceholderText = "Apellidos";
            txtApellidos.Size = new Size(200, 23);
            txtApellidos.TabIndex = 5;
            // 
            // txtNivelAcceso
            // 
            txtNivelAcceso.BackColor = Color.WhiteSmoke;
            txtNivelAcceso.BorderStyle = BorderStyle.FixedSingle;
            txtNivelAcceso.Font = new Font("Arial", 10F);
            txtNivelAcceso.ForeColor = Color.DimGray;
            txtNivelAcceso.Location = new Point(20, 360);
            txtNivelAcceso.Name = "txtNivelAcceso";
            txtNivelAcceso.PlaceholderText = "Nivel de Acceso";
            txtNivelAcceso.Size = new Size(200, 23);
            txtNivelAcceso.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Arial", 10F);
            txtEmail.ForeColor = Color.DimGray;
            txtEmail.Location = new Point(20, 390);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 3;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.BackColor = Color.SteelBlue;
            btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarUsuario.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuario.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnAgregarUsuario.ForeColor = Color.White;
            btnAgregarUsuario.Location = new Point(240, 240);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(120, 35);
            btnAgregarUsuario.TabIndex = 2;
            btnAgregarUsuario.Text = "Agregar Usuario";
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            btnAgregarUsuario.Click += new EventHandler(btnAgregarUsuario_Click);
            // 
            // btnActualizarUsuario
            // 
            btnActualizarUsuario.BackColor = Color.Orange;
            btnActualizarUsuario.FlatAppearance.BorderSize = 0;
            btnActualizarUsuario.FlatStyle = FlatStyle.Flat;
            btnActualizarUsuario.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnActualizarUsuario.ForeColor = Color.White;
            btnActualizarUsuario.Location = new Point(240, 300);
            btnActualizarUsuario.Name = "btnActualizarUsuario";
            btnActualizarUsuario.Size = new Size(120, 35);
            btnActualizarUsuario.TabIndex = 1;
            btnActualizarUsuario.Text = "Actualizar Usuario";
            btnActualizarUsuario.UseVisualStyleBackColor = false;
            btnActualizarUsuario.Click += new EventHandler(btnActualizarUsuario_Click);
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.BackColor = Color.Crimson;
            btnEliminarUsuario.FlatAppearance.BorderSize = 0;
            btnEliminarUsuario.FlatStyle = FlatStyle.Flat;
            btnEliminarUsuario.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnEliminarUsuario.ForeColor = Color.White;
            btnEliminarUsuario.Location = new Point(240, 360);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(120, 35);
            btnEliminarUsuario.TabIndex = 0;
            btnEliminarUsuario.Text = "Eliminar Usuario";
            btnEliminarUsuario.UseVisualStyleBackColor = false;
            btnEliminarUsuario.Click += new EventHandler(btnEliminarUsuario_Click);
            // 
            // FormularioUsuarios
            // 
            BackColor = Color.LightGray;
            ClientSize = new Size(650, 450);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(btnActualizarUsuario);
            Controls.Add(btnAgregarUsuario);
            Controls.Add(txtEmail);
            Controls.Add(txtNivelAcceso);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombre);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(dgvUsuarios);
            Name = "FormularioUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNivelAcceso;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.Button btnActualizarUsuario;
        private System.Windows.Forms.Button btnEliminarUsuario;
    }
}

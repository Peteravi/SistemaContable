using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaContable.Forms
{
    partial class RegistroUsuarioForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNivelAcceso;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblNivelAcceso;
        private System.Windows.Forms.Label lblEmail;

        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtNombre = new TextBox();
            txtApellidos = new TextBox();
            txtNivelAcceso = new TextBox();
            txtEmail = new TextBox();
            btnRegistrar = new Button();
            lblLogin = new Label();
            lblPassword = new Label();
            lblNombre = new Label();
            lblApellidos = new Label();
            lblNivelAcceso = new Label();
            lblEmail = new Label();
            SuspendLayout();
            // 
            // txtLogin
            // 
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Font = new Font("Segoe UI", 10F);
            txtLogin.Location = new Point(120, 40);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(200, 25);
            txtLogin.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(120, 80);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 25);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(120, 120);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 25);
            txtNombre.TabIndex = 2;
            // 
            // txtApellidos
            // 
            txtApellidos.BorderStyle = BorderStyle.FixedSingle;
            txtApellidos.Font = new Font("Segoe UI", 10F);
            txtApellidos.Location = new Point(120, 160);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(200, 25);
            txtApellidos.TabIndex = 3;
            // 
            // txtNivelAcceso
            // 
            txtNivelAcceso.BorderStyle = BorderStyle.FixedSingle;
            txtNivelAcceso.Font = new Font("Segoe UI", 10F);
            txtNivelAcceso.Location = new Point(134, 198);
            txtNivelAcceso.Name = "txtNivelAcceso";
            txtNivelAcceso.Size = new Size(200, 25);
            txtNivelAcceso.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(120, 240);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 25);
            txtEmail.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.MediumSeaGreen;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(120, 280);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(200, 35);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Registrar Usuario";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 10F);
            lblLogin.Location = new Point(40, 40);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(46, 19);
            lblLogin.TabIndex = 7;
            lblLogin.Text = "Login:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(40, 80);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 19);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F);
            lblNombre.Location = new Point(40, 120);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(62, 19);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Font = new Font("Segoe UI", 10F);
            lblApellidos.Location = new Point(40, 160);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(67, 19);
            lblApellidos.TabIndex = 10;
            lblApellidos.Text = "Apellidos:";
            // 
            // lblNivelAcceso
            // 
            lblNivelAcceso.AutoSize = true;
            lblNivelAcceso.Font = new Font("Segoe UI", 10F);
            lblNivelAcceso.Location = new Point(40, 200);
            lblNivelAcceso.Name = "lblNivelAcceso";
            lblNivelAcceso.Size = new Size(88, 19);
            lblNivelAcceso.TabIndex = 11;
            lblNivelAcceso.Text = "Nivel Acceso:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(40, 240);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 19);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email:";
            // 
            // RegistroUsuarioForm
            // 
            ClientSize = new Size(400, 350);
            Controls.Add(lblEmail);
            Controls.Add(lblNivelAcceso);
            Controls.Add(lblApellidos);
            Controls.Add(lblNombre);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Controls.Add(btnRegistrar);
            Controls.Add(txtEmail);
            Controls.Add(txtNivelAcceso);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombre);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Name = "RegistroUsuarioForm";
            Text = "Registrar Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

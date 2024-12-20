using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaContable.Forms
{
    public class FormBalanceGeneral : Form
    {
        private DataGridView dgvBalanceGeneral;
        private Button btnConsultar;
        private Label lblTitulo;
        private MySqlConnection conexion;

        public FormBalanceGeneral()
        {
            InitializeComponent();
            InicializarConexion();
        }

        private void InicializarConexion()
        {
            string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";
            conexion = new MySqlConnection(connectionString);
        }

        private void InitializeComponent()
        {
            this.dgvBalanceGeneral = new DataGridView();
            this.btnConsultar = new Button();
            this.lblTitulo = new Label();

            // Configuración del formulario
            this.ClientSize = new Size(800, 600);
            this.BackColor = Color.FromArgb(240, 243, 255);
            this.Text = "Balance General";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Título
            this.lblTitulo.Text = "Consulta de Balance General";
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitulo.Dock = DockStyle.Top;
            this.lblTitulo.Height = 50;

            // DataGridView
            this.dgvBalanceGeneral.Location = new Point(50, 100);
            this.dgvBalanceGeneral.Size = new Size(700, 400);
            this.dgvBalanceGeneral.BackgroundColor = Color.White;
            this.dgvBalanceGeneral.BorderStyle = BorderStyle.Fixed3D;
            this.dgvBalanceGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Botón Consultar
            this.btnConsultar.Text = "Consultar Balance";
            this.btnConsultar.BackColor = Color.FromArgb(52, 152, 219);
            this.btnConsultar.ForeColor = Color.White;
            this.btnConsultar.FlatStyle = FlatStyle.Flat;
            this.btnConsultar.Location = new Point(50, 520);
            this.btnConsultar.Size = new Size(200, 40);
            this.btnConsultar.Click += new EventHandler(this.btnConsultar_Click);

            // Añadir controles al formulario
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvBalanceGeneral);
            this.Controls.Add(this.btnConsultar);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string query = @"
                    SELECT 
                        c.No_Cta AS NumeroCuenta,
                        c.Descripcion_Cta AS DescripcionCuenta,
                        c.Tipo_Cta_ID AS TipoCuenta,
                        SUM(t.Valor_Debito) AS TotalDebito,
                        SUM(t.Valor_Credito) AS TotalCredito,
                        (SUM(t.Valor_Debito) - SUM(t.Valor_Credito)) AS Balance
                    FROM 
                        sistemcontable.catalogo_cuenta_contable c
                    LEFT JOIN 
                        sistemcontable.transaccion_contable t 
                    ON 
                        c.No_Cta = t.Cuenta_Contable
                    GROUP BY 
                        c.No_Cta, c.Descripcion_Cta, c.Tipo_Cta_ID
                    ORDER BY 
                        c.No_Cta;";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvBalanceGeneral.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

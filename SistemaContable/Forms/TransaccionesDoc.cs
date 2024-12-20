using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaContable.Forms
{
    public partial class TransaccionesDoc : Form
    {
        private string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";

        private DataGridView dgvTransacciones;
        private TextBox txtNroDocumento;
        private Button btnBuscar;
        private Label lblNroDocumento;
        private GroupBox grpBusqueda;

        public TransaccionesDoc()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dgvTransacciones = new DataGridView();
            this.txtNroDocumento = new TextBox();
            this.btnBuscar = new Button();
            this.lblNroDocumento = new Label();
            this.grpBusqueda = new GroupBox();

            // Configuración del DataGridView
            this.dgvTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacciones.Location = new Point(20, 100);
            this.dgvTransacciones.Name = "dgvTransacciones";
            this.dgvTransacciones.Size = new Size(760, 250);
            this.dgvTransacciones.TabIndex = 0;

            // Configuración del Label
            this.lblNroDocumento.Text = "Número de Documento:";
            this.lblNroDocumento.Location = new Point(15, 30);
            this.lblNroDocumento.AutoSize = true;
            this.lblNroDocumento.Font = new Font("Arial", 10, FontStyle.Bold);

            // Configuración del TextBox para el número de documento
            this.txtNroDocumento.Location = new Point(180, 25);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new Size(200, 20);
            this.txtNroDocumento.TabIndex = 1;

            // Configuración del botón de búsqueda
            this.btnBuscar.Location = new Point(400, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new Size(100, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Font = new Font("Arial", 9, FontStyle.Bold);
            this.btnBuscar.Click += new EventHandler(this.BtnBuscar_Click);

            // Configuración del GroupBox para agrupar los controles de búsqueda
            this.grpBusqueda.Text = "Búsqueda";
            this.grpBusqueda.Location = new Point(20, 20);
            this.grpBusqueda.Size = new Size(760, 60);
            this.grpBusqueda.Font = new Font("Arial", 10, FontStyle.Bold);
            this.grpBusqueda.Controls.Add(this.lblNroDocumento);
            this.grpBusqueda.Controls.Add(this.txtNroDocumento);
            this.grpBusqueda.Controls.Add(this.btnBuscar);

            // Configuración del formulario
            this.ClientSize = new Size(800, 400);
            this.Controls.Add(this.dgvTransacciones);
            this.Controls.Add(this.grpBusqueda);
            this.Name = "TransaccionesPorDocumento";
            this.Text = "Consultas de Transacciones por Documento";

            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).EndInit();
            this.ResumeLayout(false);
        }

        // Evento de búsqueda
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string nroDocumento = txtNroDocumento.Text.Trim();
            if (!string.IsNullOrEmpty(nroDocumento))
            {
                BuscarTransaccionesPorDocumento(nroDocumento);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número de documento para realizar la búsqueda.");
            }
        }

        // Método para cargar las transacciones por número de documento desde la base de datos
        private void BuscarTransaccionesPorDocumento(string nroDocumento)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Consulta SQL para obtener transacciones por número de documento
                    string query = "SELECT Nro_Docu, Descripcion_Docu, Fecha_Docu, Tipo_Entrada, Monto_Transaccion " +
                                   "FROM cabecera_transaccion WHERE Nro_Docu = @NroDocumento";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@NroDocumento", nroDocumento);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Verificar si el DataTable contiene datos
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        // Asignar los resultados al DataGridView
                        dgvTransacciones.DataSource = dataTable;
                    }
                    else
                    {
                        // Si no se encuentran transacciones, mostrar un mensaje
                        MessageBox.Show("No se encontraron transacciones con el número de documento especificado.");
                        dgvTransacciones.DataSource = null; // Limpiar el DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las transacciones: " + ex.Message);
            }
        }
    }
}

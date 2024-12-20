using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EstadoGananciasPerdidas
{
    public class FormEstadoGananciasPerdidas : Form
    {
        private DataGridView dgvResultados;
        private Button btnConsultar;

        // Cadena de conexión a la base de datos
        private readonly string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07;";

        public FormEstadoGananciasPerdidas()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            dgvResultados = new DataGridView();
            btnConsultar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();

            // 
            // dgvResultados
            // 
            dgvResultados.Location = new Point(38, 80); // Ajustado para más espacio en la parte superior
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Size = new Size(600, 250); // Aumento el tamaño para hacer la vista más cómoda
            dgvResultados.TabIndex = 1;
            dgvResultados.BackgroundColor = Color.White; // Fondo blanco
            dgvResultados.BorderStyle = BorderStyle.Fixed3D; // Borde alrededor del DataGridView
            dgvResultados.DefaultCellStyle.Font = new Font("Arial", 10); // Fuente para el texto de las celdas
            dgvResultados.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Filas alternas en gris claro
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar las columnas al tamaño de la tabla
            dgvResultados.RowHeadersVisible = false; // Ocultar los encabezados de fila
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Ajustar la altura de los encabezados

            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(38, 350); // Ubicado debajo del DataGridView
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(100, 40); // Aumento el tamaño del botón para hacerlo más visible
            btnConsultar.TabIndex = 0;
            btnConsultar.Text = "Consultar";
            btnConsultar.Font = new Font("Arial", 12, FontStyle.Bold); // Fuente más grande y en negrita
            btnConsultar.BackColor = Color.Blue; // Fondo azul para el botón
            btnConsultar.ForeColor = Color.White; // Texto blanco
            btnConsultar.FlatStyle = FlatStyle.Flat; // Sin bordes
            btnConsultar.Click += BtnConsultar_Click;

            // 
            // FormEstadoGananciasPerdidas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 413);
            Controls.Add(btnConsultar);
            Controls.Add(dgvResultados);
            Name = "FormEstadoGananciasPerdidas";
            Text = "Estado de Ganancias y Pérdidas";
            StartPosition = FormStartPosition.CenterScreen; // Centrar la ventana en la pantalla
            Icon = SystemIcons.Information; // Icono de la ventana
            BackColor = Color.LightBlue; // Fondo de la ventana
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL
                    string query = @"
                        SELECT 
                            ct.Descripcion_Cta AS 'Cuenta',
                            SUM(tc.Valor_Debito) AS 'Total Débito',
                            SUM(tc.Valor_Credito) AS 'Total Crédito',
                            (SUM(tc.Valor_Debito) - SUM(tc.Valor_Credito)) AS 'Balance'
                        FROM 
                            transaccion_contable tc
                        INNER JOIN 
                            catalogo_cuenta_contable ct ON tc.Cuenta_Contable = ct.No_Cta
                        WHERE 
                            ct.Grupo_Cta IN (3, 4, 5) -- Grupos de cuentas relacionadas con ingresos y egresos
                        GROUP BY 
                            tc.Cuenta_Contable;";

                    // Carga de datos en el DataGridView
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvResultados.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaContable.Models.SistemaContable.Models.SistemaContable.Models;

namespace SistemaContable.Forms
{
    public partial class CatalogoCuentas : Form
    {
        private static readonly string connectionString = "Server=localhost; Database=sistemcontable; Uid=root; Pwd=piteravi07";
        private List<CuentaContable> cuentasContables;

        public CatalogoCuentas()
        {
            InitializeComponent();
            cuentasContables = new List<CuentaContable>();
            CargarCuentas();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private void CargarCuentas()
        {
            try
            {
                cuentasContables = ObtenerCuentasDB();
                dgvCuentasContables.Rows.Clear();

                foreach (var cuenta in cuentasContables)
                {
                    string tipoCuenta = cuenta.Tipo_Cta_ID == 1 ? "General" : "Detalle";

                    dgvCuentasContables.Rows.Add(
                        cuenta.No_Cta,
                        cuenta.Descripcion_Cta,
                        tipoCuenta,
                        cuenta.Nivel_Cta,
                        cuenta.Grupo_Cta,
                        cuenta.Fecha_Creacion_Cta.ToShortDateString(),
                        cuenta.Debito_Acumulado,
                        cuenta.Credito_Acumulado,
                        cuenta.Balance
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las cuentas: {ex.Message}");
            }
        }

        private List<CuentaContable> ObtenerCuentasDB()
        {
            var cuentas = new List<CuentaContable>();

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT No_Cta, Descripcion_Cta, Tipo_Cta_ID, Nivel_Cta, Grupo_Cta, Fecha_Creacion_Cta, Debito_Acum_Cta, Credito_Acum_Cta, Balance_Cta, Cta_Padre " +
                                   "FROM catalogo_cuenta_contable;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Verificar cada valor por DBNull antes de intentar obtenerlo
                                int? ctaPadre = reader.IsDBNull(reader.GetOrdinal("Cta_Padre")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Cta_Padre"));
                                int noCta = reader.GetInt32(reader.GetOrdinal("No_Cta"));
                                string descripcionCta = reader.GetString(reader.GetOrdinal("Descripcion_Cta"));
                                int tipoCtaID = reader.GetInt32(reader.GetOrdinal("Tipo_Cta_ID"));
                                int nivelCta = reader.GetInt32(reader.GetOrdinal("Nivel_Cta"));
                                int grupoCta = reader.GetInt32(reader.GetOrdinal("Grupo_Cta"));
                                DateTime fechaCreacionCta = reader.GetDateTime(reader.GetOrdinal("Fecha_Creacion_Cta"));
                                decimal debitoAcumCta = reader.IsDBNull(reader.GetOrdinal("Debito_Acum_Cta")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Debito_Acum_Cta"));
                                decimal creditoAcumCta = reader.IsDBNull(reader.GetOrdinal("Credito_Acum_Cta")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Credito_Acum_Cta"));
                                decimal balanceCta = reader.IsDBNull(reader.GetOrdinal("Balance_Cta")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Balance_Cta"));

                                cuentas.Add(new CuentaContable(
                                    noCta,
                                    descripcionCta,
                                    tipoCtaID,
                                    nivelCta,
                                    ctaPadre,
                                    grupoCta,
                                    fechaCreacionCta,
                                    debitoAcumCta,
                                    creditoAcumCta,
                                    balanceCta
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las cuentas de la base de datos: {ex.Message}");
            }

            return cuentas;
        }

        #region Código generado por el Diseñador de Windows Forms

        private System.Windows.Forms.DataGridView dgvCuentasContables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNivelCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupoCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebitoAcumulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreditoAcumulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;

        private void InitializeComponent()
        {
            this.dgvCuentasContables = new System.Windows.Forms.DataGridView();
            this.colNoCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNivelCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupoCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebitoAcumulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreditoAcumulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasContables)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvCuentasContables
            // 
            this.dgvCuentasContables.AllowUserToAddRows = false;
            this.dgvCuentasContables.AllowUserToDeleteRows = false;
            this.dgvCuentasContables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentasContables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        this.colNoCta,
        this.colDescripcionCta,
        this.colTipoCuenta,
        this.colNivelCta,
        this.colGrupoCta,
        this.colFechaCreacion,
        this.colDebitoAcumulado,
        this.colCreditoAcumulado,
        this.colBalance});
            this.dgvCuentasContables.Location = new System.Drawing.Point(12, 12);
            this.dgvCuentasContables.Name = "dgvCuentasContables";
            this.dgvCuentasContables.ReadOnly = true;
            this.dgvCuentasContables.Size = new System.Drawing.Size(960, 450);
            this.dgvCuentasContables.TabIndex = 0;

            // Configurar las columnas
            this.colNoCta.HeaderText = "Número de Cuenta";
            this.colDescripcionCta.HeaderText = "Descripción";
            this.colTipoCuenta.HeaderText = "Tipo de Cuenta";
            this.colNivelCta.HeaderText = "Nivel de Cuenta";
            this.colGrupoCta.HeaderText = "Grupo de Cuenta";
            this.colFechaCreacion.HeaderText = "Fecha de Creación";
            this.colDebitoAcumulado.HeaderText = "Débito Acumulado";
            this.colCreditoAcumulado.HeaderText = "Crédito Acumulado";
            this.colBalance.HeaderText = "Balance";

            // Alineación del texto en las celdas
            this.colNoCta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colDescripcionCta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.colTipoCuenta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colNivelCta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colGrupoCta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colFechaCreacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colDebitoAcumulado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colCreditoAcumulado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.colBalance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Estilo de la cabecera de las columnas
            this.dgvCuentasContables.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvCuentasContables.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCuentasContables.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.dgvCuentasContables.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar el tamaño de las columnas automáticamente
            this.dgvCuentasContables.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.dgvCuentasContables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // CatalogoCuentas
            // 
            this.ClientSize = new System.Drawing.Size(984, 481);
            this.Controls.Add(this.dgvCuentasContables);
            this.Name = "CatalogoCuentas";
            this.Text = "Catálogo de Cuentas Contables";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentasContables)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

    }

}

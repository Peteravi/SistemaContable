// Archivo principal: TransaccionContableForm.cs
using SistemaContable.Controllers;
using SistemaContable.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaContable.Forms
{
    public partial class TransaccionContableForm : Form
    {
        private TransaccionContableController controller;

        public TransaccionContableForm()
        {
            InitializeComponent();
            controller = new TransaccionContableController();
            DefinirColumnas();
            CargarTransacciones();
        }

        private void DefinirColumnas()
        {
            dataGridViewTransacciones.Columns.Clear();

            dataGridViewTransacciones.Columns.Add("NroDoc", "Número de Documento");
            dataGridViewTransacciones.Columns.Add("SecuenciaDoc", "Secuencia Documento");
            dataGridViewTransacciones.Columns.Add("CuentaContable", "Cuenta Contable");
            dataGridViewTransacciones.Columns.Add("ValorDebito", "Valor Débito");
            dataGridViewTransacciones.Columns.Add("ValorCredito", "Valor Crédito");
            dataGridViewTransacciones.Columns.Add("Comentario", "Comentario");

            dataGridViewTransacciones.Columns["NroDoc"].Width = 100;
            dataGridViewTransacciones.Columns["SecuenciaDoc"].Width = 100;
            dataGridViewTransacciones.Columns["CuentaContable"].Width = 150;
            dataGridViewTransacciones.Columns["ValorDebito"].Width = 100;
            dataGridViewTransacciones.Columns["ValorCredito"].Width = 100;
            dataGridViewTransacciones.Columns["Comentario"].Width = 200;
        }

        private void CargarTransacciones()
        {
            dataGridViewTransacciones.Rows.Clear();
            List<TransaccionContable> transacciones = controller.ObtenerTransacciones();

            foreach (var transaccion in transacciones)
            {
                dataGridViewTransacciones.Rows.Add(
                    transaccion.NroDoc,
                    transaccion.SecuenciaDoc,
                    transaccion.CuentaContable,
                    transaccion.ValorDebito,
                    transaccion.ValorCredito,
                    transaccion.Comentario
                );
            }
        }

        private void btnCierreDiario_Click (object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePickerInicio.Value;
            DateTime fechaFin = dateTimePickerFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool exito = controller.RealizarCierreDiario(fechaInicio, fechaFin);

            if (exito)
            {
                MessageBox.Show("Cierre diario realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTransacciones();
            }
            else
            {
                MessageBox.Show("Error al realizar el cierre diario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTransacciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewTransacciones.Rows[e.RowIndex];
                txtNroDoc.Text = row.Cells[0].Value.ToString();
                txtSecuenciaDoc.Text = row.Cells[1].Value.ToString();
                txtCuentaContable.Text = row.Cells[2].Value.ToString();
                txtValorDebito.Text = row.Cells[3].Value.ToString();
                txtValorCredito.Text = row.Cells[4].Value.ToString();
                txtComentario.Text = row.Cells[5].Value.ToString();
            }
        }

        // Evento para agregar una nueva transacción
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevaTransaccion = new TransaccionContable(
                    txtNroDoc.Text,
                    int.Parse(txtSecuenciaDoc.Text),
                    int.Parse(txtCuentaContable.Text),
                    double.Parse(txtValorDebito.Text),
                    double.Parse(txtValorCredito.Text),
                    txtComentario.Text
                );

                controller.CrearTransaccion(nuevaTransaccion);
                CargarTransacciones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la transacción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para actualizar una transacción
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var transaccion = new TransaccionContable(
                    txtNroDoc.Text,
                    int.Parse(txtSecuenciaDoc.Text),
                    int.Parse(txtCuentaContable.Text),
                    double.Parse(txtValorDebito.Text),
                    double.Parse(txtValorCredito.Text),
                    txtComentario.Text
                );

                controller.ActualizarTransaccion(transaccion);
                CargarTransacciones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la transacción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar una transacción
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string nroDoc = txtNroDoc.Text;
                int secuenciaDoc = int.Parse(txtSecuenciaDoc.Text);

                controller.EliminarTransaccion(nroDoc, secuenciaDoc);
                CargarTransacciones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la transacción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNroDoc.Clear();
            txtSecuenciaDoc.Clear();
            txtCuentaContable.Clear();
            txtValorDebito.Clear();
            txtValorCredito.Clear();
            txtComentario.Clear();
        }
    }
}

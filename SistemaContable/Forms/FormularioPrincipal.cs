using EstadoGananciasPerdidas;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaContable.Forms
{
    public partial class FormularioPrincipal : Form
    {
        // Definición de colores y estilos
        private Color backgroundColor = Color.FromArgb(240, 248, 255); // AliceBlue
        private Color menuBackColor = Color.FromArgb(70, 130, 180); // SteelBlue
        private Color menuForeColor = Color.WhiteSmoke;
        private Font menuFont = new Font("Segoe UI", 10F, FontStyle.Bold);

        private string nivelAcceso;

        public FormularioPrincipal(string nivelAcceso)
        {
            this.nivelAcceso = nivelAcceso;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Menú principal
            MenuStrip menuStrip = new MenuStrip
            {
                BackColor = menuBackColor,
                Font = menuFont,
                ForeColor = menuForeColor,
                Dock = DockStyle.Top,
            };

            // Crear menús
            ToolStripMenuItem mantenimientosMenu = new ToolStripMenuItem("Mantenimientos");
            ToolStripMenuItem movimientoMenu = new ToolStripMenuItem("Movimiento");
            ToolStripMenuItem procesosMenu = new ToolStripMenuItem("Procesos");
            ToolStripMenuItem consultasMenu = new ToolStripMenuItem("Consultas");

            // Submenús de Mantenimientos
            mantenimientosMenu.DropDownItems.Add("Catálogo de cuenta").Click += MenuMantenimientosCatalogoCuenta_Click;
            mantenimientosMenu.DropDownItems.Add("Usuarios").Click += MenuMantenimientosUsuarios_Click;
            mantenimientosMenu.DropDownItems.Add("Tipo Entrada de Diario").Click += MenuMantenimientosTipoEntrada_Click;

            // Submenús de Movimiento
            movimientoMenu.DropDownItems.Add("Transacciones").Click += MenuMovimientoTransacciones_Click;

            // Submenús de Procesos
            procesosMenu.DropDownItems.Add("Cierre de Diario por fechas").Click += MenuProcesosCierreDiario_Click;
            procesosMenu.DropDownItems.Add("Cierre de fin de año fiscal").Click += MenuProcesosCierreFiscal_Click;

            // Submenús de Consultas
            consultasMenu.DropDownItems.Add("Catálogo de cuenta").Click += MenuConsultasCatalogoCuenta_Click;
            consultasMenu.DropDownItems.Add("Transacciones por Fecha").Click += MenuConsultasTransaccionesFecha_Click;
            consultasMenu.DropDownItems.Add("Transacciones por Documento").Click += MenuConsultasTransaccionesDoc_Click;
            consultasMenu.DropDownItems.Add("Transacciones por Rango de Fechas").Click += MenuConsultasTransaccionesRangoFechas_Click;
            consultasMenu.DropDownItems.Add("Balanza General").Click += MenuConsultasBalanzaGeneral_Click;
            consultasMenu.DropDownItems.Add("Resumen de Gastos Generales").Click += MenuConsultasResumenGastos_Click;
            consultasMenu.DropDownItems.Add("Estado de Ganancias y Pérdidas").Click += MenuConsultasGanancias_Click;

            // Agregar menús al menú principal
            menuStrip.Items.AddRange(new ToolStripItem[] { mantenimientosMenu, movimientoMenu, procesosMenu, consultasMenu });

            // Configurar el formulario
            ClientSize = new Size(800, 600);
            Controls.Add(menuStrip);
            BackColor = backgroundColor;
            MainMenuStrip = menuStrip;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Contable - Menú Principal";

            // Limitar acceso según el nivel de acceso
            LimitarAcceso(menuStrip);

            // Evento Load
            Load += FormularioPrincipal_Load;
        }

        // Evento Load del formulario
        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
        }

        // Métodos de eventos del menú Mantenimientos
        private void MenuMantenimientosCatalogoCuenta_Click(object sender, EventArgs e)
        {
            FormularioCuentasContables cuentacontable = new FormularioCuentasContables();
            cuentacontable.Show();
        }

        private void MenuMantenimientosUsuarios_Click(object sender, EventArgs e)
        {
            FormularioUsuarios formularioUsuario = new FormularioUsuarios();
            formularioUsuario.Show();
        }

        private void MenuMantenimientosTipoEntrada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mantenimiento - Tipo Entrada de Diario seleccionado.", "Mantenimientos");
        }

        // Métodos de eventos del menú Movimiento
        private void MenuMovimientoTransacciones_Click(object sender, EventArgs e)
        {
            FormularioTransacciones formulariotransacciones = new FormularioTransacciones();
            formulariotransacciones.Show();
        }

        // Métodos de eventos del menú Procesos
        private void MenuProcesosCierreDiario_Click(object sender, EventArgs e)
        {
            TransaccionContableForm transaccionContableForm = new TransaccionContableForm();
            transaccionContableForm.Show();
        }

        private void MenuProcesosCierreFiscal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proceso - Cierre de fin de año fiscal seleccionado.", "Procesos");
        }

        // Métodos de eventos del menú Consultas
        private void MenuConsultasCatalogoCuenta_Click(object sender, EventArgs e)
        {
            CatalogoCuentas catalogoCuentas = new CatalogoCuentas();
            catalogoCuentas.Show();
        }

        private void MenuConsultasTransaccionesFecha_Click(object sender, EventArgs e)
        {
            TransaccionesFecha transaccionesFecha = new TransaccionesFecha();
            transaccionesFecha.Show();
        }

        private void MenuConsultasTransaccionesDoc_Click(object sender, EventArgs e)
        {
            TransaccionesDoc transaccionesDoc = new TransaccionesDoc();
            transaccionesDoc.Show();
        }

        private void MenuConsultasTransaccionesRangoFechas_Click(object sender, EventArgs e)
        {
            TransaccionesRangoFecha rangoFechas = new TransaccionesRangoFecha();
            rangoFechas.Show();
        }

        private void MenuConsultasBalanzaGeneral_Click(object sender, EventArgs e)
        {
           FormBalanceGeneral general = new FormBalanceGeneral();
            general.Show();
        }

        private void MenuConsultasResumenGastos_Click(object sender, EventArgs e)
        {
            FormGastosGenerales generalgastos = new FormGastosGenerales();
            generalgastos.Show();
        }

        private void MenuConsultasGanancias_Click(object sender, EventArgs e)
        {
            FormEstadoGananciasPerdidas formEstadoGanancias = new FormEstadoGananciasPerdidas();
            formEstadoGanancias.Show();
        }

        // Método para limitar el acceso según el nivel de acceso del usuario
        internal void LimitarAcceso(MenuStrip menuStrip)
        {
            // Si el usuario es "Normal", se deshabilitan algunas opciones del menú
            if (nivelAcceso == "Normal")
            {
                foreach (ToolStripMenuItem menu in menuStrip.Items.OfType<ToolStripMenuItem>())
                {
                    if (menu.Text == "Mantenimientos" || menu.Text == "Procesos")
                    {
                        menu.Enabled = false;
                    }
                }
            }
        }
    }
}

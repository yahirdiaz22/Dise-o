using System;
using System.Windows;

namespace Diseño
{
    public partial class ConsultarCredito : Window
    {
        public ConsultarCredito()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;

            // Cargar directamente los datos del cliente
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            // Simulación de datos del cliente
            string cliente = "Yahir Diaz";
            double creditoInicial = 3000.00;
            double saldoPendiente = 1000.00;
            DateTime fechaVencimiento = new DateTime(2024, 11, 10);
            double montoTotal = 4000.00;

            // Asignar los datos a los TextBlocks
            txtResultado.Text = $"Información de crédito para el cliente: {cliente}";
            txtCreditoInicial.Text = $"Crédito Inicial: ${creditoInicial:F2}";
            txtSaldoPendiente.Text = $"Saldo Pendiente: ${saldoPendiente:F2}";
            txtFechaVencimiento.Text = $"Fecha de Vencimiento: {fechaVencimiento:dd/MM/yyyy}";
            txtMontoTotal.Text = $"Monto Total: ${montoTotal:F2}";

            // Asegurarse de que los controles sean visibles
            stackPanelDetalles.Visibility = Visibility.Visible;
        }

        private void RegresarMenu_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar la ventana actual y regresar al menú principal
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}

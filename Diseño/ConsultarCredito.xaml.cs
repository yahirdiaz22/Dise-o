using System;
using System.Windows;

namespace Diseño
{
    public partial class ConsultarCredito : Window
    {
        // Suponiendo que tienes un crédito inicial de $3000
        private const decimal creditoInicial = 3000.00m;
        private decimal saldoPendiente = 3000.00m; // Saldo inicial igual al crédito
        private DateTime fechaVencimiento = DateTime.Now.AddMonths(1); // Vencimiento en un mes
        private decimal montoTotal = 3000.00m; // Se asume que el monto total es igual al crédito inicial al principio

        public ConsultarCredito()
        {
            InitializeComponent();
        }

        private void ConsultarCredito_Click(object sender, RoutedEventArgs e)
        {
            string nombreCliente = txtNombreCliente.Text.Trim();

            if (string.IsNullOrEmpty(nombreCliente))
            {
                txtError.Visibility = Visibility.Visible;
                txtError.Text = "Por favor, ingrese el nombre del cliente.";
                stackPanelDetalles.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Ocultar mensaje de error si el nombre es válido
                txtError.Visibility = Visibility.Collapsed;

                // Mostrar los detalles del crédito
                txtCreditoInicial.Text = $"Crédito Inicial: ${creditoInicial:0.00}";
                txtSaldoPendiente.Text = $"Saldo Pendiente: ${saldoPendiente:0.00}";
                txtFechaVencimiento.Text = $"Fecha de Vencimiento: {fechaVencimiento:dd/MM/yyyy}";
                txtMontoTotal.Text = $"Monto Total: ${montoTotal:0.00}";

                // Hacer visible el stack panel que contiene los detalles del crédito
                stackPanelDetalles.Visibility = Visibility.Visible;
            }
        }

        private void RegresarMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Menu menu = new Menu();
            menu.Show();
        }
    }
}

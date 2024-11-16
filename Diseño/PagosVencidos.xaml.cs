using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Diseño
{
    public partial class PagosVencidos : Window
    {
        // Lista que simula los datos de pagos vencidos
        public List<PagoVencido> PagosVencidosList { get; set; }

        public PagosVencidos()
        {
            InitializeComponent();

            // Inicializamos la lista de pagos vencidos, pero no la asignamos aún al DataGrid
            PagosVencidosList = new List<PagoVencido>
            {
                new PagoVencido { Cliente = "Yahir Diaz", Monto = 1500.00, FechaVencimiento = new DateTime(2024, 11, 10), SaldoPendiente = 500.00 },
                new PagoVencido { Cliente = "Yahir Diaz", Monto = 3000.00, FechaVencimiento = new DateTime(2024, 10, 15), SaldoPendiente = 3000.00 },
                new PagoVencido { Cliente = "Yahir Diaz", Monto = 2000.00, FechaVencimiento = new DateTime(2024, 09, 20), SaldoPendiente = 1000.00 }
            };

            // No se asigna nada aún al DataGrid
            dgPagosVencidos.ItemsSource = null;
        }

        // Método que se ejecuta cuando el usuario hace clic en "Consultar"
        private void ConsultarPagos_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el nombre del cliente del campo de texto
            string cliente = txtNombreCliente.Text.Trim();

            if (string.IsNullOrEmpty(cliente))
            {
                MessageBox.Show("Por favor, ingresa un nombre de cliente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Filtrar los pagos vencidos para el cliente ingresado
            var pagosFiltrados = PagosVencidosList.Where(p => p.Cliente.Contains(cliente, StringComparison.OrdinalIgnoreCase)).ToList();

            // Asignar los pagos filtrados al DataGrid
            if (pagosFiltrados.Any())
            {
                dgPagosVencidos.ItemsSource = pagosFiltrados;
            }
            else
            {
                MessageBox.Show("No se encontraron pagos vencidos para el cliente ingresado.", "Sin resultados", MessageBoxButton.OK, MessageBoxImage.Information);
                dgPagosVencidos.ItemsSource = null; // Limpiar el DataGrid si no hay resultados
            }
        }

        // Método que se ejecuta cuando el usuario hace clic en "Regresar al Menú"
        private void RegresarMenu_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar la ventana actual y regresar al menú principal
            this.Close();
        Menu menu = new Menu();
            menu.Show();
        }

        // Método para manejar el cambio de texto en el TextBox (si es necesario para alguna lógica futura)
        private void txtNombreCliente_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Aquí podrías implementar alguna lógica adicional si se desea filtrar automáticamente mientras se escribe
        }
    }

    // Clase que representa los pagos vencidos
    public class PagoVencido
    {
        public string Cliente { get; set; }
        public double Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double SaldoPendiente { get; set; }
    }
}

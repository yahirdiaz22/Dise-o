using System;
using System.Collections.Generic;
using System.Windows;

namespace Diseño
{
    public partial class PagosVencidos : Window
    {
        // Lista que simula los datos de pagos vencidos
        public List<PagoVencido> PagosVencidosList { get; set; }

        public PagosVencidos()
        {
            this.WindowState = WindowState.Maximized;

            InitializeComponent();

            // Inicializamos la lista de pagos vencidos
            PagosVencidosList = new List<PagoVencido>
            {
                new PagoVencido { Cliente = "Yahir Diaz", Monto = 1500.00, FechaVencimiento = new DateTime(2024, 11, 10), SaldoPendiente = 500.00 },
                new PagoVencido { Cliente = "Yahir Diaz", Monto = 3000.00, FechaVencimiento = new DateTime(2024, 10, 15), SaldoPendiente = 3000.00 },
                new PagoVencido { Cliente = "Yahir Diaz", Monto = 2000.00, FechaVencimiento = new DateTime(2024, 09, 20), SaldoPendiente = 1000.00 }
            };

            // Asignar la lista completa de pagos vencidos al DataGrid
            dgPagosVencidos.ItemsSource = PagosVencidosList;
        }

        // Método para manejar el clic en "Pagar"
        private void Pagar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el pago vinculado al botón usando la propiedad Tag
            var button = sender as FrameworkElement;
            var pago = button?.DataContext as PagoVencido;

            if (pago != null)
            {
                // Mostrar un mensaje de confirmación
                MessageBox.Show($"El pago de {pago.Cliente} por un monto de {pago.SaldoPendiente:C} ha sido realizado.",
                                "Pago Realizado", MessageBoxButton.OK, MessageBoxImage.Information);

                // Eliminar el pago de la lista
                PagosVencidosList.Remove(pago);

                // Actualizar la fuente de datos del DataGrid
                dgPagosVencidos.ItemsSource = null; // Necesario para que se reflejen los cambios
                dgPagosVencidos.ItemsSource = PagosVencidosList;
            }
        }

        // Método para regresar al menú principal
        private void RegresarMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu(); // Asumiendo que tienes una ventana llamada Menu
            menu.Show();
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

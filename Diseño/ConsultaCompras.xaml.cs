using System.Collections.Generic;
using System.Windows;
using Diseño;  // Importa el espacio de nombres donde ya está definida la clase Carrito

namespace Diseño
{
    public partial class ConsultaCompras : Window
    {
        private List<Carrito> carrito;

        // Constructor que recibe la lista del carrito
        public ConsultaCompras(List<Carrito> carrito)
        {
            this.WindowState= WindowState.Maximized;
            InitializeComponent();
            this.carrito = carrito;
            CargarProductos();
        }

        // Método para cargar los productos en el DataGrid
        private void CargarProductos()
        {
            // Asignar la lista de productos al DataGrid
            ComprasDataGrid.ItemsSource = carrito;
        }

        private void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

    }
}

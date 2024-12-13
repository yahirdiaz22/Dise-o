using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Diseño;  // Esto importa el espacio de nombres donde se encuentra la clase Carrito

namespace Diseño
{
    public partial class Menu : Window
    {
        private List<Carrito> carrito = new List<Carrito>();
        private decimal creditoDisponible = 3000m; // Crédito disponible del cliente

        public Menu()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void PagosVencidosButton_Click(object sender, RoutedEventArgs e)
        {
            PagosVencidos pagosVencidos = new PagosVencidos();
            pagosVencidos.Show();
            this.Hide();
        }

        private void ConsultaCompraButton_Click(object sender, RoutedEventArgs e)
        {
   // Abre la ventana ConsultaCompras, pasando el carrito como parámetro
    ConsultaCompras consultaCompras = new ConsultaCompras(carrito);
    consultaCompras.Show();
    this.Hide();        }

        private void ConsultaCreditoButton_Click(object sender, RoutedEventArgs e)
        {
            ConsultarCredito consultarCredito = new ConsultarCredito();
            consultarCredito.Show();
            this.Hide();
        }

        private void ProximoPagoButton_Click(object sender, RoutedEventArgs e)
        {
            ProximoPago proximoPago = new ProximoPago();
            proximoPago.Show();
            this.Hide();
        }

        private void FechaCorteButton_Click(object sender, RoutedEventArgs e)
        {
            FechaCorte fecha = new FechaCorte();
            fecha.Show();
            this.Hide();
        }

        private void SolicitarAumentoCreditoButton_Click(object sender, RoutedEventArgs e)
        {
            SolicitarCredito solicitarCredito = new SolicitarCredito();
            solicitarCredito.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CarritoButton_Click(object sender, RoutedEventArgs e)
        {
            decimal total = carrito.Sum(p => p.Precio * p.Cantidad);

            // Verificar si el total excede el crédito disponible
            if (total > creditoDisponible)
            {
                // Si excede el crédito, mostrar un mensaje de error
                MessageBox.Show("¡Error! El total del carrito sobrepasa tu crédito disponible de $3000.", "Error de crédito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Si el pago es válido, mostrar un mensaje de éxito
                MessageBox.Show($"Pago exitoso. El total es ${total}. Tu pago se ha realizado correctamente.", "Pago realizado", MessageBoxButton.OK, MessageBoxImage.Information);

                // Actualizar el crédito disponible
                creditoDisponible -= total;

                // Limpiar el carrito después de realizar el pago
                ActualizarCarrito();  // Actualiza el botón del carrito para reflejar que está vacío
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Calcular el total actual del carrito
            decimal totalActual = carrito.Sum(p => p.Precio * p.Cantidad);

            // El precio del producto que se va a agregar
            decimal precioNuevoProducto = 3000;

            // Verificar si el total actual más el precio del nuevo producto excede el crédito disponible
            if (totalActual + precioNuevoProducto > creditoDisponible)
            {
                // Si el total excede, mostrar un mensaje de advertencia y no agregar el producto
                MessageBox.Show("¡No puedes agregar este producto! El total del carrito excede tu crédito disponible de $3000.", "Error de crédito", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Crear un nuevo producto para el carrito
                Carrito producto = new Carrito
                {
                    Nombre = "Relojes",
                    Precio = precioNuevoProducto, // El precio del reloj
                    Cantidad = 1 // Si es la primera vez que se agrega, la cantidad es 1
                };

                // Añadir el producto al carrito
                carrito.Add(producto);

                // Mostrar mensaje de que se ha agregado
                MessageBox.Show($"{producto.Nombre} se ha agregado al carrito.");

                // Actualizar el botón de carrito para mostrar el nombre, precio y cantidad
                ActualizarCarrito();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Calcular el total actual del carrito
            decimal totalActual = carrito.Sum(p => p.Precio * p.Cantidad);

            // El precio del producto que se va a agregar
            decimal precioNuevoProducto = 120;

            // Verificar si el total actual más el precio del nuevo producto excede el crédito disponible
            if (totalActual + precioNuevoProducto > creditoDisponible)
            {
                // Si el total excede, mostrar un mensaje de advertencia y no agregar el producto
                MessageBox.Show("¡No puedes agregar este producto! El total del carrito excede tu crédito disponible de $3000.", "Error de crédito", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Crear un nuevo producto para el carrito
                Carrito producto = new Carrito
                {
                    Nombre = "Playera",
                    Precio = precioNuevoProducto, // El precio de la playera
                    Cantidad = 1 // Si es la primera vez que se agrega, la cantidad es 1
                };

                // Añadir el producto al carrito
                carrito.Add(producto);

                // Mostrar mensaje de que se ha agregado
                MessageBox.Show($"{producto.Nombre} se ha agregado al carrito.");

                // Actualizar el botón de carrito para mostrar el nombre, precio y cantidad
                ActualizarCarrito();
            }
        }

        private void ActualizarCarrito()
        {
            // Calcular el total y la cantidad de productos
            decimal total = carrito.Sum(p => p.Precio * p.Cantidad);
            int cantidadTotal = carrito.Sum(p => p.Cantidad);

            // Actualizar el texto del botón del carrito
            CarritoButton.Content = $"Ver Carrito ({cantidadTotal} productos) - ${total}";
        }
    }

}

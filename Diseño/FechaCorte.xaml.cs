using System;
using System.Windows;

namespace Diseño
{
    public partial class FechaCorte : Window
    {
        public FechaCorte()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;

            // Configurar información de las fechas
            txtFechaCorte.Text = "15 de cada mes"; // Puedes calcular esto dinámicamente si lo deseas
            txtFechaLimitePago.Text = "5 del mes siguiente"; // Igual, dinámico si aplica
            txtDiasRestantes.Text = CalcularDiasRestantes(5) + " días";
        }

        // Método para calcular los días restantes para pagar
        private int CalcularDiasRestantes(int diaLimite)
        {
            var hoy = DateTime.Now;
            var fechaLimite = new DateTime(hoy.Year, hoy.Month, diaLimite);

            if (hoy.Day > diaLimite)
            {
                // Si ya pasó el día límite este mes, considerar el siguiente mes
                fechaLimite = fechaLimite.AddMonths(1);
            }

            return (fechaLimite - hoy).Days;
        }

        // Método para regresar al menú
        private void RegresarMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu(); // Asumiendo que tienes una ventana llamada Menu
            menu.Show();
        }
    }
}

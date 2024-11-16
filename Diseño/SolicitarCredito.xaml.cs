using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diseño
{
    /// <summary>
    /// Lógica de interacción para SolicitarCredito.xaml
    /// </summary>
    public partial class SolicitarCredito : Window
    {
        public SolicitarCredito()
        {
            InitializeComponent();
        }

        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
            MessageBox.Show("Solicitud enviada con éxito.","Solicitud Enviada",MessageBoxButton.OK,MessageBoxImage.Information);

        }

        private void BtnCargarINE_Click(object sender, RoutedEventArgs e)
        {
            // Crear un OpenFileDialog para seleccionar una imagen
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",  // Filtra solo imágenes
                Title = "Seleccionar Imagen de la INE"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Muestra la imagen seleccionada en el Image control
                imgINE.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                imgINE.Visibility = Visibility.Visible;  // Hace visible la imagen de la INE
                txtINE.Text = $"Imagen cargada: {openFileDialog.SafeFileName}";  // Muestra el nombre del archivo cargado
            }
        }

        private void BtnCargarComprobante_Click(object sender, RoutedEventArgs e)
        {
            // Crear un OpenFileDialog para seleccionar un archivo PDF
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",  // Filtra solo archivos PDF
                Title = "Seleccionar Comprobante de Domicilio"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Muestra el nombre del archivo PDF seleccionado
                txtComprobante.Text = $"Archivo cargado: {openFileDialog.SafeFileName}";
                imgComprobante.Visibility = Visibility.Collapsed;  // Esconde la imagen (no es necesaria para PDF)
            }
        }
    }
}

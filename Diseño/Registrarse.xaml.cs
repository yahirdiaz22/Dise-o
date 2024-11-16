using System;
using System.Windows;
using System.Windows.Input;

namespace Diseño
{
    public partial class Registrarse : Window
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        // Al dar Enter, se mueve al siguiente campo
        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EmailTextBox.Focus();
            }
        }

        private void EmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Validar si el correo es válido
                if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || !IsValidEmail(EmailTextBox.Text))
                {
                    MessageBox.Show("Correo electrónico inválido. Por favor ingresa un correo electrónico válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                PasswordBox.Focus(); // Si es válido, mover al siguiente campo
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmPasswordBox.Focus();
            }
        }

        private void ConfirmPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, e); // Llamar al evento del botón si todo está listo
            }
        }

        // Botón Cancelar (Volver a la ventana de inicio)
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Validar formulario y registrar
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Validación del nombre de usuario
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                MessageBox.Show("El nombre del usuario es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validación del correo
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || !IsValidEmail(EmailTextBox.Text))
            {
                MessageBox.Show("Correo electrónico inválido. Por favor ingresa un correo electrónico válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validación de la contraseña (mínimo 6 caracteres)
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (PasswordBox.Password.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validación de las contraseñas coincidentes
            if (PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Si todo es válido, mostrar mensaje de éxito
            MessageBox.Show("Registro exitoso.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            // Opcional: Aquí puedes redirigir a otra ventana o realizar otras acciones después de un registro exitoso.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Validar el formato del correo
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}

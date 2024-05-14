using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PIUG_Aplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateUsername(usernameTextBox.Text))
            {
                MessageBox.Show("Numele de utilizator trebuie să aibă între 3 și 20 de caractere.", "Eroare de validare", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ValidateEmail(emailTextBox.Text))
            {
                MessageBox.Show("Adresa de email nu este validă.", "Eroare de validare", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ValidatePassword(passwordBox.Password))
            {
                MessageBox.Show("Parola trebuie să conțină cel puțin 8 caractere și să includă cel puțin o literă mare, o literă mică, o cifră și un caracter special.", "Eroare de validare", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Înregistrare cu succes!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            Task_Manager task_Manager = new Task_Manager();
            task_Manager.Show();
            this.Close();
        }

        private bool ValidateUsername(string username)
        {
            return !string.IsNullOrEmpty(username) && username.Length >= 3 && username.Length <= 20;
        }

        private bool ValidateEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email,
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        private bool ValidatePassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 8 &&
                Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        }
    }
}

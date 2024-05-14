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

namespace PIUG_Aplicatie
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        public Quiz()
        {
            InitializeComponent();
        }

        private string GetSelectedRadioButtonText(StackPanel stackPanel)
        {
            foreach (UIElement element in stackPanel.Children)
            {
                if (element is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    return radioButton.Content.ToString();
                }
            }
            return ""; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Validare pentru întrebarea 1
            string raspunsCorect1 = "Java";
            string raspunsUtilizator1 = GetSelectedRadioButtonText(stackPanelIntrebare1);
            // Validare pentru întrebarea 2
            string raspunsCorect2 = "O instrucțiune care se repetă";
            string raspunsUtilizator2 = GetSelectedRadioButtonText(stackPanelIntrebare2);
            // Validare pentru întrebarea 3
            string raspunsCorect3 = "Structured Query Language";
            string raspunsUtilizator3 = GetSelectedRadioButtonText(stackPanelIntrebare3);
            // Validare pentru întrebarea 4
            string raspunsCorect4 = "MySQL";
            string raspunsUtilizator4 = GetSelectedRadioButtonText(stackPanelIntrebare4);
            // Validare pentru întrebarea 5
            string raspunsCorect5 = "Hyper Text Markup Language";
            string raspunsUtilizator5 = GetSelectedRadioButtonText(stackPanelIntrebare5);
            // Validare pentru întrebarea 6
            string raspunsCorect6 = "Bootstrap";
            string raspunsUtilizator6 = GetSelectedRadioButtonText(stackPanelIntrebare6);
            // Verificare și afișare rezultat
            if (raspunsUtilizator1 == raspunsCorect1 && raspunsUtilizator2 == raspunsCorect2 &&
                raspunsUtilizator3==raspunsCorect3 && raspunsUtilizator4==raspunsCorect4 &&
                raspunsUtilizator5==raspunsCorect5 && raspunsUtilizator6==raspunsCorect6)
            {
                MessageBox.Show("Toate răspunsurile sunt corecte!", "Validare", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Unul sau mai multe răspunsuri sunt incorecte. Te rog să verifici din nou.", "Validare", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pagina_Finala pagina_Finala = new Pagina_Finala();
            pagina_Finala.Show();
            this.Close();
        }
    }
}

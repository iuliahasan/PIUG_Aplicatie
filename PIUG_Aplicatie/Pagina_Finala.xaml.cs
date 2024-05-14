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
    /// Interaction logic for Pagina_Finala.xaml
    /// </summary>
    public partial class Pagina_Finala : Window
    {
        public Pagina_Finala()
        {
            InitializeComponent();
        }

        private void btnInchide_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

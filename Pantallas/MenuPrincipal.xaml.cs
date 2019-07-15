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

namespace Pantallas
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void AgregarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            AgregarVehiculo win = new AgregarVehiculo();
            win.Show();
        }

        private void SalidaDeVehiculo_Click(object sender, RoutedEventArgs e)
        {
            AgregarSalida win = new AgregarSalida();
            win.Show();

        }

        private void Historial_Click(object sender, RoutedEventArgs e)
        {
            Historial win = new Historial();
            win.Show();
        }
    }
}

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

using Estacionamiento;
using System.Data;

namespace Pantallas
{
    /// <summary>
    /// Lógica de interacción para AgregarSalida.xaml
    /// </summary>
    public partial class AgregarSalida : Window
    {
        public AgregarSalida()
        {
            InitializeComponent();
            //mostrar vehiculo

            DataTable dtv = EstacionamientoVehiculo.DesplegarVehiculo();

            IList<Vehiculo> V = new List<Vehiculo>();
            foreach (DataRow dr in dtv.Rows)
            {
                V.Add(new Vehiculo
                {
                    IdVehiculo = dr[0].ToString(),
                    Placa = dr[1].ToString(),
                    Tipo = dr[2].ToString(),

                });
            }
            ListaEntradas.ItemsSource = V;
        }

        private void ListaEntradas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public class Vehiculo
        {
            public string IdVehiculo { get; set; }
            public string Placa { get; set; }
            public string Tipo { get; set; }

        }

        private void Cobrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VHistorial_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

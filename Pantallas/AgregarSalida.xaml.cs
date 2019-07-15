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
        }

        private void ListaEntradas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //mostrar vehiculo

            /*DataTable dtv = EstacionamientoVehiculo.IngresarVehiculo();

            IList<Vehiculo> V = new List<Vehiculo>();
            foreach (DataRow dr in dtv.Rows)
            {
                V.Add(new Vehiculo
                {
                    IdVehiculo = dr[0].ToString(),
                    Placa = dr[1].ToString(),
                    Tipo = dr[2].ToString(),
                    HoraEntrada = dr[3].ToString(),


                });
            }
            lbVehiculo.ItemsSource = V;*/
        }
    }
}

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
    /// Lógica de interacción para Historial.xaml
    /// </summary>
    public partial class Historial : Window
    {
        public Historial()
        {
            InitializeComponent();

            DataTable dtv = EstacionamientoVehiculo.DesplegarDetalle();

            IList<Vehiculo> V = new List<Vehiculo>();
            foreach (DataRow dr in dtv.Rows)
            {
                V.Add(new Vehiculo
                {
                    Placa = dr[0].ToString(),
                    HoraEntrada = dr[1].ToString(),
                    HoraSalida  = dr[2].ToString(),
                    Tiempo = dr[3].ToString(),
                    Total = dr[4].ToString(),
                    Tipo = dr[5].ToString(),

                });
            }
            ListaHistorial.ItemsSource = V;
        }

        private void ListaHistorial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public class Vehiculo
        {
            public string Placa { get; set; }
            public string HoraEntrada { get; set; }
            public string HoraSalida { get; set; }
            public string Tiempo { get; set; }
            public string Total { get; set; }
            public string Tipo { get; set; }
    


        }



    }

 }


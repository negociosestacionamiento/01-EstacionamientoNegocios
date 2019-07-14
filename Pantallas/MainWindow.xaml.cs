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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Estacionamiento;
using System.Data;

namespace Pantallas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //mostrar vehiculo.tipo
            DataTable dtt = EstacionamientoTipoVehiculo.MostrarTipoVehiculo();

            IList<Tipos> t = new List<Tipos>();
            foreach (DataRow dr in dtt.Rows)
            {
                t.Add(new Tipos
                {
                    idTipo = dr[0].ToString(),
                    TipoNombre = dr[1].ToString(),

                });
            }
            lbTipoVehiculo.ItemsSource = t;

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
                    HoraEntrada = dr[3].ToString(),


                });
            }
            lbVehiculo.ItemsSource = V;

            //mostrar detalle

            DataTable dtd = EstacionamientoDetalle.DesplegarDetalleVehiculo();

            IList<Detalle> D = new List<Detalle>();
            foreach (DataRow dr in dtd.Rows)
            {
                D.Add(new Detalle
                {
                    Placa = dr[0].ToString(),
                    HoraEntrada = dr[1].ToString(),
                    TipoVehiculo = dr[2].ToString(),
                    HoraSalida = dr[3].ToString(),
                    Cobro = dr[4].ToString()

                });
            }
            lbVehiculoDetalle.ItemsSource = D;
        }
        public class Tipos
        {
            public string idTipo { get; set; }
            public string TipoNombre { get; set; }
        }
        public class Vehiculo
        {
            public string IdVehiculo { get; set; }
            public string Placa { get; set; }
            public string Tipo { get; set; }
            public string HoraEntrada { get; set; }
        }
        public class Detalle
        {
            public string Placa { get; set; }
            public string HoraEntrada { get; set; }
            public string TipoVehiculo { get; set; }
            public string HoraSalida { get; set; }
            public string Cobro { get; set; }
        }
    }
}

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

            InitializeComponent();
            DataTable dt = EstacionamientoTipoVehiculo.MostrarTipoVehiculo();

            IList<Tipos> V = new List<Tipos>();
            foreach (DataRow dr in dt.Rows)
            {
                V.Add(new Tipos
                {
                    nombre = dr[0].ToString(),

                });
            }
            lbTipoVehiculo.ItemsSource = V;

        }

        public class Tipos
        {
            public string nombre { get; set; }
        }
    }

}

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
using System.Data;
using System.Data.SqlClient;
using Clases_Datos;
using Estacionamiento;

namespace Pantallas
{
    /// <summary>
    /// Lógica de interacción para AgregarVehiculo.xaml
    /// </summary>
    public partial class AgregarVehiculo : Window
    {
  
        public AgregarVehiculo()
        {
            InitializeComponent();
            ComboTipo.DisplayMemberPath = "Nombre";
            ComboTipo.SelectedValuePath = "idTipo";
            ComboTipo.ItemsSource = EstacionamientoVehiculo.MostrarTipoVehiculo().DefaultView;
        }

        string opt = "";
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            opt = EstacionamientoVehiculo.IngresarVehiculo(txtPlaca.Text, Convert.ToInt32(ComboTipo.SelectedValue));
            MessageBox.Show(opt);

        }
    }
}

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
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
               

                string query = string.Format("REGISTRO_VEHICULO");
                SqlCommand command = new SqlCommand(query);

                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                using (adapter)
                {
                    command.Parameters.AddWithValue("@Placa", txtPlaca);
                    command.Parameters.AddWithValue("@Id", txtIdVehiculo);
                    command.Parameters.AddWithValue("@HoraEntrada", txtHoraEntrada);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tipo de vehiculo Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public class Vehiculo
        {
            public string IdVehiculo { get; set; }
            public string Placa { get; set; }
            public string Tipo { get; set; }
            public string HoraEntrada { get; set; }
        }
    }
}

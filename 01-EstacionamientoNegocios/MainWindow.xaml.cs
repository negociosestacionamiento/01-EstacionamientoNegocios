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
//Agregar los name spaces para SQL
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _01_EstacionamientoNegocios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //variable miembro
        SqlConnection sqlconnection;

        public MainWindow()
        {
            //EstacionamientoConnectionString
            string connectionString2 = @"server=DESKTOP-536T0JD\SQLEXPRESS; Initial Catalog = BD_ESTACIONAMIENTO_CM; Integrated Security = True;";

            sqlconnection = new SqlConnection(connectionString2);

            //MostarVehiculos();

            
            InitializeComponent();
            //starTipoVehiculos();
            MostarVehiculo2();
        }
        private void MostarVehiculos()
        {
            try
            {

                // El query ha realizar en la BD
                string query = "SELECT * FROM Estacionamiento.Vehiculo";

                // SqlDataAdapter es una interfaz entre las tablas y los objetos utilizables en C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    // Objecto en C# que refleja una tabla de una BD
                    DataTable tablaVehiculo = new DataTable();

                    //llenar el objeto de tipo Datatable
                    sqlDataAdapter.Fill(tablaVehiculo);

                    // ¿Cuál información de la tabla en el DataTable debería se desplegada en nuestro ListBox?
                    lsbInfo.DisplayMemberPath = "Placa";
                    // ¿Qué valor debe ser entregado cuando un elemento de nuestro ListBox es seleccionado?
                    lsbInfo.SelectedValuePath = "idVehiculo";
                    // ¿Quién es la referencia de los datos para el ListBox (popular)
                    lsbInfo.ItemsSource = tablaVehiculo.DefaultView;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void MostarTipoVehiculos()
        {
            try
            {

                // El query ha realizar en la BD
                string query = "SELECT * FROM Estacionamiento.TipoVehiculo";

                // SqlDataAdapter es una interfaz entre las tablas y los objetos utilizables en C#
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    // Objecto en C# que refleja una tabla de una BD
                    DataTable tablaTipoVehiculo = new DataTable();

                    //llenar el objeto de tipo Datatable
                    sqlDataAdapter.Fill(tablaTipoVehiculo);

                    // ¿Cuál información de la tabla en el DataTable debería se desplegada en nuestro ListBox?
                    lsbInfo.DisplayMemberPath = "Nombre"; //aqui esta el error
                    // ¿Qué valor debe ser entregado cuando un elemento de nuestro ListBox es seleccionado?
                    lsbInfo.SelectedValuePath = "idTipo";
                    // ¿Quién es la referencia de los datos para el ListBox (popular)
                    lsbInfo.ItemsSource = tablaTipoVehiculo.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void MostarVehiculo2()
        {

            DataTable TablaVehiculo = new DataTable();

            try
            {     
                // Crear el comando con el Stored Procedure
                SqlCommand sqlCommand = new SqlCommand("dbo.SP_MostrarVehiculo", sqlconnection);

                // Establecer el comando como un Stored Procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;
                // Parámetro
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter)
                {
                    sqlDataAdapter.Fill(TablaVehiculo);
                }
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conexion.Cn);

                string query = string.Format("REGISTRO_TIPO_VEHICULO");
                SqlCommand command = new SqlCommand(query,connection);

                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                using (adapter)
                {
                    command.Parameters.AddWithValue("@nombre", Nombre);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tipo de vehiculo Guardado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }
    }
}

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
// Agregando los namespaces necesarios para SQL Server
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace _01_EstacionamientoNegocios
{
    /// <summary>
    /// Lógica de interacción para Historial.xaml
    /// </summary>
    public partial class Historial : Window
    {
        SqlConnection sqlconnection;
        // Variable miembro
        public Historial()
        {
            
            InitializeComponent();
                /*
            string connectionString = ConfigurationManager.ConnectionStrings["_01_EstacionamientoNegocios.Properties.Settings.Default.BD_ESTACIONAMIENTO_CMConnectionString"].ConnectionString;
            sqlconnection = new SqlConnection(connectionString);

            MostrarTodo();*/
        }
        /*
        private void MostrarTodo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["_01_EstacionamientoNegocios.Properties.Settings.EstacionamientoPConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [EstacionamientoP].[dbo].[Datos]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataView vw = new DataView();
            gi.ItemsSource = vw;
        }
        */
    }
}

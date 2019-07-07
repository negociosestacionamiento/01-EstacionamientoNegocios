using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregar los namespaces para la conexión con SQL Server
using System.Data;
using System.Data.SqlClient;


namespace _01_EstacionamientoNegocios
{
    class MyConnectionSql : MyConnection
    {
        public MyConnectionSql(DataProvider theDataProvider) : base(theDataProvider)
        {
            // Utilizando un ConnectionString para realizar la conexión
            // con el servidor SQL Server
            SqlConnection connectionString = new SqlConnection(@"server = (local)\sqlexpress; integrated security = true;");

            try
            {
                // Abrir la conexión
                connectionString.Open();

            }
            catch (SqlException e)
            {
                // Desplegar el mensaje de error
                Console.WriteLine("Error: {0} {1}", e.Message, e.StackTrace); ;
            }
            finally
            {
                // Cerrar la conexión
                connectionString.Close();
                Console.WriteLine("Conexión finalizada");
            }
        }
    
    }
}

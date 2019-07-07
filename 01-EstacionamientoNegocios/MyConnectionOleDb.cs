using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespaces necesarios para realizar la conexión OleDB
using System.Data;
using System.Data.OleDb;

namespace _01_EstacionamientoNegocios
{
    class MyConnectionOleDb : MyConnection
    {
        // Constructor
        public MyConnectionOleDb(DataProvider theDataProvider) : base(theDataProvider)
        {
            // Crear la cadena de conexión
            OleDbConnection connectionString = new OleDbConnection(@"provider = sqloledb;
                data source = (local)\sqlexpress; integrated security = sspi;");

            try
            {
                // Establecer la conexión
                connectionString.Open();
                Console.WriteLine("Conexión establecida");

            }
            catch (OleDbException e)
            {
                // Desplegar el error en la conexión
                Console.WriteLine("Error: {0} {1}", e.Message, e.StackTrace);
            }
            finally
            {
                // Cerrar la conexión
                connectionString.Close();
            }
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Clases_Datos
{

        
        public class Datos_TipoVehiculo
        {

        private int idTipoVehiculo;
        private string nombre;
        private string busqueda;

        SqlConnection Con = new SqlConnection(Conexion.Cn);

        public Datos_TipoVehiculo()
        {

        }

        public int IdTipoVehiculo { get { return idTipoVehiculo; } set => idTipoVehiculo = value; }
        public string Nombre { get { return nombre; } set => nombre = value; }
        public string Busqueda { get {return busqueda; }set => busqueda = value; }


        public DataTable MostrarTipoVehiculo()
        {
            DataTable TablaTipoVehiculo = new DataTable();
            try
            {
                SqlCommand Cmd = new SqlCommand("SP_DeplegarTipoVehiculo", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlData = new SqlDataAdapter(Cmd);
                using (sqlData)
                {
                    sqlData.Fill(TablaTipoVehiculo);
                }
            }
            catch (Exception)
            {
                TablaTipoVehiculo = null;
            }
            return TablaTipoVehiculo;
        }
    }
}

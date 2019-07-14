using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Clases_Datos
{
    public class Datos_Vehiculo
    {
        private int idVehiculo;
        private string placa;
        private int idTipoVehiculo;
        private string horaEntrada;

        SqlConnection Con = new SqlConnection(Conexion.Cn);

        public Datos_Vehiculo()
        {

        }

        public int IdVehiculo { get { return idVehiculo; } set { idVehiculo = value;} }
        public string Placa { get { return placa; } set { placa = value; } }
        public int IdTipoVehiculo { get { return idTipoVehiculo; } set { idTipoVehiculo = value; } }
        public string HoraEntrada { get { return horaEntrada; } set { horaEntrada = value; } }

        public DataTable DesplegarVehiculo()
        {
            DataTable TablaVehiculo = new DataTable();
            try
            {
                SqlCommand Cmd = new SqlCommand("SP_DesplegarEstacionamientoVehiculo", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlData = new SqlDataAdapter(Cmd);
                using (sqlData)
                {
                    sqlData.Fill(TablaVehiculo);
                }
            }
            catch (Exception)
            {
                TablaVehiculo = null;
            }
            return TablaVehiculo;
        }
    }
}

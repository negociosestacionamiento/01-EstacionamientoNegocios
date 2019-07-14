using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Clases_Datos
{
    public class Datos_Detalle
    {
        private string placa;
        private string horaEntrada;
        private string tipoVehiculo;
        private string horaSalida;
        private double cobro;
        private string busqueda;

        SqlConnection Con = new SqlConnection(Conexion.Cn);
        public Datos_Detalle()
        {

        }

        public string Placa { get { return placa; } set => placa = value; }
        public string HoraEntrada { get { return horaEntrada; } set => horaEntrada = value; }
        public string TipoVehiculo { get { return tipoVehiculo; } set => tipoVehiculo = value; }
        public string HoraSalida { get { return horaSalida; } set => horaSalida = value; }
        public double Cobro { get { return cobro; } set => cobro = value; }
        public string Busqueda { get { return busqueda; } set => busqueda = value; }

        public DataTable DesplegarDetalleVehiculo()
        {
            DataTable TablaTipoVehiculo = new DataTable();
            try
            {
                SqlCommand Cmd = new SqlCommand("SP_DesplegarEstacionamientoDetalle", Con);
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

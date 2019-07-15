using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Clases_Datos;

namespace Clases_Datos
{
    public class Datos_Vehiculo
    {
        private int idVehiculo;
        private string placa;
        private int idTipoVehiculo;
        private string nombre;
        private string busqueda;

        SqlConnection Con = new SqlConnection(Conexion.Cn);

        public Datos_Vehiculo()
        {

        }

        public int IdVehiculo { get { return idVehiculo; } set => idVehiculo = value; }
        public string Placa { get { return placa; } set => placa = value; }
        public int IdTipoVehiculo { get { return idTipoVehiculo; } set => idTipoVehiculo = value; }
        public string Nombre { get { return nombre; } set => nombre = value; }
        public string Busqueda { get { return busqueda; } set => busqueda = value; }



        public DataTable DesplegarVehiculo()
        {
            DataTable TablaVehiculo = new DataTable();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("SP_DesplegarEstacionamientoVehiculo", Con);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlData = new SqlDataAdapter(SqlCmd);
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

        public string IngresarVehiculo(Datos_Vehiculo vehiculo)
        {
            string opt = "";
            SqlCommand SqlCmd = new SqlCommand("SP_Ingreso_Vehiculo", Con);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Con.Open();
                SqlCmd.Parameters.Add(new SqlParameter("Placa", SqlDbType.VarChar));
                SqlCmd.Parameters["Placa"].Value = vehiculo.Placa;
                SqlCmd.Parameters.Add(new SqlParameter("idTipo", SqlDbType.Int));
                SqlCmd.Parameters["idTipo"].Value = vehiculo.IdTipoVehiculo;
                SqlCmd.ExecuteNonQuery();
                opt = "Agregado satisfactoriamente";
            }
            catch (Exception e)
            {
                opt = e.ToString();
            }
            finally
            {
                Con.Close();
            }
            return opt;
        }
    }
}

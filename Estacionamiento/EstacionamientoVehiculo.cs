using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Clases_Datos;

namespace Estacionamiento
{
    public class EstacionamientoVehiculo
    {

        public static DataTable MostrarTipoVehiculo()
        {
            return new Datos_Vehiculo().MostrarTipoVehiculo();
        }

        public static DataTable DesplegarVehiculo()
        {
            return new Datos_Vehiculo().DesplegarVehiculo();
        }

        public static string IngresarVehiculo(string Placa, int Tipo)
        {
            Datos_Vehiculo Obj = new Datos_Vehiculo();
            Obj.Placa = Placa;
            Obj.IdTipoVehiculo = Tipo;
            return Obj.IngresarVehiculo(Obj);
        }
    }
}

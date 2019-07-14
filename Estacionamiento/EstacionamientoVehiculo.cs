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
        public static DataTable DesplegarVehiculo()
        {
            return new Datos_Vehiculo().DesplegarVehiculo();
        }
    }
}

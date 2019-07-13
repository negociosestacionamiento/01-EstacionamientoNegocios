using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Clases_Datos;

namespace Estacionamiento
{
    public class EstacionamientoTipoVehiculo
    {
        public static DataTable MostrarTipoVehiculo()
        {
            return new Datos_TipoVehiculo().MostrarTipoVehiculo();
        }
    }
}

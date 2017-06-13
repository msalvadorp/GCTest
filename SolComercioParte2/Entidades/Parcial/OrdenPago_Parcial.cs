using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Entidades
{
    public partial class OrdenPago
    {

        public OrdenPago()
        {
        }

        public OrdenPago(IDataReader reader)
        {
            this.IdOrdenPago = Convert.ToInt32(reader["IdOrdenPago"]);
            this.IdSucursal = Convert.ToInt32(reader["IdSucursal"]);
            this.Monto = Convert.ToDecimal(reader["Monto"]);
            this.Moneda = Convert.ToInt32(reader["Moneda"]);
            this.Situacion = Convert.ToInt32(reader["Situacion"]);
            this.FechaPago = Convert.ToDateTime(reader["FechaPago"]);
            this.FlgEliminado = Convert.ToBoolean(reader["FlgEliminado"]);

        }

        [DataMember]
        public string NombreSucursalCompleta { get; set; }
        [DataMember]
        public string NombreMoneda { get; set; }
        [DataMember]
        public string NombreSituacion { get; set; }


    }



}
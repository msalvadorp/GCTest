using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Entidades
{
    public partial class Sucursal
    {

        public Sucursal()
        {
        }

        public Sucursal(IDataReader reader)
        {
            this.IdSucursal = Convert.ToInt32(reader["IdSucursal"]);
            this.IdBanco = Convert.ToInt32(reader["IdBanco"]);
            this.Nombre = Convert.ToString(reader["Nombre"]);
            this.Direccion = Convert.ToString(reader["Direccion"]);
            this.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
            this.FlgEliminado = Convert.ToBoolean(reader["FlgEliminado"]);

        }


        [DataMember]
        public string NombreBanco { get; set; }

        [DataMember]
        public string NombreBancoSucursal { get; set; }


    }



}
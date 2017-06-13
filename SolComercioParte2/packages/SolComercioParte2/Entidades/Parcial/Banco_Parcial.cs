using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Entidades
{
    public partial class Banco
    {

        public Banco()
        {
            FechaRegistro = DateTime.Now;
            FlgEliminado = false;
        }

        public Banco(IDataReader reader)
        {
            this.IdBanco = Convert.ToInt32(reader["IdBanco"]);
            this.Nombre = Convert.ToString(reader["Nombre"]);
            this.Direccion = Convert.ToString(reader["Direccion"]);
            this.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
            this.FlgEliminado = Convert.ToBoolean(reader["FlgEliminado"]);

        }


    }



}
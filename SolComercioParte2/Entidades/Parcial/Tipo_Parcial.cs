using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public partial class Tipo
    {
        public Tipo()
        {

        }

        public Tipo(IDataReader reader)
        {
            this.IdTipo = Convert.ToInt32(reader["IdTipo"]);
            this.IdGrupoTipo = Convert.ToInt32(reader["IdGrupoTipo"]);
            this.Nombre = Convert.ToString(reader["Nombre"]);
        }

    }
}

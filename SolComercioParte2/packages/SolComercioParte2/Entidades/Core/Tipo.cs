using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [DataContract]
    public partial class Tipo
    {
        #region Propiedades

        [DataMember]
        public int IdTipo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdGrupoTipo { get; set; }

        #endregion

    }
}

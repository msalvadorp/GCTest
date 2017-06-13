using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public partial class Sucursal
    {
        #region Propiedades
        [DataMember]  
		public int IdSucursal { get; set; }  
		[DataMember]  
		public int IdBanco { get; set; }  
		[DataMember]  
		public string Nombre { get; set; }  
		[DataMember]  
		public string Direccion { get; set; }  
		[DataMember]  
		public DateTime FechaRegistro { get; set; }  
		[DataMember]  
		public bool FlgEliminado { get; set; }  
		
        #endregion
    }

    

}
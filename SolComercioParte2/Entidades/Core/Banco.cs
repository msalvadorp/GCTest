using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace Entidades
{
    [DataContract]
    public partial class Banco
    {
        #region Propiedades
        [DataMember]  
		public int IdBanco { get; set; }  
		[DataMember]  
        [Required(ErrorMessage="Debe ingresar el nombre")]
		public string Nombre { get; set; }  
		[DataMember]
        [Required(ErrorMessage = "Debe ingresar la direccion")]
		public string Direccion { get; set; }  
		[DataMember]  
		public DateTime FechaRegistro { get; set; }  
		[DataMember]  
		public bool FlgEliminado { get; set; }  
		
        #endregion
    }

    

}
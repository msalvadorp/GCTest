using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatos;
using Negocio.Base;

namespace Negocio
{
    public class OrdenPagoLN : BaseLN
    {
        #region IOrdenPago Members

        public OrdenPago Insertar_OrdenPago(OrdenPago OrdenPago)
        {
             return new OrdenPagoAD().Insertar_OrdenPago(OrdenPago);
            
        }

        public OrdenPago Actualizar_OrdenPago(OrdenPago OrdenPago)
        {
             return new OrdenPagoAD().Actualizar_OrdenPago(OrdenPago);
        }

        public List<OrdenPago> Listar_OrdenPago(int IdSucursal, int TipoMoneda, int TipoSituacion)
        {
            
             return new OrdenPagoAD().Listar_OrdenPago(IdSucursal, TipoMoneda, TipoSituacion);
           
        }

        public int Anular_OrdenPago_PorCodigo(int IdOrdenPago)
        {
             return new OrdenPagoAD().Borrar_OrdenPago(IdOrdenPago);
        }

        public OrdenPago Recuperar_OrdenPago_PorCodigo(int IdOrdenPago)
        {
            
            return new OrdenPagoAD().Recuperar_OrdenPago_PorCodigo(IdOrdenPago);
           
        }

       

        #endregion

        public IEnumerable<OrdenPago> Listar_OrdenPago_LocalMoneda(int IdSucursal, string Moneda)
        {
            return new OrdenPagoAD().Listar_OrdenPago_LocalMoneda(IdSucursal, Moneda);
        }
    }
}

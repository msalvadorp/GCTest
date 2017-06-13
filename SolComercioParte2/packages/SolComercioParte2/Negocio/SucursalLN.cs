using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatos;
using Negocio.Base;

namespace Negocio
{
    public class SucursalLN : BaseLN
    {
        #region ISucursal Members

        public Sucursal Insertar_Sucursal(Sucursal Sucursal)
        {
            return new SucursalAD().Insertar_Sucursal(Sucursal);

        }

        public Sucursal Actualizar_Sucursal(Sucursal Sucursal)
        {
            return new SucursalAD().Actualizar_Sucursal(Sucursal);
        }

        public List<Sucursal> Listar_Sucursal()
        {

            return new SucursalAD().Listar_Sucursal();

        }
        public List<Sucursal> Listar_Sucursal_PorBanco(int IdBanco)
        {

            return new SucursalAD().Listar_Sucursal_PorBanco(IdBanco);

        }
        public int Anular_Sucursal_PorCodigo(int IdSucursal)
        {
            return new SucursalAD().Borrar_Sucursal(IdSucursal);
        }

        public Sucursal Recuperar_Sucursal_PorCodigo(int IdSucursal)
        {

            return new SucursalAD().Recuperar_Sucursal_PorCodigo(IdSucursal);

        }



        #endregion
    }
}

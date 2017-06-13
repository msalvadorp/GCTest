using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatos;
using Negocio.Base;

namespace Negocio
{
    public class BancoLN : BaseLN
    {
        #region IBanco Members

        public Banco Insertar_Banco(Banco Banco)
        {
            return new BancoAD().Insertar_Banco(Banco);

        }

        public Banco Actualizar_Banco(Banco Banco)
        {
            return new BancoAD().Actualizar_Banco(Banco);
        }

        public List<Banco> Listar_Banco(string filtro)
        {

            return new BancoAD().Listar_Banco(filtro);

        }

        public int Anular_Banco_PorCodigo(int IdBanco)
        {
            return new BancoAD().Borrar_Banco(IdBanco);
        }

        public Banco Recuperar_Banco_PorCodigo(int IdBanco)
        {

            return new BancoAD().Recuperar_Banco_PorCodigo(IdBanco);

        }



        #endregion
    }
}

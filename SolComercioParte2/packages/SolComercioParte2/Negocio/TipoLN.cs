using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using AccesoDatos;
using Negocio.Base;
using Utilitario;

namespace Negocio
{
    public class TipoLN : BaseLN
    {
        #region ITipo Members

        public Tipo Insertar_Tipo(Tipo Tipo)
        {
            return new TipoAD().Insertar_Tipo(Tipo);

        }

        public Tipo Actualizar_Tipo(Tipo Tipo)
        {
            return new TipoAD().Actualizar_Tipo(Tipo);
        }

        public List<Tipo> Listar_Tipo()
        {

            return new TipoAD().Listar_Tipo();

        }

        public int Anular_Tipo_PorCodigo(int IdTipo)
        {
            return new TipoAD().Borrar_Tipo(IdTipo);
        }

        public Tipo Recuperar_Tipo_PorCodigo(int IdTipo)
        {

            return new TipoAD().Recuperar_Tipo_PorCodigo(IdTipo);

        }



        #endregion


        public Dictionary<EnumTipos, List<Tipo>> Listar_Tipo_PorGrupo(List<EnumTipos> listaEnumTipos)
        {
            Dictionary<EnumTipos, List<Tipo>> resultado = new Dictionary<EnumTipos, List<Tipo>>();
            TipoAD oAD = new TipoAD();

            foreach (EnumTipos item in listaEnumTipos)
            {
                resultado.Add(item, oAD.Listar_Tipo_PorGrupo((int)item));
            }

            return resultado;
        }
    }
}

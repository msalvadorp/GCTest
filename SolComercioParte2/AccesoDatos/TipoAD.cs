using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos
{
    public class TipoAD
    {
        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        #region Tipo_AD

        /// <summary>
        /// Metodo que Inserta la Entidad Tipo hacia la base da datos
        /// </summary>
        /// <param name="Tipo">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Tipo con datos llenos</returns>
        public Tipo Insertar_Tipo(Tipo tipo)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarTipo", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTipo", tipo.IdTipo);
                    comando.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    comando.Parameters.AddWithValue("@IdGrupoTipo", tipo.IdGrupoTipo);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return tipo;
        }

        public Tipo Actualizar_Tipo(Tipo tipo)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarTipo", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTipo", tipo.IdTipo);
                    comando.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    comando.Parameters.AddWithValue("@IdGrupoTipo", tipo.IdGrupoTipo);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return tipo;
        }

        public int Borrar_Tipo(int IdTipo)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarTipo", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTipo", IdTipo);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }

        public Tipo Recuperar_Tipo_PorCodigo(int IdTipo)
        {
            Tipo Tipo = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerTipo", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTipo", IdTipo);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Tipo = new Tipo(reader);
                    }
                }
                conexion.Close();
            }
            return Tipo;
        }

        public List<Tipo> Listar_Tipo()
        {
            List<Tipo> listaEntidad = new List<Tipo>();
            Tipo entidad = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTipo", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tipo(reader);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;
        }

        public List<Tipo> Listar_Tipo_PorGrupo(int IdGrupoTipo)
        {
            List<Tipo> listaEntidad = new List<Tipo>();
            Tipo entidad = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarTipoPorGrupo", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdGrupoTipo", IdGrupoTipo);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Tipo(reader);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;
        }
        #endregion
    }
}

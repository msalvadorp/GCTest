using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public partial class BancoAD
    {
        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        #region Banco_AD

        /// <summary>
        /// Metodo que Inserta la Entidad Banco hacia la base da datos
        /// </summary>
        /// <param name="Banco">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Banco con datos llenos</returns>
        public Banco Insertar_Banco(Banco Banco)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarBanco", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", Banco.Nombre);
                    comando.Parameters.AddWithValue("@Direccion", Banco.Direccion);
                    comando.Parameters.AddWithValue("@FechaRegistro", Banco.FechaRegistro);
                    comando.Parameters.AddWithValue("@FlgEliminado", Banco.FlgEliminado);
                    conexion.Open();
                    Banco.IdBanco = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return Banco;
        }

        public Banco Actualizar_Banco(Banco Banco)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarBanco", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdBanco", Banco.IdBanco);
                    comando.Parameters.AddWithValue("@Nombre", Banco.Nombre);
                    comando.Parameters.AddWithValue("@Direccion", Banco.Direccion);
                    comando.Parameters.AddWithValue("@FechaRegistro", Banco.FechaRegistro);
                    comando.Parameters.AddWithValue("@FlgEliminado", Banco.FlgEliminado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return Banco;
        }

        public int Borrar_Banco(int IdBanco)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarBanco", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdBanco", IdBanco);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }

        public Banco Recuperar_Banco_PorCodigo(int IdBanco)
        {
            Banco Banco = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerBanco", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdBanco", IdBanco);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Banco = new Banco(reader);
                    }
                }
                conexion.Close();
            }
            return Banco;
        }

        public List<Banco> Listar_Banco(string filtro)
        {
            List<Banco> listaEntidad = new List<Banco>();
            Banco entidad = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarBanco", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Filtro", filtro);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Banco(reader);
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
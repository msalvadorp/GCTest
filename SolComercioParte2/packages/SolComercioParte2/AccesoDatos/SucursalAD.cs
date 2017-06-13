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
    public partial class SucursalAD
    {
        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        #region Sucursal_AD

        /// <summary>
        /// Metodo que Inserta la Entidad Sucursal hacia la base da datos
        /// </summary>
        /// <param name="Sucursal">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad Sucursal con datos llenos</returns>
        public Sucursal Insertar_Sucursal(Sucursal Sucursal)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarSucursal", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdBanco", Sucursal.IdBanco);
                    comando.Parameters.AddWithValue("@Nombre", Sucursal.Nombre);
                    comando.Parameters.AddWithValue("@Direccion", Sucursal.Direccion);
                    comando.Parameters.AddWithValue("@FechaRegistro", Sucursal.FechaRegistro);
                    comando.Parameters.AddWithValue("@FlgEliminado", Sucursal.FlgEliminado);
                    conexion.Open();
                    Sucursal.IdSucursal = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return Sucursal;
        }

        public Sucursal Actualizar_Sucursal(Sucursal Sucursal)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarSucursal", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdSucursal", Sucursal.IdSucursal);
                    comando.Parameters.AddWithValue("@IdBanco", Sucursal.IdBanco);
                    comando.Parameters.AddWithValue("@Nombre", Sucursal.Nombre);
                    comando.Parameters.AddWithValue("@Direccion", Sucursal.Direccion);
                    comando.Parameters.AddWithValue("@FechaRegistro", Sucursal.FechaRegistro);
                    comando.Parameters.AddWithValue("@FlgEliminado", Sucursal.FlgEliminado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return Sucursal;
        }

        public int Borrar_Sucursal(int IdSucursal)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarSucursal", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdSucursal", IdSucursal);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }

        public Sucursal Recuperar_Sucursal_PorCodigo(int IdSucursal)
        {
            Sucursal Sucursal = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerSucursal", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdSucursal", IdSucursal);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Sucursal = new Sucursal(reader);
                    }
                }
                conexion.Close();
            }
            return Sucursal;
        }

        public List<Sucursal> Listar_Sucursal()
        {
            List<Sucursal> listaEntidad = new List<Sucursal>();
            Sucursal entidad = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarSucursal", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Sucursal(reader);
                        entidad.NombreBanco = Convert.ToString(reader["NombreBanco"]);
                        entidad.NombreBancoSucursal = string.Format("Banco {0} - Sucursal {1}", entidad.Nombre, entidad.NombreBanco);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;
        }

        public List<Sucursal> Listar_Sucursal_PorBanco(int IdBanco)
        {
            List<Sucursal> listaEntidad = new List<Sucursal>();
            Sucursal entidad = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("[usp_ListarSucursalPorBanco]", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdBanco", IdBanco);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Sucursal(reader);
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
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
    public partial class OrdenPagoAD
    {
        string cadena = ConfigurationManager.ConnectionStrings["CnnSQL"].ConnectionString;

        #region OrdenPago_AD

        /// <summary>
        /// Metodo que Inserta la Entidad OrdenPago hacia la base da datos
        /// </summary>
        /// <param name="OrdenPago">Entidad a Insertar en la Base de Datos</param>
        /// <returns>Entidad OrdenPago con datos llenos</returns>
        public OrdenPago Insertar_OrdenPago(OrdenPago OrdenPago)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_InsertarOrdenPago", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdSucursal", OrdenPago.IdSucursal);
                    comando.Parameters.AddWithValue("@Monto", OrdenPago.Monto);
                    comando.Parameters.AddWithValue("@Moneda", OrdenPago.Moneda);
                    comando.Parameters.AddWithValue("@Situacion", OrdenPago.Situacion);
                    comando.Parameters.AddWithValue("@FechaPago", OrdenPago.FechaPago);
                    comando.Parameters.AddWithValue("@FlgEliminado", OrdenPago.FlgEliminado);
                    conexion.Open();
                    OrdenPago.IdOrdenPago = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return OrdenPago;
        }

        public OrdenPago Actualizar_OrdenPago(OrdenPago OrdenPago)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ActualizarOrdenPago", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdOrdenPago", OrdenPago.IdOrdenPago);
                    comando.Parameters.AddWithValue("@IdSucursal", OrdenPago.IdSucursal);
                    comando.Parameters.AddWithValue("@Monto", OrdenPago.Monto);
                    comando.Parameters.AddWithValue("@Moneda", OrdenPago.Moneda);
                    comando.Parameters.AddWithValue("@Situacion", OrdenPago.Situacion);
                    comando.Parameters.AddWithValue("@FechaPago", OrdenPago.FechaPago);
                    comando.Parameters.AddWithValue("@FlgEliminado", OrdenPago.FlgEliminado);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return OrdenPago;
        }

        public int Borrar_OrdenPago(int IdOrdenPago)
        {
            int resp = 0;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_BorrarOrdenPago", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdOrdenPago", IdOrdenPago);
                    conexion.Open();
                    resp = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return resp;
        }

        public OrdenPago Recuperar_OrdenPago_PorCodigo(int IdOrdenPago)
        {
            OrdenPago OrdenPago = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ObtenerOrdenPago", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdOrdenPago", IdOrdenPago);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        OrdenPago = new OrdenPago(reader);
                    }
                }
                conexion.Close();
            }
            return OrdenPago;
        }

        public List<OrdenPago> Listar_OrdenPago(int IdSucursal, int TipoMoneda, int TipoSituacion)
        {
            List<OrdenPago> listaEntidad = new List<OrdenPago>();
            OrdenPago entidad = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("usp_ListarOrdenPago", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdSucursal", IdSucursal);
                    comando.Parameters.AddWithValue("@TipoMoneda", TipoMoneda);
                    comando.Parameters.AddWithValue("@TipoSituacion", TipoSituacion);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new OrdenPago(reader);
                        entidad.NombreSucursalCompleta = Convert.ToString(reader["NombreSucursalCompleta"]);
                        entidad.NombreMoneda = Convert.ToString(reader["NombreMoneda"]);
                        entidad.NombreSituacion = Convert.ToString(reader["NombreSituacion"]);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;
        }


        #endregion

        public IEnumerable<OrdenPago> Listar_OrdenPago_LocalMoneda(int IdSucursal, string Moneda)
        {
            List<OrdenPago> listaEntidad = new List<OrdenPago>();
            OrdenPago entidad = null;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("[usp_ListarOrdenPago_LocalMoneda]", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdSucursal", IdSucursal);
                    comando.Parameters.AddWithValue("@Moneda", Moneda);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new OrdenPago(reader);
                        listaEntidad.Add(entidad);
                    }

                }
                conexion.Close();
            }

            return listaEntidad;
        }
    }
}
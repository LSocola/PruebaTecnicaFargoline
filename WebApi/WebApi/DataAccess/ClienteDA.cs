using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using WebApi.Models;
using System.Data.SqlClient;
using WebApi.Conexion;

namespace WebApi.DataAccess
{
    public class ClienteDA
    {
        public static Cliente ObtenerCliente(int idCliente)
        {
            
            using (SqlConnection con = new SqlConnection(BDSocola.cn))
            {
                SqlCommand cmd = new SqlCommand("SP_Obtener_Cliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_CODIGO", idCliente);

                try
                {                   
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        {
                            Cliente cliente = new Cliente()
                            {
                                Codigo = Convert.ToInt32(dr["Codigo"]),
                                Nombre = dr["Nombre"].ToString(),
                                Pais = dr["Pais"].ToString(),
                                IdDocumento = Convert.ToInt32(dr["IdDocumento"].ToString()),
                                NroDocumento = dr["NroDocumento"].ToString(),
                                Descripcion = dr["Descripcion"].ToString()
                            };
                            return cliente;
                        }
                    }
                    

                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }          
        }
        public static List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(BDSocola.cn))
            {
                SqlCommand cmd = new SqlCommand("SP_Listar_Clientes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clientes.Add(new Cliente()
                            {
                                Codigo = Convert.ToInt32(dr["Codigo"]),
                                Nombre = dr["Nombre"].ToString(),
                                Pais = dr["Pais"].ToString(),
                                IdDocumento = Convert.ToInt32(dr["IdDocumento"].ToString()),
                                NroDocumento = dr["NroDocumento"].ToString(),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }
                    return clientes;
                }
                catch (Exception ex)
                {
                    return clientes;
                }
                finally
                {
                    con.Close();
                }
            }

        }
        public static String RegistrarCliente(Cliente cliente)
        {
            String mensaje = "";
            using (SqlConnection con = new SqlConnection(BDSocola.cn))
            {
                SqlCommand cmd = new SqlCommand("SP_Registrar_Cliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PV_NOMBRE", cliente.Nombre);
                cmd.Parameters.AddWithValue("@PV_PAIS", cliente.Pais);
                cmd.Parameters.AddWithValue("@PI_TIPODOC", cliente.IdDocumento);
                cmd.Parameters.AddWithValue("@PV_NRODOC", cliente.NroDocumento);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Registro Exitoso";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return mensaje;
        }
        public static String EliminarCliente(int idCliente)
        {
            String mensaje = "";
            using (SqlConnection con = new SqlConnection(BDSocola.cn))
            {
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Cliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_CODIGO", idCliente);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Eliminado";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return mensaje;
        }
        public static String ActualizarCliente(Cliente cliente)
        {
            String mensaje = "";
            using (SqlConnection con = new SqlConnection(BDSocola.cn))
            {
                SqlCommand cmd = new SqlCommand("SP_Actualizar_Cliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_CODIGO", cliente.Codigo);
                cmd.Parameters.AddWithValue("@PV_NOMBRE", cliente.Nombre);
                cmd.Parameters.AddWithValue("@PV_PAIS", cliente.Pais);
                cmd.Parameters.AddWithValue("@PI_TIPODOC", cliente.IdDocumento);
                cmd.Parameters.AddWithValue("@PV_NRODOC", cliente.NroDocumento);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Actualizado";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return mensaje;
        }
    }
}

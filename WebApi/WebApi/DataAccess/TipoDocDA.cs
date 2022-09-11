using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using WebApi.Conexion;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class TipoDocDA
    {
        public static List<TipoDocumento> ListarTipoDoc()
        {
            List<TipoDocumento> tipos = new List<TipoDocumento>();
            using (SqlConnection con = new SqlConnection(BDSocola.cn))
            {
                SqlCommand cmd = new SqlCommand("SP_Listar_TipoDoc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tipos.Add(new TipoDocumento()
                            {
                                IdDocumento = Convert.ToInt32(dr["IdDocumento"]),
                                Descripcion = dr["Descripcion"].ToString()                             
                            });
                        }
                    }
                    return tipos;
                }
                catch (Exception ex)
                {
                    return tipos;
                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}

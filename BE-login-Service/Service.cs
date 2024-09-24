using BE_login_Date;
using BE_login_Common;
using Microsoft.Data.SqlClient;
using System.Data;


namespace BE_login_Service
{
    public class Service
    {
        public List<User> Listar()
        {
            var olista = new List<User>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar_sp", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new User()
                        {
                            IdUsers = Convert.ToInt32(dr["IdUsers"]),
                            Name = dr["Name"].ToString(),
                            Date = Convert.ToDateTime(dr["Date"]),
                            Service = dr["Service"].ToString(),
                        });
                    }
                }
            }
            return olista;

        }

        public User Obtener(int IdUsers)
        {
            var ocontacto = new User();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("obtener_sp", conexion);
                cmd.Parameters.AddWithValue("IdUsers", IdUsers);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ocontacto.IdUsers = Convert.ToInt32(dr["IdUsers"]);
                        ocontacto.Name = dr["Name"].ToString();
                        ocontacto.Date = Convert.ToDateTime(dr["Date"]);
                        ocontacto.Service = dr["Service"].ToString();
                    }
                }
            }
            return ocontacto;
        }

        public bool Guardar(User ousuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("guardar_sp", conexion);
                    cdm.Parameters.AddWithValue("Name", ousuario.Name);
                    cdm.Parameters.AddWithValue("Date", ousuario.Date);
                    cdm.Parameters.AddWithValue("Service", ousuario.Service);
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


        public bool Editar(User ousuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("editar_sp", conexion);
                    cdm.Parameters.AddWithValue("IdUsers", ousuario.IdUsers);
                    cdm.Parameters.AddWithValue("Name", ousuario.Name);
                    cdm.Parameters.AddWithValue("Date", ousuario.Date);
                    cdm.Parameters.AddWithValue("Service", ousuario.Service);
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int IdUsers)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("eliminar_sp", conexion);
                    cdm.Parameters.AddWithValue("IdUsers", IdUsers);
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}

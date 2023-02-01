using MySqlConnector;
using Softtek.Domain;
using Softtek.Domain.Dto;
using Softtek.Repository.SqlServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Repository.SqlServer
{
    public class SegurityRepository : Repository<UserDTO>, ISegurityRepository
    {
        public UserDTO GetUser(UserLogins itemRequest)
        {
            UserDTO result = new UserDTO();
            try
            {
                using (MySqlConnection cn = Softtek.Repository.SqlServer.Core.DbContext.connection())
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_LOGIN", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("usuario", itemRequest.UserName);
                        cmd.Parameters.AddWithValue("contrasena", itemRequest.Password);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result.Id = Convert.ToInt32(reader["Id"].ToString());
                            result.Usuario = reader["Usuario"].ToString();
                            result.Nombre = reader["Nombre"].ToString();
                            result.Apellidos = reader["Apellidos"].ToString();
                            result.Perfil = reader["Perfil"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = new UserDTO();
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Domain;
using Softtek.Domain.Dto;
using Softtek.Repository.SqlServer.Core;
using MySqlConnector;
namespace Softtek.Repository.SqlServer
{
    public class CommercialRepository : Repository<Sale>, ICommercialRepository
    {
        public IList<SaleDto> ListarVenta()
        {
            IList<SaleDto> result = new List<SaleDto>();
            try
            {
                using (MySqlConnection cn =  Softtek.Repository.SqlServer.Core.DbContext.connection())
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_LISTAR_PRODUCTO_VENTA", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new SaleDto
                            {
                                IdProducto = Convert.ToInt32(reader["id"].ToString()),
                                producto = reader["Descripcion"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<SaleDto>();
            }
            return result;
        }

        public IList<SaleDto> ListarVentaXProducto(int idProducto)
        {
            IList<SaleDto> result = new List<SaleDto>();
            try
            {
                using (MySqlConnection cn = Softtek.Repository.SqlServer.Core.DbContext.connection())
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PRODUCTO_X_ASESOR", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idProducto", idProducto);  
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new SaleDto
                            {
                                IdProducto = Convert.ToInt32(reader["id"].ToString()),
                                producto = reader["Descripcion"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<SaleDto>();
            }
            return result;
        }

    }
}

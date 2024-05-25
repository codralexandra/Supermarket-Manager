using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace supermarket_manager.Models.DataAccessLayer
{
    class JoinDALs
    {
        public ObservableCollection<Product> GetProductsByCategory (Category category)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductsByCategory", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                SqlParameter CategoryIDParameter = new SqlParameter("@id_category", category.Id);
                cmd.Parameters.Add(CategoryIDParameter);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("No rows returned by the stored procedure.");
                    return result;
                }
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        BarCode = reader["Bar_Code"].ToString(),
                        ExpDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("Exp_Date"))),
                        CategoryId = Convert.ToInt32(reader["Id_Category"]),
                        SuplierId = Convert.ToInt32(reader["Id_Suplier"])
                    });
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

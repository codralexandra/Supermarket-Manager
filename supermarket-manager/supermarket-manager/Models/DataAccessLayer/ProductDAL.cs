using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace supermarket_manager.Models.DataAccessLayer
{
    class ProductDAL
    {
        public ObservableCollection<Product> GetAllProducts()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
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
                    }) ;
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", product.Name);
                SqlParameter paramExpDate = new SqlParameter("@exp_date", new DateTime(product.ExpDate.Value.Year,
                                                                                       product.ExpDate.Value.Month,
                                                                                       product.ExpDate.Value.Day));
                SqlParameter paramCategory = new SqlParameter("@id_category", product.CategoryId);
                SqlParameter paramIdSuplier = new SqlParameter("@id_suplier", product.SuplierId);

                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramExpDate);
                cmd.Parameters.Add(paramCategory);
                cmd.Parameters.Add(paramIdSuplier);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", product.Id);
                SqlParameter paramName = new SqlParameter("@name", product.Name);
                SqlParameter paramCategory = new SqlParameter("@category", product.CategoryId);

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramCategory);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", product.Name);
                cmd.Parameters.Add(paramName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

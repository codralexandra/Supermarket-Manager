using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace supermarket_manager.Models.DataAccessLayer
{
    class ProductDAL
    {
        CategoryDAL categoryDAL = new CategoryDAL();
        SuplierDAL suplierDAL = new SuplierDAL();
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
                    Product product = new Product();
                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.Name = reader["Name"].ToString();
                    product.BarCode = reader["Bar_Code"].ToString();
                    product.ExpDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("Exp_Date")));
                    product.CategoryId = Convert.ToInt32(reader["Id_Category"]);
                    product.CategoryName = categoryDAL.GetCategoryName(product.CategoryId);
                    product.SuplierId = Convert.ToInt32(reader["Id_Suplier"]);
                    product.SuplierName = suplierDAL.GetSuplierName(product.SuplierId);

                    result.Add(product);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public Product GetProductById(int id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByID", con);
                Product result = new Product();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("id", id);
                cmd.Parameters.Add(nameParam);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("No rows returned by the stored procedure.");
                    return result;
                }
                while (reader.Read())
                {
                    result = (new Product()
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

        public Product GetProductByName(string name)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByName", con);
                Product result = new Product();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("name", name);
                cmd.Parameters.Add(nameParam);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("No rows returned by the stored procedure.");
                    return result;
                }
                while (reader.Read())
                {
                    result=(new Product()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        BarCode = reader["Bar_Code"].ToString(),
                        ExpDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("Exp_Date"))),
                        CategoryId = Convert.ToInt32(reader["Id_Category"]),
                        CategoryName = categoryDAL.GetCategoryName(Convert.ToInt32(reader["Id_Category"])),
                        SuplierId = Convert.ToInt32(reader["Id_Suplier"]),
                        SuplierName = suplierDAL.GetSuplierName(Convert.ToInt32(reader["Id_Suplier"]))
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

        public ObservableCollection<Product> GetProductByBarCode(string bar_code)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByBarCode", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("bar_code", bar_code);
                cmd.Parameters.Add(nameParam);
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
                        CategoryName = categoryDAL.GetCategoryName(Convert.ToInt32(reader["Id_Category"])),
                        SuplierId = Convert.ToInt32(reader["Id_Suplier"]),
                        SuplierName = suplierDAL.GetSuplierName(Convert.ToInt32(reader["Id_Suplier"]))
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

        public ObservableCollection<Product> GetProductByExpDate(DateOnly exp_date)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByExpDate", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("exp_date", new DateTime(exp_date.Year,
                                                                                      exp_date.Month,
                                                                                       exp_date.Day));
                cmd.Parameters.Add(nameParam);
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
                        CategoryName = categoryDAL.GetCategoryName(Convert.ToInt32(reader["Id_Category"])),
                        SuplierId = Convert.ToInt32(reader["Id_Suplier"]),
                        SuplierName = suplierDAL.GetSuplierName(Convert.ToInt32(reader["Id_Suplier"]))
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

        public ObservableCollection<Product> GetProductBySuplier(int suplier)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductBySuplier", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("id_suplier", suplier);
                cmd.Parameters.Add(nameParam);
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
                        CategoryName = categoryDAL.GetCategoryName(Convert.ToInt32(reader["Id_Category"])),
                        SuplierId = Convert.ToInt32(reader["Id_Suplier"]),
                        SuplierName = suplierDAL.GetSuplierName(Convert.ToInt32(reader["Id_Suplier"]))
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

        public ObservableCollection<Product> GetProductByCategory(int category)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductsByCategory", con);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("id_category", category);
                cmd.Parameters.Add(nameParam);
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
                        CategoryName = categoryDAL.GetCategoryName(Convert.ToInt32(reader["Id_Category"])),
                        SuplierId = Convert.ToInt32(reader["Id_Suplier"]),
                        SuplierName = suplierDAL.GetSuplierName(Convert.ToInt32(reader["Id_Suplier"]))
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

        public int GetProductId(string name)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductId", con);
                int result = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("name", name);
                cmd.Parameters.Add(paramName);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(!reader.HasRows)
                {
                    return result;
                }
                while(reader.Read())
                {
                    result = Convert.ToInt32(reader["Id"]);
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
                SqlParameter paramExpDate = new SqlParameter("@exp_date", new DateTime(product.ExpDate.Year,
                                                                                       product.ExpDate.Month,
                                                                                       product.ExpDate.Day));
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
                SqlParameter paramCategory = new SqlParameter("@category", categoryDAL.GetCategoryID(product.CategoryName));
                SqlParameter paramIdSuplier = new SqlParameter("@suplier", suplierDAL.GetSuplierID(product.SuplierName));

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramCategory);
                cmd.Parameters.Add(paramIdSuplier);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyProductForStock(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyProductForStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", product.Id);
                SqlParameter paramBarCode = new SqlParameter("@bar_code", product.BarCode);
                SqlParameter paramExpDate = new SqlParameter("@exp_date", new DateTime(product.ExpDate.Year,
                                                                                       product.ExpDate.Month,
                                                                                       product.ExpDate.Day));

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramBarCode);
                cmd.Parameters.Add(paramExpDate);
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

        public string GetProductName(int id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                string queryResult = null;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    queryResult = reader["Name"].ToString();
                }
                reader.Close();
                return queryResult;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

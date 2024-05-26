using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace supermarket_manager.Models.DataAccessLayer
{
    class StockDAL
    {
        public ObservableCollection<Stock> GetAllStocks()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStocks", con);
                ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Stock()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Product = reader["Produs"].ToString(),
                        Quantity = Convert.ToInt32(reader["Cantitate"]),
                        Unit = reader["Unit"].ToString(),
                        Acq_Date = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("Acq_Date"))),
                        Acq_Price = Convert.ToSingle(reader["Acq_Price"]),
                        Sell_Price = Convert.ToSingle(reader["Sell_Price"])
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
        public void AddStock(Stock stock)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramProduct = new SqlParameter("@product", stock.Product);
                SqlParameter paramQuantity = new SqlParameter("@quantity", stock.Quantity);
                SqlParameter paramUnit = new SqlParameter("@unit", stock.Unit);
                SqlParameter paramAcqDate = new SqlParameter("@acq_date", new DateTime(stock.Acq_Date.Year,
                                                                                       stock.Acq_Date.Month,
                                                                                       stock.Acq_Date.Day));
                SqlParameter paramAcqPrice = new SqlParameter("@acq_price", stock.Acq_Price);
                SqlParameter paramSellPrice = new SqlParameter("@sell_price", stock.Sell_Price);

                cmd.Parameters.Add(paramProduct);
                cmd.Parameters.Add(paramQuantity);
                cmd.Parameters.Add(paramUnit);
                cmd.Parameters.Add(paramAcqDate);
                cmd.Parameters.Add(paramAcqPrice);
                cmd.Parameters.Add(paramSellPrice);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStock(Stock stock)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", stock.Id);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyStock(Stock stock)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", stock.Id);
                SqlParameter paramProduct = new SqlParameter("@product", stock.Product);
                SqlParameter paramQuantity = new SqlParameter("@quantity", stock.Quantity);
                SqlParameter paramUnit = new SqlParameter("@unit", stock.Unit);
                SqlParameter paramAcqDate = new SqlParameter("@acq_date", new DateTime(stock.Acq_Date.Year,
                                                                                       stock.Acq_Date.Month,
                                                                                       stock.Acq_Date.Day));
                SqlParameter paramAcqPrice = new SqlParameter("@acq_price", stock.Acq_Price);
                SqlParameter paramSellPrice = new SqlParameter("@sell_price", stock.Sell_Price);

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramProduct);
                cmd.Parameters.Add(paramQuantity);
                cmd.Parameters.Add(paramUnit);
                cmd.Parameters.Add(paramAcqDate);
                cmd.Parameters.Add(paramAcqPrice);
                cmd.Parameters.Add(paramSellPrice);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

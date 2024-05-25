using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace supermarket_manager.Models.DataAccessLayer
{
    class SuplierDAL
    {
        public ObservableCollection<Suplier> GetAllSupliers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSupliers", con);
                ObservableCollection<Suplier> result = new ObservableCollection<Suplier>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Suplier()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Country = reader["Country"].ToString(),
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

        public int GetSuplierID(string name)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSuplierID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@name", name));

                int queryResult = 0;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    queryResult = Convert.ToInt32(reader["Id"]);
                }
                reader.Close();
               return queryResult;
            }
            finally
            {
                con.Close();
            }
        }

        public string GetSuplierName(string id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSuplierName", con);
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

        public void AddSuplier(Suplier suplier)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSuplier", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", suplier.Name);
                SqlParameter paramCountry = new SqlParameter("@country", suplier.Country);

                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramCountry);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSuplier(Suplier suplier)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSuplier", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name", suplier.Name);
                cmd.Parameters.Add(paramName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifySuplier(Suplier suplier)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifySuplier", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", suplier.Id);
                SqlParameter paramName = new SqlParameter("@name", suplier.Name);
                SqlParameter paramCountry = new SqlParameter("@country", suplier.Country);

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramCountry);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using supermarket_manager.Models.EntityLayer;
using System.Data;
using System.Data.SqlClient;


namespace supermarket_manager.Models.DataAccessLayer
{
    class UserDAL
    {
        public Role GetUserByLogin(string username, string password)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetPersonByLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@usern", username));
                cmd.Parameters.Add(new SqlParameter("@psw", password));

                string queryResult = null;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    queryResult = reader["Role"].ToString();
                }
                reader.Close();
                if ((queryResult=="Admin"))
                {
                    return Role.Admin;
                }
                if((queryResult=="Cashier"))
                {
                    return Role.Cashier;
                }
                return Role.None;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

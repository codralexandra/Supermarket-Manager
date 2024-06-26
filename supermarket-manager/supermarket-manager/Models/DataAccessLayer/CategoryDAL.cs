﻿using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace supermarket_manager.Models.DataAccessLayer
{
    class CategoryDAL
    {
        public ObservableCollection<Category> GetAllCategories()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllCategories", con);
                ObservableCollection<Category> result = new ObservableCollection<Category>();
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
                    result.Add(new Category()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString()
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

        public void AddCategory(Category category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramName = new SqlParameter("@name",  category.Name);

                cmd.Parameters.Add(paramName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyCategory(Category category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", category.Id);
                SqlParameter paramName = new SqlParameter("@name", category.Name);

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(Category category)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", category.Id);

                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public string GetCategoryName(int id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetCategoryName", con);
                string? result = null;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("id",id);
                cmd.Parameters.Add(idParam);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader["Name"].ToString();
                }
                reader.Close();
                if (result != null)
                    return result;
                else return "None";
            }
            finally
            {
                con.Close();
            }
        }

        public int GetCategoryID(string name)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetCategoryID", con);
                int result = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("name", name);
                cmd.Parameters.Add(nameParam);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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

        public int CheckCategory(Category category)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("CheckCategory", con);
                int result = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("name", category.Name);
                cmd.Parameters.Add(idParam);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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
    }
}

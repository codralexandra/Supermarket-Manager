using supermarket_manager.Models.DataAccessLayer;
using System.Collections.ObjectModel;
using System;
using supermarket_manager.Models.EntityLayer;

namespace supermarket_manager.Models.BusinessLogicLayer
{
    class UserBLL
    {
        UserDAL persoanaDAL = new UserDAL();

        public Role GetUserByLogin(string username, string password)
        {
            if(username == null || password == null)
            {
                throw new ArgumentNullException("Username or password must be specified.");
            }
            return persoanaDAL.GetUserByLogin(username, password);
        }
    }
}

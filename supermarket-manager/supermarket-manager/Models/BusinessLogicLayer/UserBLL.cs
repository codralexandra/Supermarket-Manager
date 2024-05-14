using supermarket_manager.Models.DataAccessLayer;
using System.Collections.ObjectModel;
using System;
using supermarket_manager.Models.EntityLayer;
using System.Windows;

namespace supermarket_manager.Models.BusinessLogicLayer
{
    class UserBLL
    {
        UserDAL userDAL = new UserDAL();
        public ObservableCollection<User> UsersList { get; set; }

        public Role GetUserByLogin(string username, string password)
        {
            if(username == null || password == null)
            {
                throw new ArgumentNullException("Username or password must be specified.");
            }
            return userDAL.GetUserByLogin(username, password);
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public void AddUser(User user)
        {
            userDAL.AddUser(user);
            UsersList.Add(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                MessageBox.Show("Must select a user to delete.");
            }
            else
            {
                userDAL.DeleteUser(user);
                UsersList.Remove(user);
            }
        }
    }
}

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

        #region helpers
        private Role GetOpposite(Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    return Role.Cashier;
                case Role.Cashier:
                    return Role.Admin;
                default:
                    return Role.None;
            }
        }

        private Role stringToRole(string role)
        {
            switch (role)
            {
                case "Admin":
                    return Role.Admin;
                case "Cashier":
                    return Role.Cashier;
                default: return Role.None;
            }
        }

        #endregion

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
            if(user == null || user.Username=="" || user.Password == "" || user.Role == "")
            {
                MessageBox.Show("All fields are mandatory.");
            }
            else if(userDAL.GetUserByLogin(user.Username, user.Password)!=Role.None)
            {
                MessageBox.Show("User already exists.");
            }
            else if(userDAL.GetUserByLogin(user.Username, user.Password)==GetOpposite(stringToRole(user.Role)))
            {
                MessageBox.Show("Can't add the same user with a different role."); //Not really neccessary (?)
            }
            else
            {
                userDAL.AddUser(user);
                UsersList.Add(user);
            }
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

        public void ModifyUser(User user)
        {
            if(user==null)
            {
                MessageBox.Show("You must select a user to modify.");
            }
            else if(user.Username=="" || user.Password=="" || user.Role=="")
            {
                MessageBox.Show("All fields are mandatory.");
            }
            else
            {
                userDAL.ModifyUser(user);
                MessageBox.Show("User information updated successfully!");
            }
        }
    }
}

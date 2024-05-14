using WpfMVVMAgendaCommands.Models;

namespace supermarket_manager.Models.EntityLayer
{
    class User: BasePropertyChanged
    {
        private string ?username;
        private string ?password;
        private string ?role;
        private bool? valid;

        public string? Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string? Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string? Role
        {
            get { return role; }
            set
            {
                role = value;
                NotifyPropertyChanged("Role");
            }
        }

        public bool? Valid
        {
            get { return valid; }
            set
            {
                valid = value;
                NotifyPropertyChanged("Valid");
            }
        }
    }
}

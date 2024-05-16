using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.DataAccessLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    class SupliersCRUDVM
    {
        SuplierBLL suplierBLL = new SuplierBLL();
        public ObservableCollection<Suplier> SuplierList
        {
            get => suplierBLL.SuplierList;
            set => suplierBLL.SuplierList = value;
        }
        public SupliersCRUDVM()
        {
            SuplierList = suplierBLL.GetAllSupliers();
        }

        #region Commands

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Suplier>(suplierBLL.AddSuplier);
                }
                return addCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Suplier>(suplierBLL.DeleteSuplier);
                }
                return deleteCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Suplier>(suplierBLL.ModifySuplier);
                }
                return updateCommand;
            }
        }
        #endregion
    }
}

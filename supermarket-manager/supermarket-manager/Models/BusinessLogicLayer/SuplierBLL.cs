using supermarket_manager.Models.DataAccessLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;

namespace supermarket_manager.Models.BusinessLogicLayer
{
    class SuplierBLL
    {
        SuplierDAL suplierDAL = new SuplierDAL();
        public ObservableCollection<Suplier> SuplierList { get; set; }

        public ObservableCollection<Suplier> GetAllSupliers()
        {
            return suplierDAL.GetAllSupliers();
        }

        public void AddSuplier(Suplier suplier)
        {
            if (suplier == null || suplier.Name == "" || suplier.Country == "")
            {
                MessageBox.Show("All fields are mandatory.");
            }
            else if (suplierDAL.GetSuplierID(suplier.Name)!=0)
            {
                MessageBox.Show("Suplier already exists.");
            }
            else
            {
                suplierDAL.AddSuplier(suplier);
                SuplierList.Add(suplier);
            }
        }

        public void DeleteSuplier(Suplier suplier)
        {
            if (suplier == null)
            {
                MessageBox.Show("Must select a suplier to delete.");
            }
            else
            {
                suplierDAL.DeleteSuplier(suplier);
                SuplierList.Remove(suplier);
            }
        }

        public void ModifySuplier(Suplier suplier)
        {
            if (suplier == null)
            {
                MessageBox.Show("You must select a suplier to modify.");
            }
            else if (suplier.Name == "" || suplier.Country == "")
            {
                MessageBox.Show("All fields are mandatory.");
            }
            else
            {
                suplierDAL.ModifySuplier(suplier);
                MessageBox.Show("Suplier information updated successfully!");
            }
        }

        public string GetSuplierName(int id)
        {
            return suplierDAL.GetSuplierName(id);
        }

        public int GetSuplierID(string name)
        {
            return suplierDAL.GetSuplierID(name);
        }
    }
}

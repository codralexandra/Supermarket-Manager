using supermarket_manager.Models.DataAccessLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;

namespace supermarket_manager.Models.BusinessLogicLayer
{
    class CategoryBLL
    {
        CategoryDAL categoryDAL = new CategoryDAL();
        JoinDALs joinDAL = new JoinDALs();
        public ObservableCollection<Category> CategoryList { get; set; }

        public ObservableCollection<Category> GetAllCategories()
        {
            return categoryDAL.GetAllCategories();
        }

        public void AddCategory(Category category)
        {
            if (category == null || category.Name == "")
            {
                MessageBox.Show("All fields are mandatory.");
            }
            else if (categoryDAL.CheckCategory(category) != 0)
            {
                MessageBox.Show("Category already exists!");
            }
            else
            {
                categoryDAL.AddCategory(category);
                CategoryList.Add(category);
            }
        }

        public void UpdateCategory(Category category)
        {
            if (category != null && category.Name == categoryDAL.GetCategoryName(category.Id))
            {
                MessageBox.Show("In order to update you must select a new name.");
            }
            else if (category != null && category.Name != null)
            {
                categoryDAL.ModifyCategory(category);
            }
            else
            {
                MessageBox.Show("All fields are mandatory.");
            }
        }

        public void DeleteCategory(Category category)
        {
            if (category != null && joinDAL.GetProductsByCategory(category).Count() != 0)
            {
                MessageBox.Show("You can't delete this category because there are products registered under it!");
            }
            else if (category == null)
            {
                MessageBox.Show("Must select a category in order to delete.");
            }
            else
            {
                categoryDAL.DeleteCategory(category);
                CategoryList.Remove(category);
            }
        }
        public string GetCategoryName(int id)
        {
            return categoryDAL.GetCategoryName(id);
        }

        public int GetCategoryID(string name)
        {
            return categoryDAL.GetCategoryID(name);
        }
    }
}

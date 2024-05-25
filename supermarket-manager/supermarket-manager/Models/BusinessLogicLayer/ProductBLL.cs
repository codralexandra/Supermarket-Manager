using supermarket_manager.Models.DataAccessLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;

namespace supermarket_manager.Models.BusinessLogicLayer
{
    class ProductBLL
    {
        ProductDAL productDAL = new ProductDAL();
        public ObservableCollection<Product> ProductList { get; set; }
        public ObservableCollection<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }
        public void AddProduct(Product product)
        {
            if (product == null || product.Name == "" || product.CategoryId == 0)
            {
                MessageBox.Show("All fields are mandatory.");
            }
            else
            {
                productDAL.AddProduct(product);
                ProductList.Add(product);
            }
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                MessageBox.Show("Must select a product to delete.");
            }
            else
            {
                productDAL.DeleteProduct(product);
                ProductList.Remove(product);
            }
        }

        public void ModifyProduct(Product product)
        {
            if (product == null)
            {
                MessageBox.Show("You must select a product to modify.");
            }
            else if (product.Name == "" || product.CategoryId == 0)
            {
                MessageBox.Show("All fields are mandatory.");
            }
            else
            {
                productDAL.ModifyProduct(product);
                MessageBox.Show("Product information updated successfully!");
            }
        }
    }
}

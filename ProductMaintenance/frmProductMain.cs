using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public partial class frmProductMain : Form
	{
        private List<Product> products = null;

		public frmProductMain()
		{
			InitializeComponent();
		}

	
        //getting all the products from the file and populating products
		private void frmProductMain_Load(object sender, EventArgs e)
		{
            products = ProductDB.GetProducts();
            FillProductListBox();

			
		}

        //populate the display list of products
        private void FillProductListBox()
        {
            lstProducts.Items.Clear();
            foreach(Product p in products)
            {
                lstProducts.Items.Add(p.GetDisplayText("\t"));
            }
            
        }
        //show the new add product form
        private void btnAdd_Click(object sender, EventArgs e)
		{
            frmNewProduct newProductForm = new frmNewProduct();
            newProductForm.ShowDialog();
            Product product = newProductForm.GetNewProduct();
            if(product != null)
            {
                products.Add(product);
                ProductDB.SaveProducts(products);
                FillProductListBox();
            }
			
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
            int i = lstProducts.SelectedIndex;
            if (i != -1)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete the product?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Product product = products[i];

                if(confirm == DialogResult.Yes)
                {
                    products.Remove(product);
                    ProductDB.SaveProducts(products);
                    FillProductListBox();

                }
            }
            else
            {
                MessageBox.Show("Please select the product to delete", "Delletiuon Unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
			
		}

        //close the form
		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
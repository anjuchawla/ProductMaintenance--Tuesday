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
    public partial class frmNewProduct : Form
    {
        Product product = null;

        public frmNewProduct()
        {
            InitializeComponent();
        }





        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtCode) && Validator.IsPresent(txtDescription) && Validator.IsPresent(txtPrice)
                && Validator.IsDecimal(txtPrice) && Validator.IsWithinRange(txtPrice, 0, Decimal.MaxValue))
            {
                
                product = new Product(txtCode.Text, txtDescription.Text, Convert.ToDecimal(txtPrice.Text));
                this.Close();

            }

        }//

        public Product GetNewProduct()
        {
            return product;
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
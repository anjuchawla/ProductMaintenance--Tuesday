/***
 * Name : Anju Chawla
 * Date: Nov. 22, 2016
 * Purpose: This helper/utility class defines the methods to validat a product's
 * code, description and price
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public static class Validator
	{
        private static string title; //title = "Entry Error";

        public static string Title { get; private set; } // = " Entry Error";

        //method to check if the input is provided
        public static bool IsPresent(TextBox textBox)
        {
            if(textBox.Text == String.Empty)
            {
                Title = " Entry Error";
                Title = textBox.Tag + Title;
                MessageBox.Show(textBox.Tag + " is a required field...cannot be blank", Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox.Focus();
                return false;
            }
            return true;

        }//IsPresent

        //this method checks if the input is a decimal number
        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0m;
            
            if(Decimal.TryParse(textBox.Text,out number))
            {
                return true;
            }
            else
            {
                Title = " Entry Error";
                Title = textBox.Tag + Title;
                MessageBox.Show(textBox.Tag + " must be a decimal value", Title,
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox.SelectAll();
                textBox.Focus();
                return false;

            }
        }//IsDecimal

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);  //Decimal.Parse

            if(number >= min && number <= max)
            {
                return true;
            }
            else
            {
                Title = " Entry Error";
                Title = textBox.Tag + Title;
                MessageBox.Show(textBox.Tag + " must be between " + min + " and " + max, 
                    Title,  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox.SelectAll();
                textBox.Focus();
                return false;

            }


        }


                        
	}
}

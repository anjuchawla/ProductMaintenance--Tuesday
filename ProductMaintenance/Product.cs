
using System;
/**
* Name: Anju Chawla
* Date: Nov 22, 2016
* Purpose: Define a class Product that defines the fields and properties and methods
* associated with it.
*/
namespace ProductMaintenance
{
    public class Product
    {
        //fields
        private string code;
        // private string description;
        private decimal price;

        //constructors
        public Product()
        {

        }

        public Product(string code, string description, decimal price)
        {
            ///use set methods to initialise the fields
            this.Code = code;  //call the set method of the fiels code
            this.Description = description;
            Price = price;


        }

        //properties - getters and setters
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                if (value.Length != 4)
                    throw new ArgumentException("Code should be of length 4");

                code = value;
            }
        }

        //self bodied property
        public string Description { get; set; } 

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {

                price = value;

            }
        }

        //method
        /*public string GetDisplayText()
        {
            //using the getter of the properties
            return Code + ", " + Description + ", " + Price.ToString("c");

        }*/
        //self bodied method using the lambda opearator
        public string GetDisplayText() => Code + ", " + Description + ", " + Price.ToString("c");

        //override
        public string GetDisplayText(string sep)
        {
            //using the getter of the properties
            return Code + sep + Description + sep + price.ToString("c");

        }


    }//of class
}

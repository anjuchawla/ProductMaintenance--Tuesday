using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaintenance
{
    public class ProductList
	{
		private List<Product> products;
        //a delegate is a type that can refer to methods with a specific return type and a parameter list-like a pointer to a function in C
		public delegate void ChangeHandler(ProductList products);
        //a common use of delegates is to wire an event handler to an event so the event handler is called when the event is raised
        //an event IServiceProvider a signal that an action has occured on an object that was created from the class
		public event ChangeHandler Changed;

		public ProductList()
		{
			products = new List<Product>();
		}

        public int Count => products.Count;

        //indexer is a special type of property that lets the user access individual items within the class by specifying an index value
		public Product this[int i]
		{
			get
			{
				if (i < 0)
				{
					throw new ArgumentOutOfRangeException("i");
				}
				else if (i >= products.Count)
				{
					throw new ArgumentOutOfRangeException("i");
				}
				return products[i];
			}
			set
			{
				products[i] = value;
				Changed(this); //to raise the event, you refer to it by its name and code the arguments required by the delegate
			}
		}

		public Product this[string code]
		{
			get
			{
				foreach (Product p in products)
				{
					if (p.Code == code)
						return p;
				}
				return null;
			}
		}

		public void Fill() => products = ProductDB.GetProducts();

		public void Save() => ProductDB.SaveProducts(products);

		public void Add(Product product)
		{
			products.Add(product);
			Changed(this);
		}

		public void Add(string code, string description, decimal price)
		{
			Product p = new Product(code, description, price);
			products.Add(p);
			Changed(this);
		}

		public void Remove(Product product)
		{
			products.Remove(product);
			Changed(this);
		}

        //both unary and binary operators can be overloaded in C#, need one or two operands.
        //can overload the == and != opeartors too to compare contentc of two objects instead of references
        public static ProductList operator +(ProductList pl, Product p)
        {
            pl.Add(p);
            return pl;
        }

        public static ProductList operator - (ProductList pl, Product p)
		{
			pl.Remove(p);
			return pl;
		}

	}
}

/*
 * File: RealItemManager.cs
 * Authors: Amarandei Narcis,Balan Paul , Bruma Elena, Teohari Adrian
 * Description: This file is used to communicate with the database and manipulate data.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Database;
using System.Windows.Forms;

namespace Casademarcat
{
    public class RealItemManager : IItemManager
    {
        private Database.Database database = new Database.Database();

        public Database.ProductModel AddItem(string code)//gets the product associated with the code and returns it, also removes 1 unit from stock
        {
            Database.ProductModel product = new ProductModel();

            try
            {
                product = this.database.GetProduct(code);
            }
            catch (System.InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return product;
        }

        public bool CheckItem(string code)//checks if the item exists and is in stock
        {
            try
            {
                int count = database.CountProduct(code);
                if (count >= 1)
                    return true;
                else
                    return false;
            }
            catch (System.InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public void RemoveItem(ProductModel product)//adds 1 unit back to stock to specified product
        {
            //Update quantity in db
            database.IncrementItem(product);
        }
    }
}

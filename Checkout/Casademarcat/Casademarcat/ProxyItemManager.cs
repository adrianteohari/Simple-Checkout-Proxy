/*
 * File: ProxyItemManager.cs
 * Authors: Amarandei Narcis,Balan Paul , Bruma Elena, Teohari Adrian
 * Description: This file contains the functional elements behind the UI and has the role to link front-end to back-end.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casademarcat
{
    public class ProxyItemManager : IItemManager
    {
        private RealItemManager _realItemManager; 
        private List<Database.ProductModel> _bon; //receipt to be shown in the UI, contains all the products added
        
        public ProxyItemManager()
        {
            _realItemManager = new RealItemManager(); 
            _bon = new List<Database.ProductModel>(); 
        }
        public Database.ProductModel AddItem(string code)
        {
            _bon.Add(_realItemManager.AddItem(code)); //tells realItemmanager the code of the product, it will return its name and price and add it to the receipt

            return new Database.ProductModel();//this isnt used anywhere further but it's necessary because of interface implementation
        }

        public bool CheckItem(string code)//tells realItemManager to check if there is an item with that code and is still in stock, returns true or false.
        {
            return _realItemManager.CheckItem(code);
        }

        public void RemoveItem(Database.ProductModel product)//removes selected produc from the receipt then tells realItemManager to put it back in stock
        {
            _bon.Remove(product);
            _realItemManager.RemoveItem(product);
        }
        public List<Database.ProductModel> UpdateReceipt()// returns the receipt to the UI to be shown
        {
            return _bon;
        }
    }
}

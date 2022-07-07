/*
 * File: CasaDeMarcatTest.cs
 * Authors: Amarandei Narcis,Balan Paul , Bruma Elena, Teohari Adrian
 * Description: Interface used for the Proxy design pattern
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casademarcat
{
    public interface IItemManager
    {
        bool CheckItem(string code); //checks if the item exists and is in stock
        Database.ProductModel AddItem(string code); //adds the product to the receipt and removes 1 unit from stock
        void RemoveItem(Database.ProductModel product);  //removes item from receipt and adds it back in stock
    }
}

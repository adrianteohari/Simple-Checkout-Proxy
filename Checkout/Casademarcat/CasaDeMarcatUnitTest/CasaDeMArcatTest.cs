/*
 * File: CasaDeMarcatTest.cs
 * Authors: Amarandei Narcis,Balan Paul , Bruma Elena, Teohari Adrian
 * Description: This file contains all the unit tests performed on the program.
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Casademarcat;
using Database;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CasaDeMarcatUnitTest
{
    [TestClass]
    public class CasaDeMarcatTest
    {
        public ProxyItemManager _proxyItem;
        public Database.Database _db;
        [TestInitialize]
        public void Initialize()
        {
            _proxyItem = new ProxyItemManager();
            _db = new Database.Database();
            
        }

        [TestMethod]
        public void TrueCheckItem() //checks if a item that should be in the db is there.
        {
            Assert.IsTrue(_proxyItem.CheckItem("12345"));
        }
        [TestMethod]
        public void FalseCheckItem()//checks if a item that shouldn't be in the db is there.
        {
            Assert.IsFalse(_proxyItem.CheckItem("54684"));
        }

        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void ExceptionCheckItem() //checks for an exception.
        {
            _proxyItem.CheckItem("/\"\"/+\''\\\"\"");
        }

 
        [TestMethod]
        public void CovrigAddItemTest()//checks if the item "covrig" was added
        {
            Database.ProductModel product = new ProductModel();
            product=_proxyItem.AddItem("12345");
            Assert.AreEqual("Covrig", product.Name);

        }

        [TestMethod]
        public void PaineAddItemTest()//checks if the item "paine" was added
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("1234");
            Assert.AreEqual("Paine", product.Name);

        }

        [TestMethod]
        public void addOutOfStockItemTest()//tests addItem with a nonexisting item
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("1234");
            Assert.AreEqual(0, product.Quantity);

        }

        [TestMethod]
        public void decrementQuantityTest()//checks if the quantity decrements when an item is added on the receipt
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("12345");
            int quantity = product.Quantity;
            product = _proxyItem.AddItem("12345");
            bool result = ( (quantity - product.Quantity) > 0);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void incrementProductDB()//checks id the quantity increments if the item is removed from the receipt.
        {
            Database.ProductModel product = new Database.ProductModel();
            product.Code = "12345";
            _db.IncrementItem(product) ;
            Assert.AreEqual(900, _db.GetProduct("12345").Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void decrementProductExceptionDB()//tests the exception that should be thrown on decrement.
        {
            Database.ProductModel product = new Database.ProductModel();
            product.Code = "12345";
            _db.DecrementQuantity(product);
        }

        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void ExceptionAddItem()//tests the exception that should be thrown ehen add an Iten.
        {
            _proxyItem.AddItem("cevA");
        }


        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void ExceptionGetProduct()//tests the exception that should be thrown.
        {
            _db.GetProduct("cevA");
        }

        [TestMethod]
  //      [ExpectedException(typeof(MySqlException))]
        public void ValidCountProduct()//Tests if a nonexistent product will be counted right.
        {
           Assert.AreEqual(0, _db.CountProduct("cevA"));
        }

        [TestMethod]
        public void IncorrectCountProduct()//Tests if a nonexistent product will be counted right.
        {
            Assert.AreEqual(34, _db.CountProduct("1234"));
        }

        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void ExceptionCountProduct()//tests the exception
        {
            _db.CountProduct("/\"\"/+\''\\\"\"");
        }

        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void ExceptionIncrementProductDB()//checks id the quantity increments if the item is removed from the receipt.
        {
            Database.ProductModel product = new Database.ProductModel();
            product.Code = "/\"\"/+\''\\\"\"";
            _db.IncrementItem(product);
   //         Assert.AreEqual(900, _db.GetProduct("/\"\"/+\''\\\"\"").Quantity);
        }

        [TestMethod]
        public void PaineProductTest()
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("1234");
            Assert.AreEqual("Paine - 12.3 lei", product.Product);

        }

        [TestMethod]
        public void CovrigProductTest()
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("12345");
            Assert.AreEqual("Covrig - 16.5 lei", product.Product);

        }

        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void ExceptionProductTest()
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("123e1245");
            Assert.AreEqual("Covrig - 16.5 lei", product.Product);

        }

        [TestMethod]
        public void removeItemReceipt()
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("12345");
            List<Database.ProductModel> receipt = _proxyItem.UpdateReceipt();
            int lenght = receipt.Count;
            _proxyItem.RemoveItem(product);
            bool ok = ((lenght - receipt.Count) == 1);
            Assert.IsTrue(ok);
        }

        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void ExceptionRemoveItemReceipt()
        {
            Database.ProductModel product = new ProductModel();
            product = _proxyItem.AddItem("123456");
            List<Database.ProductModel> receipt = _proxyItem.UpdateReceipt();
            int lenght = receipt.Count;
            _proxyItem.RemoveItem(product);
            bool ok = ((lenght - receipt.Count) == 1);
            Assert.IsTrue(ok);
        }
    }
}

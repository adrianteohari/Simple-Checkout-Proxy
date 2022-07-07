/*
 * File: Database.cs
 * Authors: Amarandei Narcis,Balan Paul , Bruma Elena, Teohari Adrian
 * Description: This file is used to connect to the database and impelent the DB commands used in the program.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Database
{
    public class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Database()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "csharp";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        break;

                    case 1045:
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        //Removes one from inventory
        public void DecrementQuantity(ProductModel product)
        {
            string query = "UPDATE products SET quantity = quantity - 1 WHERE code= \"" + product.Code + "\"";

            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();
        }

        //Adds one from inventory
        public void IncrementItem(ProductModel product)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                string query = "UPDATE products SET quantity = quantity + 1 WHERE code= \"" + product.Code + "\"";

                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();
            }
        }

        //Gets a product from the db
        public ProductModel GetProduct(string code)
        {
            string sql = "SELECT * FROM products WHERE code= \"" + code + "\" LIMIT 1;";
            ProductModel Product = new ProductModel();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader DataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                DataReader.Read();

                //Create new Product object
                Product.Id = (int)DataReader["id"];
                Product.Name = (string)DataReader["name"];
                Product.Price = (double)DataReader["price"];
                Product.Quantity = (int)DataReader["quantity"];
                Product.Code = (string)DataReader["code"];

                //close Data Reader
                DataReader.Close();

                //Decrement the quantity
                this.DecrementQuantity(Product);

                //close Connection
                this.CloseConnection();
            }

            return Product;
        }

        //Count a product from the db
        public int CountProduct(string code)
        {
            string sql = "SELECT COUNT(name) AS product_count FROM products WHERE code = \"" + code + "\" AND quantity > 0;";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

            }

            return Count;
        }
    }
}

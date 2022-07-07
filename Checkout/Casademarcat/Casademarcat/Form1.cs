/*
 * File: Form1.cs
 * Authors: Amarandei Narcis,Balan Paul , Bruma Elena, Teohari Adrian
 * Description: This file contains the UI and all its functionalites, also has some error addressing code.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casademarcat
{
    public partial class MainForm : Form
    {
        private ProxyItemManager _proxyItemManager;
        public MainForm()
        {
            InitializeComponent();
            _proxyItemManager = new ProxyItemManager();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            //Help button text

            try
            {
                System.Diagnostics.Process.Start(@"C:\ipppp\proiectIp\Casademarcat\Casademarcat\casamarcathelp.chm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exit button
        }

        private void Adauga_Click(object sender, EventArgs e)
        {
            if(_proxyItemManager.CheckItem(codProdus.Text))
            {
                _proxyItemManager.AddItem(codProdus.Text);

                List<Database.ProductModel> receipt = _proxyItemManager.UpdateReceipt();

                //Clear the elements previously added
                listBoxReceipt.Items.Clear();
            
                //Update with the new list
                for (int i = 0;i < receipt.Count();i++)
                {
                    listBoxReceipt.Items.Add(receipt[i].Product);
                }

                //Update total
                textBoxTotal.Text = (Double.Parse(textBoxTotal.Text) + receipt.Last().Price).ToString();
            }
            else
            {
                MessageBox.Show("Eroare!\nAcest produs nu este in stoc");
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Choose which product is select for delete
            if (listBoxReceipt.SelectedIndex >= 0)
            {
                string product = listBoxReceipt.SelectedItem.ToString();

                //Get the index of the deleted item
                int productIndex = listBoxReceipt.Items.IndexOf(listBoxReceipt.SelectedItem);
                List<Database.ProductModel> receipt = _proxyItemManager.UpdateReceipt();
                Database.ProductModel productObj = receipt[productIndex];

                //Update the database
                _proxyItemManager.RemoveItem(productObj);

                //Delete from list box
                listBoxReceipt.Items.Remove(product);

                //Update total
                textBoxTotal.Text = (Double.Parse(textBoxTotal.Text) - productObj.Price).ToString();

                MessageBox.Show("Produsul " + product + " a fost sters din lista."); 
            }
        }

    }
}


namespace Casademarcat
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.codProdus = new System.Windows.Forms.TextBox();
            this.Adauga = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.listBoxReceipt = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod produs:";
            // 
            // codProdus
            // 
            this.codProdus.Location = new System.Drawing.Point(128, 23);
            this.codProdus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codProdus.Name = "codProdus";
            this.codProdus.Size = new System.Drawing.Size(112, 26);
            this.codProdus.TabIndex = 1;
            // 
            // Adauga
            // 
            this.Adauga.Location = new System.Drawing.Point(246, 15);
            this.Adauga.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Adauga.Name = "Adauga";
            this.Adauga.Size = new System.Drawing.Size(99, 42);
            this.Adauga.TabIndex = 2;
            this.Adauga.Text = "Adauga";
            this.Adauga.UseVisualStyleBackColor = true;
            this.Adauga.Click += new System.EventHandler(this.Adauga_Click);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(923, 20);
            this.Help.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(95, 42);
            this.Help.TabIndex = 3;
            this.Help.Text = "Ajutor";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(1170, 20);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(99, 42);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // listBoxReceipt
            // 
            this.listBoxReceipt.FormattingEnabled = true;
            this.listBoxReceipt.ItemHeight = 20;
            this.listBoxReceipt.Location = new System.Drawing.Point(31, 97);
            this.listBoxReceipt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxReceipt.Name = "listBoxReceipt";
            this.listBoxReceipt.Size = new System.Drawing.Size(1296, 384);
            this.listBoxReceipt.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bon:";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(1033, 20);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(114, 42);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Sterge";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Enabled = false;
            this.textBoxTotal.Location = new System.Drawing.Point(610, 23);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(126, 26);
            this.textBoxTotal.TabIndex = 9;
            this.textBoxTotal.Text = "0";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(550, 25);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(44, 20);
            this.labelTotal.TabIndex = 10;
            this.labelTotal.Text = "Total";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(742, 26);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(24, 20);
            this.labelCurrency.TabIndex = 11;
            this.labelCurrency.Text = "lei";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 506);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxReceipt);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Adauga);
            this.Controls.Add(this.codProdus);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codProdus;
        private System.Windows.Forms.Button Adauga;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ListBox listBoxReceipt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelCurrency;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
	public partial class frmInvoiceTotal : Form
	{
        public frmInvoiceTotal()
		{
			InitializeComponent();
		}

		private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
                decimal discountPercent = .25m;
                decimal discountAmount = subtotal * discountPercent;
                decimal invoiceTotal = subtotal - discountAmount;

                txtDiscountPercent.Text = discountPercent.ToString("p1");
                txtDiscountAmount.Text = discountAmount.ToString("c");
                txtTotal.Text = invoiceTotal.ToString("c");

                txtSubtotal.Focus();

                if (subtotal >= 10000)
                    throw new Exception(
                            "An overflow exception has occurred. Please enter smaller values.");

                if (invoiceTotal <= 100)
                    throw new Exception(
                        "Invoice total is less than 100.00. Please use a larger invoice subtotal.");
            }
            catch (FormatException) // a specific exception
            {
                MessageBox.Show(
                    "Please enter a valid number for the Subtotal field.",
                    "Entry Error");
            }
            catch (OverflowException) 
            {
                MessageBox.Show(
                    "An overflow exception has occurred. Please enter smaller values.",
                    "Entry Error");
            }
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
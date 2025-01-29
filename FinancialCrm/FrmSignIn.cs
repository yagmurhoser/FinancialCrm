using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
	public partial class FrmSignIn : Form
	{
		public FrmSignIn()
		{
			InitializeComponent();
		}
		FinancialCrmDbEntities db = new FinancialCrmDbEntities();
		private void button1_Click(object sender, EventArgs e)
		{
			var value = db.Users.Where(x => x.UserName == textBox1.Text && x.Password ==  textBox2.Text).FirstOrDefault();
			if (value != null)
			{
				FrmDashboard form = new FrmDashboard();
				form.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Wrong UserName or Password");
			}
		}

		private void label3_Click(object sender, EventArgs e)
		{
			textBox1.Text="";
			textBox2.Text ="";
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if(checkBox1.Checked)
			{
				textBox2.PasswordChar = '\0';
			}
			else
			{
				textBox2.PasswordChar = '*';
			}
		}
	}
}

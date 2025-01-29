using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
	public partial class FrmBiiling : Form
	{
		public FrmBiiling()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();
		private void FrmBiiling_Load(object sender, EventArgs e)
		{
			var value = db.Bills.ToList();
			dataGridView1.DataSource = value;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			var value = db.Bills.ToList();
			dataGridView1.DataSource = value;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			Bills bills = new Bills();
			bills.BillTitle = textBox2.Text;
			bills.BillAmount = decimal.Parse(textBox3.Text);
			bills.BillPeriod = textBox4.Text;
			db.Bills.Add(bills);
			db.SaveChanges();
			MessageBox.Show("Ödeme Sisteme Eklendi", "Ödeme & Faturalar",MessageBoxButtons.OK, MessageBoxIcon.Information);
			var value = db.Bills.ToList();
			dataGridView1.DataSource = value;

		}

		private void button11_Click(object sender, EventArgs e)
		{
			int id = int.Parse(textBox1.Text);
			var value = db.Bills.Find(id);
			db.Bills.Remove(value);
			db.SaveChanges();
			MessageBox.Show("Ödeme Sistemden Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
			var list = db.Bills.ToList();
			dataGridView1.DataSource = list;
		}

		private void button12_Click(object sender, EventArgs e)
		{
			int id = int.Parse(textBox1.Text);
			var value = db.Bills.Find(id);
			value.BillTitle = textBox2.Text;
			value.BillAmount = decimal.Parse(textBox3.Text);
			value.BillPeriod = textBox4.Text;
			db.SaveChanges();
			MessageBox.Show("Ödeme Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
			var list = db.Bills.ToList();
			dataGridView1.DataSource = list;


		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
			textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
			textBox3.Text =dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
			textBox4.Text =dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FrmBanks banks = new FrmBanks();
			banks.Show();
			this.Hide();
		}

		private void label6_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}

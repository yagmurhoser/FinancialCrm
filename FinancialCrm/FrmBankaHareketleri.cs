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
	public partial class FrmBankaHareketleri : Form
	{
		public FrmBankaHareketleri()
		{
			InitializeComponent();
		}
		FinancialCrmDbEntities db = new FinancialCrmDbEntities();

		void Listele()
		{
			dataGridView1.DataSource  = db.BankProcesses.Join(db.Banks,
				process => process.BankId,
				banks => banks.BankId,
				(process, banks) => new
				{
					ID = process.BankProcessId,
					BankaAdı = banks.BankTitle,
					IslemTuru = process.ProcessType,
					Tutar = process.Amount,
					Acıklama = process.Description,
					IslemTarihi = process.ProcessDate
				}).ToList();
		}
		private void FrmBankaHareketleri_Load(object sender, EventArgs e)
		{
			Listele();



		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex % 2 == 0) // Çift satırlar için
			{
				dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
			}
			else // Tek satırlar için
			{
				dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource  = db.BankProcesses.Join(db.Banks,
				process => process.BankId,
				banks => banks.BankId,
				(process, banks) => new
				{
					ID = process.BankProcessId,
					BankaAdı = banks.BankTitle,
					IslemTuru = process.ProcessType,
					Tutar = process.Amount,
					Acıklama = process.Description,
					IslemTarihi = process.ProcessDate
				}).Where(x => x.IslemTarihi == dateTimePicker1.Value.Date).ToList();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			Listele();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			FrmDashboard form = new FrmDashboard();
			form.Show();
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FrmBanks banks = new FrmBanks();
			banks.Show();
			this.Hide();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			FrmBiiling biil = new FrmBiiling();
			biil.Show();
			this.Hide();
		}
	}
}

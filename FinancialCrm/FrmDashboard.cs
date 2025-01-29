﻿using FinancialCrm.Models;
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
	public partial class FrmDashboard : Form
	{
		public FrmDashboard()
		{
			InitializeComponent();
		}

		private void label5_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();
		int count = 0;
		private void FrmDashboard_Load(object sender, EventArgs e)
		{
			var value = db.Banks.Sum(x => x.BankBalance);
			lblTotalBalance.Text = value.ToString()+ " " + '₺';

			var value1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
			lblLastBankProcessAmount.Text = value1.Amount.ToString() + " " + '₺';

			// Chart 1 kodları

			var bankData = db.Banks.Select(x => new
			{
				x.BankTitle,
				x.BankBalance
			}).ToList();
			chart1.Series.Clear();
			var series = chart1.Series.Add("Series1");
			foreach (var item in bankData)
			{
				series.Points.AddXY(item.BankTitle, item.BankBalance);
			}

			// Chart 2 kodları

			var billData = db.Bills.Select(x => new
			{
				x.BillTitle,
				x.BillAmount
			}).ToList();
			chart2.Series.Clear();

			var series2 = chart2.Series.Add("Faturalar");
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Renko;
			foreach (var item in billData)
			{
				series2.Points.AddXY(item.BillTitle, item.BillAmount);
			}

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			count++;
			if(count % 4 == 1)
			{
				var values = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Elektrik Faturası";
				lblBillAmount.Text = values.ToString();
			}
			if (count % 4 == 2)
			{
				var values = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Doğalgaz Faturası";
				lblBillAmount.Text = values.ToString();
			}
			if (count % 4 == 3)
			{
				var values = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Su Faturası";
				lblBillAmount.Text = values.ToString();
			}
			if (count % 4 == 0)
			{
				var values = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
				lblBillTitle.Text = "Su Faturası";
				lblBillAmount.Text = values.ToString();
			}
		}
	}
}

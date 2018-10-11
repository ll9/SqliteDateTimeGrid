using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqliteDateTimeGrid
{
    public partial class Form1 : Form
    {
        private SqliteService SqliteService { get; } = new SqliteService("lds.sqlite", "lds_features");

        public Form1()
        {
            InitializeComponent();
            var dataTable = new DataTable();
            SqliteService.FillDataTable(dataTable);
            Debug.WriteLine(dataTable.Columns[1].DataType);
            dataGridView1.DataSource = dataTable;
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            SqliteService.Update(dataGridView1.DataSource as DataTable);
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            SqliteService.FillDataTable(dataGridView1.DataSource as DataTable);
        }
    }
}

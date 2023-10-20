using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bücherverwaltung_booksmanager
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable("table");
        int index;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("Title", Type.GetType("System.String"));
            table.Columns.Add("Autor", Type.GetType("System.String"));
            table.Columns.Add("Pages", Type.GetType("System.Int32"));
            table.Columns.Add("Preis", Type.GetType("System.Double"));

            dataGridView1.DataSource = table;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }

        private void datsGridView1_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            index=e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView1.Rows[index];
            newdata.Cells[0].Value = textBox1.Text;
            newdata.Cells[1].Value = textBox2.Text;
            newdata.Cells[2].Value = textBox3.Text;
            newdata.Cells[3].Value = textBox4.Text;
            newdata.Cells[4].Value = textBox5.Text;
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bücherverwaltung_booksmanager
{
    public partial class Form1 : Form
    {

        DataTable table = new DataTable("table");

        int index;
        int currentId = 0;

        public Form1()
        {
            InitializeComponent();
        }
        //_________________________________________________________

        private void Form1_Load(object sender, EventArgs e)
        {

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Autor", typeof(string));
            table.Columns.Add("Pages", typeof(int));
            table.Columns.Add("Preis", typeof(int));




            //"ID" column as primary key and enable AutoIncrement
            table.Columns["ID"].AutoIncrement = true;
            //table.Columns["ID"].AutoIncrementSeed = 1;
            table.Columns["ID"].AutoIncrementStep = 1;


            dataGridView1.DataSource = table;
            //dataGridView1.Columns["ID"].Visible = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            DataRow row = table.NewRow();

            string title = textBox2.Text;
            string autor = textBox3.Text;
            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(autor))
            {
                row["Title"] = title;
                row["Autor"] = autor;
                int pages, price;
                if (int.TryParse(textBox4.Text, out pages) && int.TryParse(textBox5.Text, out price))
                {
                    // Valid integer values for "Pages" and "Preis"
                    row["Pages"] = pages;
                    row["Preis"] = price;


                    table.Rows.Add(++currentId, row["Title"], row["Autor"], row["Pages"], row["Preis"]);

                    // Clear the input  after adding 
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Please provide a valid integer value for Pages and Preis.");
                }
            }
            else
            {
                MessageBox.Show("Please provide valid Title and Autor values.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();

        }
        private void bt_Edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[index];
            newDataRow.Cells[0].Value = textBox1.Text;
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = textBox3.Text;
            newDataRow.Cells[3].Value = textBox4.Text;
            newDataRow.Cells[4].Value = textBox5.Text;
   

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    if (selectedIndex >= 0)
                    {
                        dataGridView1.Rows.RemoveAt(selectedIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

   
    


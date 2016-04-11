using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace memory_allocator
{
    public partial class Form2 : Form
    {
        public int max_rows;
        public Form2()
        {
            InitializeComponent();
            dataGridView1.UserAddedRow += dgRowLimit_RowCountChange;
            dataGridView1.UserDeletedRow += dgRowLimit_RowCountChange;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            max_rows = Convert.ToInt32(Form1.holesNo);
            dataGridView1.RowCount = max_rows;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Hole Base Address";
            dataGridView1.Columns[1].Name = "Hole Size";
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 0 || dataGridView1.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.processfilled = true;
            for (int i = 0; i < max_rows; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) == "")
                    {
                        i = dataGridView1.RowCount;
                        MessageBox.Show("please fill all the data");
                        Form1.processfilled = false;
                        break;
                    }
                }
            }

            if (Form1.processfilled)
            {
                Form1.MyMemory.Clear();
                Form1.MyMemory_Allocated.Clear();

                for (int i = 0; i < max_rows; i++)
                {

                    Form1.MyMemory.AddLast(new memory());
                    Form1.MyMemory.ElementAt(i).BaseAddress = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    Form1.MyMemory.ElementAt(i).Size = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    
                    
                }


            }
        }
        private void dgRowLimit_RowCountChange(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount >= max_rows)
                dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        

      

    }
}

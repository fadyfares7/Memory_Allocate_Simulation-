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
    public partial class Form1 : Form
    {
        public static LinkedList<memory> MyMemory = new LinkedList<memory>();
        public static LinkedList<memory> MyMemory_Allocated = new LinkedList<memory>();
        public static Boolean processfilled;
        public static string holesNo;
        private string process_size;
        
        private int memory_Id = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            
          
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ReadOnly = true;
            First_fit_radioButton1.Checked = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

      

        private void NoOfHoles_TextChanged(object sender, EventArgs e)
        {
            holesNo = NoOfHoles.Text;
        }

        private void EnterHoles_Click(object sender, EventArgs e)
        {
            if (NoOfHoles.Text == "")
                MessageBox.Show("Please enter holes number");
            else if (NoOfHoles.Text == "0")
                MessageBox.Show("Please enter positive hole number");
            else
            {

                Form2 f2 = new Form2();
                f2.ShowDialog();
                drawHoles();
            }
        }

        private void AddProcess_Click(object sender, EventArgs e)
        {
            if (MemSize.Text == "")
            {
                MessageBox.Show("Please enter process size");
            }
            else if (MemSize.Text == "0")
                MessageBox.Show("Please enter positive process size");
            else
            {
                
                if (First_fit_radioButton1.Checked)
                {
                    First_Fit();
                }
                else if (Best_fit_radioButton2.Checked)
                {
                    best_Fit();
                }
                else if (Worst_fit_radioButton3.Checked)
                {
                    worst_Fit();
                }


            }
        }
        public void drawHoles()
        {
           
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Memory allocation " + memory_Id;
            MyMemory = new LinkedList<memory>(MyMemory.OrderBy(item => item.BaseAddress));
            //concatenation of holes
            for (int i = 0; i < MyMemory.Count(); i++)
            {
                for (int j = 0; j < MyMemory.Count()-1; j++)
                {
                    if ( MyMemory.ElementAt(j+1).BaseAddress <= MyMemory.ElementAt(j).BaseAddress + MyMemory.ElementAt(j).Size)
                    {
                        if (MyMemory.ElementAt(j + 1).BaseAddress + MyMemory.ElementAt(j + 1).Size <= MyMemory.ElementAt(j).BaseAddress + MyMemory.ElementAt(j).Size)
                            MyMemory.ElementAt(j).Size = MyMemory.ElementAt(j).Size;
                        else
                        MyMemory.ElementAt(j).Size = MyMemory.ElementAt(j+1).Size + MyMemory.ElementAt(j+1).BaseAddress - MyMemory.ElementAt(j).BaseAddress;
                        var current_node = MyMemory.ElementAt(j+1);
                        MyMemory.Remove(current_node);
                    }
                }
            }

            dataGridView1.RowCount = MyMemory.Count();

            MyMemory = new LinkedList<memory>(MyMemory.OrderBy(item => item.BaseAddress));
            for (int i = 0; i < MyMemory.Count(); i++)
            {
                MyMemory.ElementAt(i).name = "H" + i;
                dataGridView1.Rows[i].Cells[0].Value = MyMemory.ElementAt(i).name+"\n"+ "BA= "+MyMemory.ElementAt(i).BaseAddress + "\n"+"Size= " + MyMemory.ElementAt(i).Size;
                dataGridView1.Rows[i].Height =Convert.ToInt32((MyMemory.ElementAt(i).Size)*0.15+50);
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[i].Cells[0].Selected = false;
            }
            for (int i = 0; i < MyMemory.Count; i++)
            {
                memory m1 = new memory();
                   m1.name=MyMemory.ElementAt(i).name;
                   m1.Size = MyMemory.ElementAt(i).Size;
                   m1.BaseAddress = MyMemory.ElementAt(i).BaseAddress;
                   m1.IsProcess = MyMemory.ElementAt(i).IsProcess;
                MyMemory_Allocated.AddLast(m1);
            }
           
        }

        private void MemSize_TextChanged(object sender, EventArgs e)
        {
            process_size = MemSize.Text;
        }

        private void ClearMemory_Click(object sender, EventArgs e)
        {
            memory_Id = 0;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Memory allocation " + memory_Id;
            dataGridView1.RowCount = MyMemory.Count();
            for (int i = 0; i < MyMemory.Count(); i++)
            {
                MyMemory.ElementAt(i).name = "H" + i;
                dataGridView1.Rows[i].Cells[0].Value = MyMemory.ElementAt(i).name + "\n" + "BA= " + MyMemory.ElementAt(i).BaseAddress + "\n" + "Size= " + MyMemory.ElementAt(i).Size;
                dataGridView1.Rows[i].Height = Convert.ToInt32((MyMemory.ElementAt(i).Size) * 0.15 + 50);
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            MyMemory_Allocated.Clear();
            for (int i = 0; i < MyMemory.Count; i++)
            {
                memory m1 = new memory();
                m1.name = MyMemory.ElementAt(i).name;
                m1.Size = MyMemory.ElementAt(i).Size;
                m1.BaseAddress = MyMemory.ElementAt(i).BaseAddress;
                m1.IsProcess = MyMemory.ElementAt(i).IsProcess;
                MyMemory_Allocated.AddLast(m1);
            }
        }

        public void First_Fit()
        {
            for (int i = 0; i < MyMemory_Allocated.Count; i++)
            {
                LinkedListNode<memory> hole_node = MyMemory_Allocated.First;
                memory hole1 = MyMemory_Allocated.ElementAt(i);
                memory process = new memory();
                if (Convert.ToInt32(process_size) <= hole1.Size && hole1.IsProcess==false)
                {
                    process.name = "P" + memory_Id;
                    process.Size = Convert.ToInt32(process_size);
                    process.BaseAddress = hole1.BaseAddress;
                    process.IsProcess = true;
                    hole1.BaseAddress += Convert.ToInt32(process_size);
                    hole1.Size -= Convert.ToInt32(process_size);
                    MyMemory_Allocated.AddBefore(hole_node, process);
                    if (hole1.Size == 0)
                    {
                        MyMemory_Allocated.Remove(hole1);
                    }
                    draw_process();
                    
                    break;
                }
               
                hole_node = MyMemory_Allocated.First.Next;
               
            }

            
            
        }
        public void best_Fit()
        {
            MyMemory_Allocated = new LinkedList<memory>(MyMemory_Allocated.OrderBy(item => item.Size));
            for (int i = 0; i < MyMemory_Allocated.Count; i++)
            {

                LinkedListNode<memory> hole_node = MyMemory_Allocated.First;
                memory hole1 = MyMemory_Allocated.ElementAt(i);
                memory process = new memory();
                if (Convert.ToInt32(process_size) <= hole1.Size && hole1.IsProcess == false)
                {
                    process.name = "P" + memory_Id;
                    process.Size = Convert.ToInt32(process_size);
                    process.BaseAddress = hole1.BaseAddress;
                    process.IsProcess = true;
                    hole1.BaseAddress += Convert.ToInt32(process_size);
                    hole1.Size -= Convert.ToInt32(process_size);
                    MyMemory_Allocated.AddBefore(hole_node, process);
                    if (hole1.Size == 0)
                    {
                        MyMemory_Allocated.Remove(hole1);
                    }
                    draw_process();

                    break;
                }

                hole_node = MyMemory_Allocated.First.Next;

            }



        }
        public void worst_Fit()
        {
            MyMemory_Allocated = new LinkedList<memory>(MyMemory_Allocated.OrderByDescending(item => item.Size));
            for (int i = 0; i < MyMemory_Allocated.Count; i++)
            {

                LinkedListNode<memory> hole_node = MyMemory_Allocated.First;
                memory hole1 = MyMemory_Allocated.ElementAt(i);
                memory process = new memory();
                if (Convert.ToInt32(process_size) <= hole1.Size && hole1.IsProcess == false)
                {
                    process.name = "P" + memory_Id;
                    process.Size = Convert.ToInt32(process_size);
                    process.BaseAddress = hole1.BaseAddress;
                    process.IsProcess = true;
                    hole1.BaseAddress += Convert.ToInt32(process_size);
                    hole1.Size -= Convert.ToInt32(process_size);
                    MyMemory_Allocated.AddBefore(hole_node, process);
                    if (hole1.Size == 0)
                    {
                        MyMemory_Allocated.Remove(hole1);
                    }
                    draw_process();

                    break;
                }

                hole_node = MyMemory_Allocated.First.Next;

            }



        }
        public void draw_process()
        {
            memory_Id++;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Memory allocation " + memory_Id;
            dataGridView1.RowCount = MyMemory_Allocated.Count;
            MyMemory_Allocated = new LinkedList<memory>(MyMemory_Allocated.OrderBy(item => item.BaseAddress));
            for (int i = 0; i < MyMemory_Allocated.Count; i++)
            {
                if (MyMemory_Allocated.ElementAt(i).IsProcess == true)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;

                 dataGridView1.Rows[i].Cells[0].Value = MyMemory_Allocated.ElementAt(i).name + "\n" + "BA= " + MyMemory_Allocated.ElementAt(i).BaseAddress + "\n" + "Size= " + MyMemory_Allocated.ElementAt(i).Size;
                dataGridView1.Rows[i].Height = Convert.ToInt32((MyMemory_Allocated.ElementAt(i).Size) * 0.15 + 50);
                dataGridView1.Rows[i].Cells[0].Selected = false;
               
            }
            

        }
        private void dgvSomeDataGridView_SelectionChanged(Object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        
    }
}

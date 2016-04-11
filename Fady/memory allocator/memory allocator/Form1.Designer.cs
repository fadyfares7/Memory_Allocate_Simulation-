namespace memory_allocator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.MemSize = new System.Windows.Forms.TextBox();
            this.AddProcess = new System.Windows.Forms.Button();
            this.EnterHoles = new System.Windows.Forms.Button();
            this.ClearMemory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NoOfHoles = new System.Windows.Forms.TextBox();
            this.First_fit_radioButton1 = new System.Windows.Forms.RadioButton();
            this.Best_fit_radioButton2 = new System.Windows.Forms.RadioButton();
            this.Worst_fit_radioButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(399, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(208, 621);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter process memory size";
            // 
            // MemSize
            // 
            this.MemSize.Location = new System.Drawing.Point(153, 127);
            this.MemSize.Name = "MemSize";
            this.MemSize.Size = new System.Drawing.Size(100, 20);
            this.MemSize.TabIndex = 3;
            this.MemSize.TextChanged += new System.EventHandler(this.MemSize_TextChanged);
            this.MemSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // AddProcess
            // 
            this.AddProcess.Location = new System.Drawing.Point(291, 127);
            this.AddProcess.Name = "AddProcess";
            this.AddProcess.Size = new System.Drawing.Size(80, 23);
            this.AddProcess.TabIndex = 4;
            this.AddProcess.Text = "Add process";
            this.AddProcess.UseVisualStyleBackColor = true;
            this.AddProcess.Click += new System.EventHandler(this.AddProcess_Click);
            // 
            // EnterHoles
            // 
            this.EnterHoles.Location = new System.Drawing.Point(226, 24);
            this.EnterHoles.Name = "EnterHoles";
            this.EnterHoles.Size = new System.Drawing.Size(105, 23);
            this.EnterHoles.TabIndex = 5;
            this.EnterHoles.Text = "Enter Holes";
            this.EnterHoles.UseVisualStyleBackColor = true;
            this.EnterHoles.Click += new System.EventHandler(this.EnterHoles_Click);
            // 
            // ClearMemory
            // 
            this.ClearMemory.Location = new System.Drawing.Point(153, 225);
            this.ClearMemory.Name = "ClearMemory";
            this.ClearMemory.Size = new System.Drawing.Size(103, 55);
            this.ClearMemory.TabIndex = 6;
            this.ClearMemory.Text = "Clear memory";
            this.ClearMemory.UseVisualStyleBackColor = true;
            this.ClearMemory.Click += new System.EventHandler(this.ClearMemory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "No. of holes";
            // 
            // NoOfHoles
            // 
            this.NoOfHoles.Location = new System.Drawing.Point(101, 24);
            this.NoOfHoles.Name = "NoOfHoles";
            this.NoOfHoles.Size = new System.Drawing.Size(100, 20);
            this.NoOfHoles.TabIndex = 7;
            this.NoOfHoles.TextChanged += new System.EventHandler(this.NoOfHoles_TextChanged);
            this.NoOfHoles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // First_fit_radioButton1
            // 
            this.First_fit_radioButton1.AutoSize = true;
            this.First_fit_radioButton1.Location = new System.Drawing.Point(118, 78);
            this.First_fit_radioButton1.Name = "First_fit_radioButton1";
            this.First_fit_radioButton1.Size = new System.Drawing.Size(61, 17);
            this.First_fit_radioButton1.TabIndex = 8;
            this.First_fit_radioButton1.TabStop = true;
            this.First_fit_radioButton1.Text = "First Fit";
            this.First_fit_radioButton1.UseVisualStyleBackColor = true;
            // 
            // Best_fit_radioButton2
            // 
            this.Best_fit_radioButton2.AutoSize = true;
            this.Best_fit_radioButton2.Location = new System.Drawing.Point(211, 78);
            this.Best_fit_radioButton2.Name = "Best_fit_radioButton2";
            this.Best_fit_radioButton2.Size = new System.Drawing.Size(61, 17);
            this.Best_fit_radioButton2.TabIndex = 9;
            this.Best_fit_radioButton2.TabStop = true;
            this.Best_fit_radioButton2.Text = "Best Fit";
            this.Best_fit_radioButton2.UseVisualStyleBackColor = true;
            // 
            // Worst_fit_radioButton3
            // 
            this.Worst_fit_radioButton3.AutoSize = true;
            this.Worst_fit_radioButton3.Location = new System.Drawing.Point(300, 77);
            this.Worst_fit_radioButton3.Name = "Worst_fit_radioButton3";
            this.Worst_fit_radioButton3.Size = new System.Drawing.Size(69, 17);
            this.Worst_fit_radioButton3.TabIndex = 10;
            this.Worst_fit_radioButton3.TabStop = true;
            this.Worst_fit_radioButton3.Text = "Worst Fit";
            this.Worst_fit_radioButton3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Allocation type :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 633);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Worst_fit_radioButton3);
            this.Controls.Add(this.Best_fit_radioButton2);
            this.Controls.Add(this.First_fit_radioButton1);
            this.Controls.Add(this.NoOfHoles);
            this.Controls.Add(this.ClearMemory);
            this.Controls.Add(this.EnterHoles);
            this.Controls.Add(this.AddProcess);
            this.Controls.Add(this.MemSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MemSize;
        private System.Windows.Forms.Button AddProcess;
        private System.Windows.Forms.Button EnterHoles;
        private System.Windows.Forms.Button ClearMemory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NoOfHoles;
        private System.Windows.Forms.RadioButton First_fit_radioButton1;
        private System.Windows.Forms.RadioButton Best_fit_radioButton2;
        private System.Windows.Forms.RadioButton Worst_fit_radioButton3;
        private System.Windows.Forms.Label label1;
    }
}


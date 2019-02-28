namespace AutoComplete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.list_result = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.QuickSort = new System.Windows.Forms.RadioButton();
            this.MergeSort = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.BubbleSort = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // list_result
            // 
            this.list_result.FormattingEnabled = true;
            this.list_result.Location = new System.Drawing.Point(173, 251);
            this.list_result.Name = "list_result";
            this.list_result.Size = new System.Drawing.Size(415, 238);
            this.list_result.TabIndex = 3;
            this.list_result.SelectedIndexChanged += new System.EventHandler(this.list_result_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose Your Preferable Sorting Algorithm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // QuickSort
            // 
            this.QuickSort.AutoSize = true;
            this.QuickSort.Font = new System.Drawing.Font("Elephant", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickSort.Location = new System.Drawing.Point(425, 96);
            this.QuickSort.Name = "QuickSort";
            this.QuickSort.Size = new System.Drawing.Size(86, 18);
            this.QuickSort.TabIndex = 7;
            this.QuickSort.TabStop = true;
            this.QuickSort.Text = "Quick Sort";
            this.QuickSort.UseVisualStyleBackColor = true;
            this.QuickSort.CheckedChanged += new System.EventHandler(this.QuickSort_CheckedChanged);
            // 
            // MergeSort
            // 
            this.MergeSort.AutoSize = true;
            this.MergeSort.Font = new System.Drawing.Font("Elephant", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MergeSort.Location = new System.Drawing.Point(425, 119);
            this.MergeSort.Name = "MergeSort";
            this.MergeSort.Size = new System.Drawing.Size(88, 18);
            this.MergeSort.TabIndex = 8;
            this.MergeSort.TabStop = true;
            this.MergeSort.Text = "Merge Sort";
            this.MergeSort.UseVisualStyleBackColor = true;
            this.MergeSort.CheckedChanged += new System.EventHandler(this.MergeSort_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(173, 203);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(415, 29);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // BubbleSort
            // 
            this.BubbleSort.AutoSize = true;
            this.BubbleSort.Font = new System.Drawing.Font("Elephant", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BubbleSort.Location = new System.Drawing.Point(425, 143);
            this.BubbleSort.Name = "BubbleSort";
            this.BubbleSort.Size = new System.Drawing.Size(93, 18);
            this.BubbleSort.TabIndex = 10;
            this.BubbleSort.TabStop = true;
            this.BubbleSort.Text = "Bubble Sort";
            this.BubbleSort.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ravie", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enter here :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(700, 582);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BubbleSort);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.MergeSort);
            this.Controls.Add(this.QuickSort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_result);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "AutocompleteMe !";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton QuickSort;
        private System.Windows.Forms.RadioButton MergeSort;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton BubbleSort;
        private System.Windows.Forms.Label label2;
    }
}


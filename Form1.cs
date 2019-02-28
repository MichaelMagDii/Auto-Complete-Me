using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace AutoComplete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class AutoCompelete
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Class1.loadweightsfile();
            Class1.loaddictionaryfile();
             Class1.loaddic();
        }

        // CheckKeyword de function 3shan ta3'yar al color bta3 al wrong word na gaybha ml net ma3rafsh feha 7aga
        // bs hya btasht3'al 3la 7aga asmha rich textbox msh textbox 3ady w ma3rfsh a al far2 bs hwa sha3'al tmam :D
        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
        }
    
        void Form1_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            AutoCompelete f = new AutoCompelete();

            string text = richTextBox1.Text.ToString();

            #region "Wrong word"

            if (text.Length > 1 && text[text.Length - 1] == ' ')
            {
                string[] txt = richTextBox1.Text.Split(' ');

                for (int i = 0; i < txt.Length; i++)
                {
                    string word = txt[i];
                    if (word.Length > 1)
                    {
                        if (!Class1.IsCorrect(word))
                        {
                            this.CheckKeyword(word, Color.Red, 0);

                            Class1.getsuggestion(word);
                            List<Tuple<int, string>> ls = Class1.nearwords;

                            
                            var Item2Result = ls.Select(item => item.Item2).ToArray();
                            list_result.DataSource = Item2Result;
                            
                            MessageBox.Show("\n\n");
                        }
                        else
                        {
                            this.CheckKeyword(word, Color.Black, 0);
                        }

                    }
                }
            }
            #endregion

            #region "if the user enter right word"
            List<Tuple<int, string>> result = Class1.getresults(text);
            
            if (QuickSort.Checked)
            {
                int n = Class1.get_length(result);
               List<Tuple<int, string>> sort = Class1.quicksort(result, 0,n-1);
                var Item2Result = sort.Select(item => item.Item2).ToArray();
                list_result.DataSource = Item2Result;
            }
            else if (MergeSort.Checked)
            {
                List<Tuple<int, string>> sort = Class1.mergesort(result);
                var Item2Result = sort.Select(item => item.Item2).ToArray();
                list_result.DataSource = Item2Result;
            }
            else if(BubbleSort.Checked)
            {
                List<Tuple<int, string>> sort = Class1.bubblesort(result);
                var Item2Result = sort.Select(item => item.Item2).ToArray();
                list_result.DataSource = Item2Result;
            }
            #endregion
          
            if (text == string.Empty)
            {
                list_result.DataSource = null;
            }

        }

        #region" Sorting Algorithm "

        private void QuickSort_CheckedChanged(object sender, EventArgs e)
        {
            List<Tuple<int, string>> result = Class1.getresults(richTextBox1.Text.ToString());
        
            int n = Class1.get_length(result);
           List<Tuple<int, string>> sort = Class1.quicksort(result, 0, n-1);
            var Item2Result = sort.Select(item => item.Item2).ToArray();
            list_result.DataSource = Item2Result;
        }

        private void MergeSort_CheckedChanged(object sender, EventArgs e)
        {
            List<Tuple<int, string>> result = Class1.getresults(richTextBox1.Text.ToString());
            
            List<Tuple<int, string>> sort = Class1.mergesort(result);
            var Item2Result = sort.Select(item => item.Item2).ToArray();
            list_result.DataSource = Item2Result;
         
        }

        private void BubbleSort_CheckedChanged(object sender, EventArgs e)
        {
            List<Tuple<int, string>> result = Class1.getresults(richTextBox1.Text.ToString());

            List<Tuple<int, string>> sort = Class1.bubblesort(result);
            var Item2Result = sort.Select(item => item.Item2).ToArray();
            list_result.DataSource = Item2Result;
         
        }

        #endregion

        private void list_result_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

            




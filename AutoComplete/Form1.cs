using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //---------------------------------------------------------------------------------------------------------------------
            // Load the txt file into list of pairs
            public static List<Tuple<int, string>> loadfile()
            {
                List<Tuple<int, string>> myfile = new List<Tuple<int, string>>();

                string[] filea = File.ReadAllLines("Search Links (Scenario 1 & 2).txt");

                foreach (var s in filea)
                {
                    string[] parts = s.Split(',');
                    Tuple<int, string> test = new Tuple<int, string>(int.Parse(parts[0]), parts[1]);
                    myfile.Add(test);
                }
                return myfile;
            }
            //---------------------------------------------------------------------------------------------------------------------
            // make a list of the written sentence "Ge" // badl el Ge de ana 3yza ya5od el fel textbox
            public static List<Tuple<int, string>> getresults(string search, List<Tuple<int, string>> myfile)
            {
                List<Tuple<int, string>> result = new List<Tuple<int, string>>();

                int len = search.Length;

                for (int i = 0; i < myfile.Count; i++)
                {
                    if (myfile[i].Item2.Length >= len) //to prevent exception when making substring
                    {
                        string s = myfile[i].Item2.Substring(0, len);

                        if (s == search)
                        {
                            Tuple<int, string> test = new Tuple<int, string>(myfile[i].Item1, myfile[i].Item2);
                            result.Add(test);
                        }
                    }
                }
                return result;
            }

        }


        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            //AutoCompelete f = new AutoCompelete();

            //string text = txt_search.Text.ToString();

            //List<Tuple<int, string>> myfile = AutoCompelete.loadfile();
            //List<Tuple<int, string>> result = AutoCompelete.getresults("G", myfile);


            //string[] arr = new string[1000];

            this.txt_search.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //TextBox t = sender as TextBox;


            //for (int i = 0; i < myfile.Count; i++)
            //{
            //    arr[i] = myfile[i].Item2;
            //}


            //AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            //collection.AddRange(arr);

            //this.txt_search.AutoCompleteCustomSource = collection;



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoCompelete f = new AutoCompelete();

            string text = txt_search.Text.ToString();

            List<Tuple<int, string>> myfile = AutoCompelete.loadfile();
            List<Tuple<int, string>> result = AutoCompelete.getresults(text, myfile);

            string[] arr = new string[1000];
            //this.txt_search.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //this.txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;

            for (int i = 0; i < myfile.Count; i++)
            {
                arr[i] = myfile[i].Item2;
            }


            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(arr);

            this.txt_search.AutoCompleteCustomSource = collection;
            
        }
    }
}

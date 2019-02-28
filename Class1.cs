using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutoComplete
{
    class Class1
    {
        public static int mid;
        public static List<string> dic = new List<string>(); 
        public static SortedDictionary<char, List<Tuple<int, string>>> myweightsfile = new SortedDictionary<char, List<Tuple<int, string>>>();
        public static SortedDictionary<char, List<string>> dictionaryfile = new SortedDictionary<char, List<string>>();
        public static List<Tuple<int, string>> nearwords = new List<Tuple<int, string>>();
       // public static List<List<Tuple<int, string>>> correctresult = new List<List<Tuple<int, string>>>();

        public static int get_length(List<Tuple<int, string>> myfile)
        {
            int X;
            return X = myfile.Count;
        }

      
        #region  "Prefix Search"

        // make a list of the written sentence "Ge"
        // Load the txt file into list of Tuples

        public static void loadweightsfile()
        {
            myweightsfile.Clear();

            string[] filea = File.ReadAllLines("Search Links (Scenario 1 & 2).txt");

            foreach (var s in filea)
            {
                string[] parts = s.Split(',');
                Tuple<int, string> test = new Tuple<int, string>(int.Parse(parts[0]), parts[1]);



                if (!myweightsfile.ContainsKey(parts[1][0]))
                {
                    List<Tuple<int, string>> test2 = new List<Tuple<int, string>>();
                    test2.Add(test);
                    myweightsfile[parts[1][0]] = test2;
                }
                else
                {
                    myweightsfile[parts[1][0]].Add(test);
                }
            }
        }


        public static List<Tuple<int, string>> getresults(string search)
        {
            List<Tuple<int, string>> result = new List<Tuple<int, string>>();

            if (search.Length < 1)
                return result;

            string letter = search[0].ToString().ToUpper();

            if (!myweightsfile.ContainsKey(letter[0]))
            {
                return result;
            }

            int length = search.Length;

            int count = myweightsfile[letter[0]].Count;


            for (int i = 0; i < count; i++)
            {
                if (myweightsfile[letter[0]][i].Item2.Length >= length)
                {
                    string s = myweightsfile[letter[0]][i].Item2.Substring(0, length);
                    if (s.ToUpper() == search.ToUpper())
                    {
                        Tuple<int, string> test = new Tuple<int, string>(myweightsfile[letter[0]][i].Item1, myweightsfile[letter[0]][i].Item2);
                        result.Add(test);
                    }
                }
            }
            return result;
        }

    
        #endregion

        #region "Load dictionary and checking if word is right"

        public static void loaddictionaryfile()
        {
            dictionaryfile.Clear();
            string line ;

            StreamReader file = new StreamReader("dictionary.txt");
            while ((line = file.ReadLine()) != null)
            {
                int n;
                if (!int.TryParse(line , out n))
                {
                    line = line.ToLower();
                    if (!dictionaryfile.ContainsKey(line[0]))
                    {
                        List<string> test = new List<string>();
                        test.Add(line);
                        dictionaryfile[line[0]] = test;
                    }
                    else
                    {
                        dictionaryfile[line[0]].Add(line);
                    }
                }
                
            }
            
        }

        // Check if the written word is correct
        public static bool IsCorrect(string text)
        {
            
            string letter = text[0].ToString().ToLower();
            if (!dictionaryfile.ContainsKey(letter[0]))
            {
                return false;
            }

            int count = dictionaryfile[letter[0]].Count;
            for (int i = 0; i < count; i++)
            {
                if (dictionaryfile[letter[0]][i].ToLower() == text.ToLower())
                {
                    return true;
                }
            }
            return false;
         }

        
        #endregion

        #region "Suggestions of wrong word"

        // load dictionary file in list of string to find the correction of the wrong
        public static void loaddic()
        {
            dic.Clear();
            string line;

            StreamReader file = new StreamReader("dictionary.txt");
            while ((line = file.ReadLine()) != null)
            {
                int n;
                if (!int.TryParse(line, out n))
                {
                    line = line.ToLower();

                    List<string> test = new List<string>();
                    dic.Add(line);

                }

            }

        }

        public static void getsuggestion(string wrongword)
        {
            dic.Sort();
            int length = dic.Count;
            for(int i = 0 ; i < length ; i++)
            {
                string word = dic[i];
                Edit_Distance(word, wrongword);
            }
           // suggestion_words(nearwords);
        }
        public static void Edit_Distance(string word, string wrongword)
        {
            int target = word.Length;
            int wrong = wrongword.Length;
            int[,] d = new int[target + 1, wrong + 1];

            // Step 1
            if (target == 0)
            {
                Tuple<int, string> test = new Tuple<int, string>(wrong, word);
                nearwords.Add(test);
                return;
            }

            if (wrong == 0)
            {
                Tuple<int, string> test = new Tuple<int, string>(target, word);
                nearwords.Add(test);
                return;
            }

            // Step 2
            for (int i = 0; i <= target; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= wrong; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= target; i++)
            {
                //Step 4
                for (int j = 1; j <= wrong; j++)
                {
                    // Step 5
                    int cost = (wrongword[j - 1] == word[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                                                d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            if (d[target, wrong] <= 20 || d[target, wrong] < wrong)
            {
                Tuple<int, string> tmp = new Tuple<int, string>(d[target, wrong], word);

                nearwords.Add(tmp);

            }
            // return d[n, m];
        }
        //public static void suggestion_words(List<Tuple<int, string>> nearwords)
        //{
        //    nearwords.Sort();
        //    string test = nearwords[0].Item2;
        //    getresults(test);

        //    //for(int i = 0 ; i < nearwords.Count ; i++)
        //    //{
        //    //    string test = nearwords[i].Item2;
        //    //    List<Tuple<int, string>> t= getresults(test);
        //    //    correctresult.Add(t);
        //    //}
        //    //correctresult.Sort();
            
        //}


        #endregion


        #region" MergeSort "
        public static List<Tuple<int, string>> mergesort(List<Tuple<int, string>> myfile)
        {

            int len = myfile.Count;

            List<Tuple<int, string>> left = new List<Tuple<int, string>>();
            List<Tuple<int, string>> right = new List<Tuple<int, string>>();

            if (len < 2)
                return myfile;
            else
            {
                if (len % 2 == 0)
                {
                    mid = len / 2;
                }
                else
                {
                    mid = (len + 1) / 2;
                }


                for (int i = 0; i < mid; i++)
                {
                    left.Add(myfile[i]);
                }
                for (int i = mid; i <= len - 1; i++)
                {
                    right.Add(myfile[i]);
                }

                left = mergesort(left);
                right = mergesort(right);
                return merge(left, right);
            }

        }

        public static List<Tuple<int, string>> merge(List<Tuple<int, string>> left, List<Tuple<int, string>> right)
        {
            List<Tuple<int, string>> sortedresult = new List<Tuple<int, string>>();

            int llen = left.Count;
            int rlen = right.Count;

            int i = 0, j = 0;
            while (i < llen && j < rlen)
            {
                if (left[i].Item1 >= right[j].Item1)
                {
                    sortedresult.Add(left[i]);
                    i++;
                }
                else
                {
                    sortedresult.Add(right[j]);
                    j++;
                }
            }
            while (i < llen)
            {
                sortedresult.Add(left[i]);
                i++;
            }
            while (j < rlen)
            {
                sortedresult.Add(right[j]);
                j++;
            }
            return sortedresult;
        }
#endregion 
        #region "bubble sort"
        public static List<Tuple<int, string>> bubblesort(List<Tuple<int, string>> myfile)
        {
            int len = myfile.Count;
             for(int i =0;i<len;i++)
             {
                 for( int  j=0;j<len-i-1;j++)
                 {
                     if(myfile[j].Item1<myfile[j+1].Item1)
                     {
                         
                     Tuple<int , string> temp = myfile[j];
                         myfile[j]= myfile[j+1];
                         myfile[j+1] = temp;
                     }
                     
                  
                 }
             }
                return myfile;
            
        }

#endregion 
        #region "quick sort "
        public static int Partition(List<Tuple<int, string>> myfile, int low, int high)
            {

                int pivot = myfile[high].Item1;
                int pindex = low;
                for (int i= low; i <=high; i++)
                {
                    if (myfile[i].Item1 > pivot)
                    {
                       
                        Tuple<int , string > val = myfile[i];
                        myfile[i] = myfile[pindex];
                        myfile[pindex] = val;
                        ++pindex;
                    }
                }
                    Tuple<int , string > tmp = myfile[pindex];
                    myfile[pindex]=myfile[high];
                    myfile[high] = tmp;
               
                return pindex;
            }
  public static List<Tuple<int, string>> quicksort(List<Tuple<int, string>> myfile, int low, int high)
  { 
      if(low < high)
      {
          int pi = Partition(myfile, low, high);
          quicksort(myfile, low, pi-1);
          quicksort(myfile, pi+1, high);
      }
      return myfile;
  }
   
            #endregion
       
    }// class

}// namespace 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IT111_MP
{
    class Records
    {
        private const string filename = "Record.txt";
        protected List<string> sorted = new List<string>();
        protected string[] currP = new string[17];

        
        private void CreateFile()
        {
            StreamWriter file = new StreamWriter(filename, true);
            file.Close();
        }

        private List<string> Readfile()
        {
            try
            {
                StreamReader file = new StreamReader(filename);

                List<string> data = new List<string>();

                while (file.ReadLine() is string content)
                {
                    if (content != "")
                    {
                        data.Add(content);
                    }

                }
                file.Close();

                return data;
            }

            catch
            {
                CreateFile();
                StreamReader file = new StreamReader(filename);

                List<string> data = new List<string>();

                while (file.ReadLine() is string content)
                {
                    if (content != "")
                    {
                        data.Add(content);
                    }

                }
                file.Close();

                return data;
            }
            
        }


        private void AddToFile()
        {
            //converts currP into string
            string newdata = string.Join("|", currP);

            //reads txt file and stores it in list
            List<string> existing = Readfile(); 

            for(int i = 0; i< existing.Count(); i++)
            {
                string[] v = existing[i].Split('|');

                //if name is equal, existing data is replaced by newdata
                if(v[0] == currP[0])
                {
                    existing[i] = newdata;
                }
            }

            //overrides the txtfile with updated list
            StreamWriter file = new StreamWriter(filename);
            
            foreach(string i in existing)
            {
                file.WriteLine(i);
            }
            file.Close();
        }



        protected void AddTo_currP(string data, int index)
        {
            if (currP[index] != null)
            {
                string[] v1 = currP[index].Split(':');
                string[] v2 = data.Split(':');

                if (int.Parse(v1[0]) <= int.Parse(v2[0]) && int.Parse(v1[1]) < int.Parse(v2[1]))
                {
                    currP[index] = data;
                    currP[16] = $"{index}";
                }
            }
            else
            {
                currP[index] = data;
                currP[16] = $"{index}";
            }

            AddToFile();
        }



        protected void LoadPLayer()
        {
            List<string> exisitng = Readfile();
            int counter = 0;

            //checks if player exist in file
            for (int i = 0; i < exisitng.Count(); i++)
            {
                string[] v = exisitng[i].Split('|');

                //if exist, it adds player record to currP
                if (v[0] == currP[0])
                {
                    for (int x = 1; x < v.Count(); x++)
                    {
                        if(v[x] != "")
                        {
                            currP[x] = v[x];
                        }
                    }
                    counter++;
                    break;
                }
            }

            //adds player in file if player is new
            if (exisitng.Count() == 0 || counter == 0)
            {
                StreamWriter file = new StreamWriter(filename, true);
                file.WriteLine(string.Join("|", currP));
                file.Close();
            }
        }



        protected void GetTopTen()
        {
            sorted.Clear();
            List<string> unsorted = new List<string>();
            List<string> existing = Readfile();
            
            foreach(string i in existing)
            {
                string[] v = i.Split('|');
                int count = 0;

                foreach(string x in v)
                {
                    if(x != "")
                    {
                        count++;
                    }
                }

                if(count == 17)
                {
                    string name = v[0];
                    TimeSpan sum_time = SumTime(i);
                    unsorted.Add($"{name}|{sum_time}");
                } 
            }

            
            while (unsorted.Count() != 0)
            {
                string[] lowest = unsorted[0].Split('|');
                TimeSpan l_time = ConvertToTime(lowest[1]);

                foreach (string i in unsorted)
                {
                    string[] num = i.Split('|');
                    TimeSpan n_time = ConvertToTime(num[1]);

                    if (n_time < l_time)
                    {
                        lowest = num;
                        l_time = n_time;
                    }
                }

                sorted.Add($"{lowest[0]}|{l_time}");
                unsorted.Remove($"{lowest[0]}|{lowest[1]}");
            }
        }







        private TimeSpan SumTime(string data)
        {
            string[] player = data.Split('|');
            TimeSpan sum_time = new TimeSpan();

            int minLimit = 5;

            for (int i = 1; i <= 15; i++)
            {
                if (i == 7) { minLimit = 3; }
                if (i == 13) { minLimit = 2; }

                TimeSpan min_sec = ConvertToTime(player[i], minLimit);
                sum_time += min_sec;
            }

            return sum_time;
        }
        private TimeSpan ConvertToTime(string data, int limit)
        {
            string[] time = data.Split(':');

            int min = int.Parse(time[0]);
            int sec = int.Parse(time[1]);


            TimeSpan newTime = new TimeSpan(0, 0, min, sec);
            TimeSpan newLimit = new TimeSpan(0, 0, limit, 0);
            TimeSpan final = newLimit - newTime;

            return final;
        }


        private TimeSpan ConvertToTime(string data)
        {
            string[] time = data.Split(':');

            int min = int.Parse(time[1]);
            int sec = int.Parse(time[2]);
            
            TimeSpan newTime = new TimeSpan(0, 0, min, sec);
            return newTime;
        }

        


        protected void ClearTop()
        {
            List<string> existing = Readfile();
            List<string> newdata = new List<string>();
            List<string> names = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                if(sorted.Count() > i)
                {
                    string[] v = sorted[i].Split('|');
                    names.Add(v[0]);
                }
                
            }

            foreach (string i in existing)
            {
                string[] v = i.Split('|');
                if (names.Contains(v[0]) == false)
                {
                    newdata.Add(i);
                }
            }


            sorted.Clear();

            StreamWriter file = new StreamWriter(filename);

            foreach (string i in newdata)
            {
                file.WriteLine(i);
            }
            file.Close();

        }
    }
}

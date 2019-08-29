using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Log_CLI
{
    class Piece
    {
        private string artist;
        private string title;
        //private List<string> daystopractice = new List<string>();
        
        public string Artist { get; set; }
        public string Title { get; set; }
        public List<string> DaysToPractice { get; set; }
       
        public Piece(string artist, string title)
        {
            this.Artist = artist;
            this.Title = title;
            this.DaysToPractice = new List<string>();
        }

        public void addDays(string day)
        {
            if(DaysToPractice.Count > 7)
            {
                Console.WriteLine("All Days are filled!");
            }
            else if(DaysToPractice.Contains(day))
            {
                Console.WriteLine("{0} day is already filled.", day);
            }
            else
            {
                DaysToPractice.Add(day.ToString());
            }
        }

        public void DeleteDay(int dayChoice)
        {
            if(DaysToPractice.Count < 1)
            {
                Console.WriteLine("No days to delete");
            }
            else
            {
                DaysToPractice.RemoveAt(dayChoice);
            }
        }

        public void viewDays()
        {
            Console.WriteLine("---Scheduled Days to Practice---");
            if(DaysToPractice.Count < 1)
            {
                Console.WriteLine("No Scheduled Days");
            }
            else
            {
                foreach (string day in DaysToPractice)
                {
                    Console.WriteLine(day);
                }
            }

            Console.WriteLine("--------------");
        }


    }
}

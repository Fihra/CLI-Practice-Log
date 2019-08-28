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
        private string[] daysToPractice = new string[7];
        
        public string Artist { get; set; }
        public string Title { get; set; }
        public List<string> DaysToPractice { get; set; }
       
        public Piece(string artist, string title, List<string> daysToPractice = null)
        {
            this.Artist = artist;
            this.Title = title;
            this.DaysToPractice = daysToPractice;
        }

        public void addDays(Enum day)
        {
            if(DaysToPractice.Count > 7)
            {
                Console.WriteLine("All Days are filled!");
            }
            else
            {
                DaysToPractice.Add(day.ToString());
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Log_CLI
{
    class Musician
    {
        private string name;
        private string instrument;
        List<Piece> allSongs = new List<Piece>();

        public string Name { get; set; }
        public string Instrument { get; set; }
        public List<Piece> Songs { get { return allSongs; } set {allSongs = value; } }

        public Musician(string name, string instrument)
        {
            this.Name = name;
            this.Instrument = instrument;
        }

        public void showSongs()
        {
            foreach(Piece song in this.Songs)
            {
                Console.WriteLine("{0}: {1}", song.Artist, song.Title);
            }
        }

    }
}

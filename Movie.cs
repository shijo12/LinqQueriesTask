using System.Collections.Generic;

namespace LinqExamples
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Cast { get; set; }
        public List<string> Genres { get; set; }
    }
}
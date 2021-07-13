using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace LinqExamples
{
    public class JsonLoadMovies
    {
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (StreamReader reader = new StreamReader("movies.json"))
            {
                string json = reader.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            

            return movies;
        }
    }
}
using System;
using System.Diagnostics;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var pagination = 100;
            FetchMovieData movieData = new FetchMovieData();
            try
            {
                while (true)
                {
                    Console.WriteLine($"Enter your choice:" +
                    "\n1.Get movies by release date" +
                    "\n2.List all movies in descending" +
                    "\n3.List movies by year in range" +
                    "\n4.Search movie" +
                    "\n5.Search by cast" +
                    "\n6.Set Pagination");
                    var option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine($"Enter a Year");
                            int year = Convert.ToInt32(Console.ReadLine());
                            movieData.GetMoviesByYear(year, pagination);
                            break;

                        case 2:
                            movieData.ListAllMovies(pagination);
                            break;

                        case 3:
                            Console.WriteLine($"From year:");
                            int yearFrom = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"till year:");
                            int yearTo = Convert.ToInt32(Console.ReadLine());
                            movieData.ListMovieByYearRange(yearFrom, yearTo, pagination);
                            break;

                        case 4:
                            Console.WriteLine($"Enter the movie title");
                            var title = Console.ReadLine();
                            movieData.SearchMovie(title, pagination);
                            break;

                        case 5:
                            Console.WriteLine($"Enter the name");
                            var name = Console.ReadLine();
                            movieData.GetMoviesByCast(name, pagination);
                            break;
                            

                        case 6:
                            Console.WriteLine($"Enter the limit of movies to show");
                            pagination = Convert.ToInt32(Console.ReadLine());
                            break;

                        default:
                            Console.WriteLine($"unknown format");
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                // TODO
                Console.WriteLine($"Something unexpected occurred.{ex}");
            }

        }
    }
}

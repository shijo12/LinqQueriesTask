using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LinqExamples
{
    public class FetchMovieData : IFetchMovieData
    {
        JsonLoadMovies jsonData = new JsonLoadMovies();
        
        public void GetMoviesByCast(string name, int pagination)
        {
            var movies = jsonData.GetMovies();
            var count = 0;

            var result = 
            movies
            .Where(m => m.Cast.Any(x => x.ToLower()
            .StartsWith(name.ToLower())));

            var enumerable = result.ToList();
            foreach (var movie in enumerable)
            {
                count++;
                Console.WriteLine($"\n\nTitle:\t{movie.Title}" +
                $"\nYear:\t{movie.Year}");

                Console.Write($"Cast:");
                foreach (var item in movie.Cast)
                {
                    Console.WriteLine($"\t{item}");
                }

                Console.WriteLine($"genre:");
                foreach (var item in movie.Genres)
                {
                    Console.WriteLine($"\t{item}");
                }

                if (count == pagination) break;
            }
            Console.WriteLine($"\nTotal Results: {enumerable.Select(m => m.Title).Count()}");
            Console.WriteLine($"Current pagintaion: {pagination}");
        }

        public void GetMoviesByYear(int year, int pagination)
        {
            var movies = jsonData.GetMovies();
            var count = 0;

            var moviesFiltered = movies.Where(m => m.Year == year);

            var enumerable = moviesFiltered.ToList();
            foreach (var movie in enumerable)
            {
                count++;
                Console.WriteLine($"\n{movie.Title}");
                if (count == pagination) break;
            }
            Console.WriteLine($"\nTotal Results: {enumerable.Select(m => m.Title).Count()}");
            Console.WriteLine($"Current pagination: {pagination}");
        }

        public void ListAllMovies(int pagination)
        {
            var movies = jsonData.GetMovies();

            var moviesByDescending = movies.OrderByDescending(y => y.Year).ToList();
            var count = 0;

            foreach (var movie in moviesByDescending)
            {
                count++;
                Console.WriteLine($"\n\nTitle:\t{movie.Title}" +
                $"\nYear:\t{movie.Year}");

                Console.Write($"Cast:");
                foreach (var item in movie.Cast)
                {
                    Console.WriteLine($"\t{item}");
                }

                Console.WriteLine($"genre:");
                foreach (var item in movie.Genres)
                {
                    Console.WriteLine($"\t{item}");
                }

                if (count == pagination) break;
            }
            Console.WriteLine($"\nTotal Results: {moviesByDescending.Select(m => m.Title).Count()}");
            Console.WriteLine($"Current pagintaion: {pagination}");
        }

        public void ListMovieByYearRange(int year1, int year2, int pagination)
        {
            var movies = jsonData.GetMovies();

            var result = 
            movies
            .Where(m => m.Year >= year1 && m.Year <= year2)
            .OrderByDescending(y => y.Year)
            .ToList();

            var count = 0;

            foreach (var movie in result)
            {
                count++;
                Console.WriteLine($"{movie.Title}");
                if (count == pagination) break;
            }
            Console.WriteLine($"\nTotal Results: {result.Select(m => m.Title).Count()}");
            Console.WriteLine($"Current pagintaion: {pagination}");
        }

        public void SearchMovie(string movieTitle, int pagination)
        {
            var movies = jsonData.GetMovies();

            // var result = movies.Where(m => m.Title == movieTitle);
            var result = 
            movies
            .FindAll(m => m.Title.ToLower()
            .StartsWith(movieTitle.ToLower()))
            .OrderByDescending(y => y.Year)
            .ToList();
            
            var count = 0;

            foreach (var movie in result)
            {
                count++;
                Console.WriteLine($"\n\nTitle:\t{movie.Title}" +
                $"\nYear:\t{movie.Year}");

                Console.Write($"Cast:");
                foreach (var item in movie.Cast)
                {
                    Console.WriteLine($"\t{item}");
                }

                Console.WriteLine($"genre:");
                foreach (var item in movie.Genres)
                {
                    Console.WriteLine($"\t{item}");
                }

                if (count == pagination) break;
            }
            Console.WriteLine($"\nTotal Results: {result.Select(m => m.Title).Count()}");
            Console.WriteLine($"Current pagination: {pagination}");
        }
    }
}
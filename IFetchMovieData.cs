namespace LinqExamples
{
    public interface IFetchMovieData
    {
        void GetMoviesByYear(int year, int pagination);
        void ListAllMovies(int pagination);
        void ListMovieByYearRange(int year1, int year2, int pagination);
        void SearchMovie(string movie, int pagination);
        void GetMoviesByCast(string name, int pagination);
    }
}
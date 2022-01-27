namespace Application.Movie.Queries
{
    public class GetMovieSearchFilter
    {
        public int Page { get; }

        public string Query { get; }

        public GetMovieSearchFilter(string query, int page)
        {
            Query = query;
            Page = page;
        }
    }
}

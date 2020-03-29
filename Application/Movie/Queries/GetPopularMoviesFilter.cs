using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Application.Movie.Queries
{
    public class GetPopularMoviesFilter
    {
        public int Page { get; }
        public int Take { get; }
        public Collection<int> Ids { get; }

        public GetPopularMoviesFilter(int page)
        {
            Page = page;
        }
    }
}

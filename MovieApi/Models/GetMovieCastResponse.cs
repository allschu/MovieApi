using MovieApi.Models.ViewModels;
using System.Collections.Generic;

namespace MovieApi.Models
{
    public class GetMovieCastResponse
    {
        public int Id { get; }
        public ICollection<CastViewModel> Cast { get; }

        public GetMovieCastResponse(int id, ICollection<CastViewModel> cast)
        {
            Id = id;
            Cast = cast;
        }
    }
}

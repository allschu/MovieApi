using MovieApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

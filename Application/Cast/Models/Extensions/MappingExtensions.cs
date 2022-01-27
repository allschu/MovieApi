using Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Application.Cast.Models.Extensions
{
    public static class MappingExtensions
    {
        internal static ICollection<CastViewModel> MapToViewModel(this CastResultSelection resultCastSelection)
        {
            return resultCastSelection.Cast.Select(x => new CastViewModel
            {
                Int = x.Id,
                Character = x.Character,
                Name = x.Name,
                Order = x.Order,
                Profile_Path    = x.Profile_Path
            }).ToList();
        }
    }
}

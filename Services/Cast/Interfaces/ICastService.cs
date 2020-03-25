using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Cast.Interfaces
{
    public interface ICastService
    {
        public Task<CastResultSelection> GetMoviesCredits(int movieId);
    }
}

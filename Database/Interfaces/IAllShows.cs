using System.Collections.Generic;
using System.Threading.Tasks;
using NetflixGraphQL.Models;

namespace NetflixGraphQL.Database.Interfaces
{
    public interface IAllShows
    {
        Task<List<MovieModel>> GetAllShows();
    }
}

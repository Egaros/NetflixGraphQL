using System.Collections.Generic;
using System.Threading.Tasks;
using NetflixGraphQL.Models;

namespace NetflixGraphQL.Database.Interfaces
{
    public interface IAllShows
    {
        Task<List<MovieModel>> GetAllShows();
        Task<IEnumerable<MovieModel>> GetActionShows();
        Task<IEnumerable<MovieModel>> GetComedyShows();
        Task<IEnumerable<MovieModel>> GetComingSoonShows();
        Task<List<MovieModel>> SearchForShows(string title);

    }
}

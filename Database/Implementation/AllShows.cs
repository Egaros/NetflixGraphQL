using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NetflixGraphQL.Database.Interfaces;
using NetflixGraphQL.Models;

namespace NetflixGraphQL.Database.DatabaseQuery.Implementation
{
    public class AllShows : IAllShows
    {
        private static MongoClient client = new MongoClient(DatabaseConstants.DatabasePath);
        private IMongoQueryable<MovieModel> dbQuery = client.GetDatabase("Movies").GetCollection<MovieModel>("Movies").AsQueryable();

        public async Task<List<MovieModel>> GetAllShows() => await client.GetDatabase("Movies").GetCollection<MovieModel>("Movies").AsQueryable().ToListAsync();

        //public async Task<List<MovieModel>> GetActionShows()
        //{
        //    MongoDB.Driver.Linq.IMongoQueryable<MovieModel> xd = client.GetDatabase("Movies").GetCollection<MovieModel>("Movies").AsQueryable();
        //}

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NetflixGraphQL.Database.Interfaces;
using NetflixGraphQL.Models;

namespace NetflixGraphQL.Database.Implementation
{
    public class AllShows : IAllShows
    {
        private static MongoClient client = new MongoClient(DatabaseConstants.DatabasePath);
        private IMongoQueryable<MovieModel> dbQuery = client.GetDatabase("Movies").GetCollection<MovieModel>("Movies").AsQueryable();
        private static Random rnd = new Random();

        public async Task<IEnumerable<MovieModel>> GetAllShows() => await dbQuery.ToListAsync();

        public async Task<MovieModel> GetFeaturedShow()
        {
            var query = await dbQuery.ToListAsync();
            return query.Where(x => x.IsFeatured).ElementAt(rnd.Next(query.Count));
        }

        public async Task<IEnumerable<MovieModel>> GetActionShows()
        {
            var query = await dbQuery.ToListAsync();
            return query.Where(x => x.IsAction);
        }

        public async Task<IEnumerable<MovieModel>> GetComedyShows()
        {
            var query = await dbQuery.ToListAsync();
            return query.Where(x => x.IsComedy);
        }

        public async Task<IEnumerable<MovieModel>> GetComingSoonShows()
        {
            var query = await dbQuery.ToListAsync();
            return query.Where(x => x.IsComingSoon);
        }

        public async Task<IEnumerable<MovieModel>> GetPopularShows()
        {
            var query = await dbQuery.ToListAsync();
            return query.Where(x => x.IsPopular);
        }

        public async Task<IEnumerable<MovieModel>> SearchForShows(string title)
        {
            var db = client.GetDatabase("Movies").GetCollection<MovieModel>("Movies");

            var filter = Builders<MovieModel>.Filter.Regex("title", new BsonRegularExpression(title, "i"));
            var response = await (await db.FindAsync<MovieModel>(filter)).ToListAsync();
            return response;
        }

        public async Task<MovieModel> SearchForSingleShows(string title)
        {
            var db = client.GetDatabase("Movies").GetCollection<MovieModel>("Movies");

            var filter = Builders<MovieModel>.Filter.Eq("title", title);
            var response = await (await db.FindAsync(filter)).FirstOrDefaultAsync();
            return response;
        }

    }
}

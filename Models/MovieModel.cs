using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetflixGraphQL.Models
{
    public class MovieModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("thumbnail")]
        public string Thumbnail { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("genre")]
        public string[] Genre { get; set; }

        [BsonElement("featured")]
        public bool IsFeatured { get; set; }

        [BsonElement("synopsis")]
        public string Synopsis { get; set; }

        [BsonElement("popular")]
        public bool IsPopular { get; set; }

        [BsonElement("action")]
        public bool IsAction { get; set; }

        [BsonElement("comedy")]
        public bool IsComedy { get; set; }

        [BsonElement("casts")]
        public string Casts { get; set; }

        [BsonElement("year")]
        public string Year { get; set; }

        [BsonElement("rating")]
        public double Rating { get; set; }

        [BsonElement("infoThumbnail")]
        public string InfoThumbnail { get; set; }

        [BsonElement("comingSoon")]
        public bool IsComingSoon { get; set; }
    }
}

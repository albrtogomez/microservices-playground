using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MovieCatalog.API.Model;

public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Title { get; set; } = null!;

    public int Year { get; set; }
}

using MongoDB.Bson;
using MongoDB.Driver;
using MovieCatalog.API.Model;

namespace MovieCatalog.API.Data;

public static class MovieCatalogSeed
{
    public static void SeedInitialData(IMongoCollection<Movie> movieCollection)
    {
        movieCollection.InsertManyAsync(new List<Movie>()
        {
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Interstellar",
                Year = 2014
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Inception",
                Year = 2010
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Tenet",
                Year = 2020
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Memento",
                Year = 2000
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "The Dark Night",
                Year = 2008
            }
        });
    }
}

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
                Year = 2014,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Inception",
                Year = 2010,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Tenet",
                Year = 2020,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BYzg0NGM2NjAtNmIxOC00MDJmLTg5ZmYtYzM0MTE4NWE2NzlhXkEyXkFqcGdeQXVyMTA4NjE0NjEy._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "The Prestige",
                Year = 2006,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BMjA4NDI0MTIxNF5BMl5BanBnXkFtZTYwNTM0MzY2._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "The Dark Night",
                Year = 2008,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Batman Begins",
                Year = 2005,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BOTY4YjI2N2MtYmFlMC00ZjcyLTg3YjEtMDQyM2ZjYzQ5YWFkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "The Dark Knight Rises",
                Year = 2012,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Dunkirk",
                Year = 2017,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BN2YyZjQ0NTEtNzU5MS00NGZkLTg0MTEtYzJmMWY3MWRhZjM2XkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Memento",
                Year = 2000,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BZTcyNjk1MjgtOWI3Mi00YzQwLWI5MTktMzY4ZmI2NDAyNzYzXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Insomnio",
                Year = 2002,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BYzlkZTEyYjUtMTY5NS00ZjU0LTk5OTYtM2M0ZDg1NmNjMzhkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Following",
                Year = 1998,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BNDVhYTAyMDgtM2NhNS00MmQ3LWE0ZDMtNWIxMjlhODFmOWUwXkEyXkFqcGdeQXVyMTA5NjIyODcx._V1_SX300.jpg",
                Price = 4.99m
            },
            new Movie()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = "Oppenheimer",
                Year = 2023,
                PosterUrl="https://m.media-amazon.com/images/M/MV5BMDI5ZTVmMmMtZjg1Ny00NzNkLWFkMDctZDlmMzQ4MDcyODZlXkEyXkFqcGdeQXVyMzM1NDY1MDE@._V1_SX300.jpg",
                Price = 4.99m
            }
        });
    }
}

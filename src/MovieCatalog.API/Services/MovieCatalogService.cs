using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieCatalog.API.Model;

namespace MovieCatalog.API.Services;

public class MovieCatalogService
{
    private readonly IMongoCollection<Movie> _movieCollection;

	public MovieCatalogService(IOptions<MovieCatalogDatabaseSettings> dbSettings)
	{
		var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

		var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

		_movieCollection = mongoDatabase.GetCollection<Movie>(dbSettings.Value.MoviesCollectionName);

        bool anyMovies = _movieCollection.Find(_ => true).Any();

        if (!anyMovies)
            MovieCatalogSeed.SeedInitialData(_movieCollection);
	}

    public async Task<List<Movie>> GetAsync() =>
        await _movieCollection.Find(_ => true).ToListAsync();

    public async Task<Movie?> GetAsync(string id) =>
        await _movieCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Movie newMovie) =>
        await _movieCollection.InsertOneAsync(newMovie);

    public async Task<ReplaceOneResult> UpdateAsync(string id, Movie updatedMovie) =>
        await _movieCollection.ReplaceOneAsync(x => x.Id == id, updatedMovie);

    public async Task<DeleteResult> RemoveAsync(string id) =>
        await _movieCollection.DeleteOneAsync(x => x.Id == id);
}

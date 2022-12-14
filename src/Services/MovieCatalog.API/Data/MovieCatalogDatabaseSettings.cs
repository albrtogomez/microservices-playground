namespace MovieCatalog.API.Data;

public class MovieCatalogDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string MoviesCollectionName { get; set; } = null!;
}

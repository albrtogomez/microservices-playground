namespace BlazorWebApp.Model;

public class MovieDto
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int Year { get; set; }

    public string PosterUrl { get; set; } = null!;

    public decimal Price { get; set; }
}

namespace Movie.Management.Domain.ModelDto;

public class MoviePaginatedDto
{
    public int Count { get; set; }
    public List<MovieDto> Items { get; set; }
}

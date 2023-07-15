namespace Movie.Management.Api.ViewModel;

public class MovieResponsePaginatedViewModel
{
    public int Count { get; set; }
    public List<MovieResponseViewModel> Items { get; set; }
}

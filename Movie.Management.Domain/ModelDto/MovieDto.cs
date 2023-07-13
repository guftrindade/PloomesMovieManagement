namespace Movie.Management.Domain.ModelDto
{
    public class MovieDto
    {
        public Guid Id { get; set; }    
        public string Title { get; set; }
        public string DirectedBy { get; set; }
        public int Year { get; set; }
    }
}

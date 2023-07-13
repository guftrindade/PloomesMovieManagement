namespace Movie.Management.Infra.Models
{
    public class Movies
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string DirectedBy { get; set; }

        public int Year { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

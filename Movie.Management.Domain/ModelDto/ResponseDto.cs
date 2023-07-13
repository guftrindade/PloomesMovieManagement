namespace Movie.Management.Domain.ModelDto
{
    public class ResponseDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string DirectedBy { get; set; }

        public string Year { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

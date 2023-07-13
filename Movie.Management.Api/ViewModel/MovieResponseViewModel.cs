namespace Movie.Management.Api.ViewModel
{
    public class MovieResponseViewModel
    {
        /// <summary>
        /// Unique Identification Number
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Movie Title
        /// </summary>
        /// <example>Transformers</example>
        public string Title { get; set; }

        /// <summary>
        /// Movie Director
        /// </summary>
        /// <example>Michael Bay</example>
        public string DirectedBy { get; set; }

        /// <summary>
        /// Released Year
        /// </summary>
        /// <example>2007</example>
        public int Year { get; set; }

        /// <summary>
        /// Created data in database
        /// </summary>
        /// <example>2023-07-13 12:21:00</example>
        public DateTime CreatedDate { get; set; }
    }
}

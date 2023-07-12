using System.ComponentModel.DataAnnotations;

namespace Movie.Management.Api.ModelsDto
{
    public class ResponseDto
    {
        /// <summary>
        /// Movie Title
        /// </summary>
        /// <example>Transformers</example>
        [Required]
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
        [Required]
        public string Year { get; set; }

        /// <summary>
        /// Movie Created Date
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}

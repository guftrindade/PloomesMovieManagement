using System.ComponentModel.DataAnnotations;

namespace Movie.Management.Api.ViewModel
{
    public class MovieRequestViewModel
    {
        /// <summary>
        /// Movie Title\
        /// Título do Filme
        /// </summary>
        /// <example>Transformers</example>
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// Movie Director\
        /// Diretor do filme
        /// </summary>
        /// <example>Michael Bay</example>
        [MaxLength(255)]
        public string DirectedBy { get; set; }

        /// <summary>
        /// Released Year (YYYY format)\
        /// Ano de lançamento (formato YYYY)
        /// </summary>
        /// <example>2007</example>
        [Required]
        [RegularExpression(@"^\d{4,4}?", ErrorMessage = "[Year] property must be in 'YYYY' format.")]
        public int Year { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Movie.Management.Api.ModelsDto
{
    public class MovieRequestViewModel
    {
        /// <summary>
        /// Movie Title\
        /// Título do Filme
        /// </summary>
        /// <example>Transformers</example>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Movie Director\
        /// Diretor do filme
        /// </summary>
        /// <example>Michael Bay</example>
        public string DirectedBy { get; set; }

        /// <summary>
        /// Released Year (YYYY format)\
        /// Ano de lançamento (formato YYYY)
        /// </summary>
        /// <example>2007</example>
        [Required]
        public int Year { get; set; }
    }
}

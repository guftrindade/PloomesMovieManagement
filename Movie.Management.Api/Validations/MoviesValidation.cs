using FluentValidation;
using Movie.Management.Api.ModelsDto;

namespace Movie.Management.Api.Validations
{
    public class MoviesValidation : AbstractValidator<MovieRequestViewModel>
    {
        public MoviesValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("Title Obrigatorio!");

            RuleFor(x => x.Year)
                .NotNull()
                .WithMessage("Year obrigatorio!");
        }
    }
}

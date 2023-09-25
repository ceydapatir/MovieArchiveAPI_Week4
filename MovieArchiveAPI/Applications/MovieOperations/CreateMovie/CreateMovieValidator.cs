using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieArchiveAPI.Data.Context;
using FluentValidation;

namespace MovieArchiveAPI.Applications.MovieOperations.CreateMovie
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
    {
        // Data check rules for POST method
        public CreateMovieValidator(MovieArchiveDBContext context){
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.PublishDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(i => i.Model.ImageURL).NotNull();
            RuleFor(i => i.Model.IMDB).NotEmpty().GreaterThan(0).LessThanOrEqualTo(10);
        }
    }
}
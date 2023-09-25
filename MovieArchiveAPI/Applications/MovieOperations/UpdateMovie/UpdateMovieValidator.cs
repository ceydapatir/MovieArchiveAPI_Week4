using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieArchiveAPI.Data.Context;
using FluentValidation;

namespace MovieArchiveAPI.Applications.MovieOperations.UpdateMovie
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
    {
        // Data check rules for PUT method
        public UpdateMovieValidator(MovieArchiveDBContext context){
            RuleFor(i => i.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.PublishDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(i => i.Model.ImageURL).NotNull();
            RuleFor(i => i.Model.IMDB).NotEmpty().GreaterThan(0).LessThanOrEqualTo(10);
        }
    }
}
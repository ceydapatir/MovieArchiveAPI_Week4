using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.MovieOperations.GetMovieById
{
    public class GetMovieByIdValidator : AbstractValidator<GetMovieByIdQuery>
    {
        // Data check rules for GET method
        public GetMovieByIdValidator(){
            RuleFor(i => i.MovieId).NotEmpty().GreaterThan(0);
        }
    }
}
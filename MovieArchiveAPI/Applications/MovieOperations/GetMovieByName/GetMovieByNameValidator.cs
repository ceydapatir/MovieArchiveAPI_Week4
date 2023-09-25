using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.MovieOperations.GetMovieByName
{
    public class GetMovieByNameValidator : AbstractValidator<GetMovieByNameQuery>
    {
        // Data check rules for GET method
        public GetMovieByNameValidator(){
            RuleFor(i => i.MovieName).NotNull();
        }
    }
}
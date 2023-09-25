using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.MovieOperations.GetMoviesByYear
{
    public class GetMoviesByYearValidator : AbstractValidator<GetMoviesByYearQuery>
    {
        // Data check rules for GET method
        public GetMoviesByYearValidator(){
            RuleFor(i => i.MovieYear).NotEmpty().GreaterThan(0);
        }
    }
}
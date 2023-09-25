using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.GenreOperations.GetGenreById
{
    public class GetGenreByIdValidator : AbstractValidator<GetGenreByIdQuery>
    {
        // Data check rules for GET method
        public GetGenreByIdValidator(){
            RuleFor(i => i.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
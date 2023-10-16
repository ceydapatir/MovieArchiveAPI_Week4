using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.GenreOperations.GetGenreByName
{
    public class GetGenreByNameValidator : AbstractValidator<GetGenreByNameQuery>
    {
        // Data check rules for GET method
        public GetGenreByNameValidator(){
            RuleFor(i => i.GenreName).NotNull();
        }
    }
}
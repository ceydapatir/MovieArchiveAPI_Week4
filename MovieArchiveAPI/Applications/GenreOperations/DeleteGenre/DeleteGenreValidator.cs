using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.GenreOperations.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
    {
        // Data check rules for DELETE method
        public DeleteGenreValidator(){
            RuleFor(i => i.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
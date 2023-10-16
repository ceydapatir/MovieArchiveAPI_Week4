using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.GenreOperations.UpdateGenre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {
        // Data check rules for PUT method
        public UpdateGenreValidator(){
            RuleFor(i => i.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.IsActive).NotNull();
        }
    }
}
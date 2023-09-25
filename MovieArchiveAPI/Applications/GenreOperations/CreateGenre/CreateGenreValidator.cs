using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.GenreOperations.CreateGenre
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        // Data check rules for POST method
        public CreateGenreValidator(){
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.IsActive).NotNull();
        }
    }
}
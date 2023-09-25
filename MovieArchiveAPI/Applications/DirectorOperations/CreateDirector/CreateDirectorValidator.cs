using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.DirectorOperations.CreateDirector
{
    public class CreateDirectorValidator : AbstractValidator<CreateDirectorCommand>
    {
        // Data check rules for POST method
        public CreateDirectorValidator(){
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.Surname).NotNull();
            RuleFor(i => i.Model.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date.AddYears(-18));
        }
    }
}
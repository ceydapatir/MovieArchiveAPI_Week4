using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorValidator : AbstractValidator<DeleteDirectorCommand>
    {
        // Data check rules for DELETE method
        public DeleteDirectorValidator(){
            RuleFor(i => i.DirectorId).NotEmpty().GreaterThan(0);
        }
    }
}
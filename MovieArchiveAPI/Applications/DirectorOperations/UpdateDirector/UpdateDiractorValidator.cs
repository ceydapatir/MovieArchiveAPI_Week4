using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.DirectorOperations.UpdateDirector
{
    public class UpdateDiractorValidator : AbstractValidator<UpdateDiractorCommand>
    {
        // Data check rules for PUT method
        public UpdateDiractorValidator(){
            RuleFor(i => i.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.Surname).NotNull();
            RuleFor(i => i.Model.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date.AddYears(-18));  
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.DirectorOperations.GetDirectorByName
{
    public class GetDirectorByNameValidator : AbstractValidator<GetDirectorByNameQuery>
    {
        // Data check rules for GET method
        public GetDirectorByNameValidator(){
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.Surname).NotNull();
        }
    }
}
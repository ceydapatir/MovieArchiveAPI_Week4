using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieArchiveAPI.Applications.DirectorOperations.GetDirectorById
{
    public class GetDirectorByIdValidator : AbstractValidator<GetDirectorByIdQuery>
    {
        // Data check rules for GET method
        public GetDirectorByIdValidator(){
            RuleFor(i => i.DirectorId).NotEmpty().GreaterThan(0);
        }
    }
}
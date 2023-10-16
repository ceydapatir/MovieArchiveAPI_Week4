using FluentValidation;

namespace MovieArchiveAPI.Applications.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorValidator : AbstractValidator<UpdateDirectorCommand>
    {
        // Data check rules for PUT method
        public UpdateDirectorValidator(){
            RuleFor(i => i.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.Surname).NotNull();
            RuleFor(i => i.Model.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date.AddYears(-18));  
        }
    }
}
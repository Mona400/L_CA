using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentServices _studentServices;
        public EditStudentValidator(IStudentServices studentServices)
        {
            ApplyValidationRules();
            ApplyCustomValdationRules();
            _studentServices = studentServices;
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must Not Be Empty")
                .NotNull().WithMessage("Name Must Not Be Null")
                .MaximumLength(100).WithMessage("Max Length is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
                .NotNull().WithMessage("{PropertyName} Must Not Be Null")
                .MaximumLength(100).WithMessage("{PropertyName} Length Is 10");
        }
        public void ApplyCustomValdationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentServices.IsNameExistExecuteSelf(Key, model.Id))
                .WithMessage("Name Is Exist");

        }
    }
}

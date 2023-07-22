using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.Students.Commands.Models;
using School.Core.Resources;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentServices _studentServices;
        private readonly IStringLocalizer<SharedResourses> _Localizer;
        public AddStudentValidator(IStudentServices studentServices, IStringLocalizer<SharedResourses> localizer)
        {
            _studentServices = studentServices;
            _Localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValdationRules();

        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_Localizer[SharedResoursesKeys.NotEmpty])
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
                .MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameExist(Key))
                .WithMessage("Name Is Exist");

        }
    }
}

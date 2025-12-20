using FluentValidation;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    public class CompanyFloorValidator : AbstractValidator<CompanyFloor>
    {

    public CompanyFloorValidator()
        {
            RuleFor(f => f.FloorName)
                .NotEmpty().WithMessage("Floor name is required")
                .MaximumLength(100).WithMessage("Floor name cannot exceed 100 characters");

            RuleFor(f => f.Map)
                .NotEmpty().WithMessage("Layout JSON is required")
                .Must(BeValidJson).WithMessage("LayoutJson must be valid JSON");

            RuleFor(f => f.FloorNumber)
                .GreaterThan(0).WithMessage("Floor number must be positive");
        }

        private bool BeValidJson(string json)
        {
            try
            {
                System.Text.Json.JsonDocument.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

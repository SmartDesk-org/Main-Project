using FluentValidation;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    public class CompanyMeetingRoomValidator : AbstractValidator<CompanyMeetingRoom>
    {
        public CompanyMeetingRoomValidator()
        {
            RuleFor(x => x.RoomName)
                .NotEmpty()
                .WithMessage("Meeting room name is required")
                .MaximumLength(100)
                .WithMessage("Meeting room name cannot exceed 100 characters");

            RuleFor(x => x.CompanyId)
                .GreaterThan(0)
                .WithMessage("CompanyId is required");

            RuleFor(x => x.FloorId)
                .GreaterThan(0)
                .WithMessage("FloorId is required");

            RuleFor(x => x.Capacity)
                .GreaterThan(0)
                .When(x => x.Capacity.HasValue)
                .WithMessage("Capacity must be greater than zero");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid meeting room status");

            RuleFor(x => x.XPosition)
                .GreaterThanOrEqualTo(0)
                .WithMessage("X position cannot be negative");

            RuleFor(x => x.YPosition)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Y position cannot be negative");

            RuleFor(x => x.SpecificationsJson)
                .NotNull()
                .WithMessage("SpecificationsJson cannot be null");
        }
    
    }
}

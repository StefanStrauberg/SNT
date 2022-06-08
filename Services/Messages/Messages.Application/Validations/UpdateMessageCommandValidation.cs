using FluentValidation;
using Messages.Application.Features.Requests.Commands;

namespace Messages.Application.Validations
{
    public class UpdateMessageCommandValidation : AbstractValidator<UpdateMessageCommand>
    {
        public UpdateMessageCommandValidation()
        {
            RuleFor(x => x.id)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.Body)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(250).WithMessage("{PropertyName} must be less than {MaxLength} characters.");
            RuleFor(x => x.model.Receiver)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.Recipient)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
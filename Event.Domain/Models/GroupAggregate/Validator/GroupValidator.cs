using FluentValidation;

namespace Event.Domain.Models.GroupAggregate.Validator
{
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 100);
            RuleFor(x => x.Description).NotEmpty().Length(100, 4000);
            RuleFor(x => x.ThumbnailImagePath).NotEmpty().MaximumLength(200);
            RuleFor(x => x.LocationId).NotNull();
        }
    }
}

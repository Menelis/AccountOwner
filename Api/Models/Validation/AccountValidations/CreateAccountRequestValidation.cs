using Api.Models.Requests.AccountRequests;
using FluentValidation;

namespace Api.Models.Validation.AccountValidations
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAccountRequestValidation : AbstractValidator<CreateAccountRequest>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAccountRequestValidation()
        {
            RuleFor(_ => _.AccountTypeId).NotEmpty().WithMessage("Required");
            RuleFor(_ => _.CustomerId).NotEmpty().WithMessage("Required");
            RuleFor(_ => _.DepositAmount).NotEmpty().WithMessage("Required");
        }
    }
}
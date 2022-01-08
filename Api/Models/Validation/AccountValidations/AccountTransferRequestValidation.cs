using Api.Models.Requests.AccountRequests;
using FluentValidation;

namespace Api.Models.Validation.AccountValidations
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountTransferRequestValidation : AbstractValidator<AccountTranferRequest>
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountTransferRequestValidation()
        {
            RuleFor(_ => _.SourceAccountNumber).NotEmpty().WithMessage("Required")
                                               .MaximumLength(36).WithMessage("Only 36 characters allowed for Source Account Number");
            RuleFor(_ => _.DestinationAccountNumber).NotEmpty().WithMessage("Required")
                                                    .MaximumLength(36).WithMessage("Only 36 characters allowed for Destination Account Number");
            RuleFor(_ => _.Amount).NotEmpty().WithMessage("Required");
        }
    }
}
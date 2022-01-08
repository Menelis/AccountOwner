using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.AccountResponses
{
    public class AccountTransferResponse : UseCaseResponseMessage
    {
        public AccountTransferResponse(bool success = false, string message = null) : base(success, message){}
    }
}
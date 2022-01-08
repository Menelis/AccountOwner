using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.CustomerResponses
{
    public class CreateOrUpdateCustomerResponse : UseCaseResponseMessage
    {
        public CreateOrUpdateCustomerResponse(bool success = false, string message = null) : base(success, message){}
    }
}
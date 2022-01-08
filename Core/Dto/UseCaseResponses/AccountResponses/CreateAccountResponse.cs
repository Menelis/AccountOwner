using System;
using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.AccountResponses
{
    public class CreateAccountResponse : UseCaseResponseMessage
    {
        public int Id { get; }

        public CreateAccountResponse(int id, bool success = true, string message = null) : base(success, message)
        {
            Id = id;
        }
        public CreateAccountResponse(bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
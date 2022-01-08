using System.Net;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Api.Presenters.AccountPresenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AccountTransferPresenter : IOutputPort<AccountTransferResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public AccountTransferPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(AccountTransferResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response);
        }
    }
}
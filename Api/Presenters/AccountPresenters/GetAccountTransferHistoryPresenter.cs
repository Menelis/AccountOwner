using System.Net;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Api.Presenters.AccountPresenters
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAccountTransferHistoryPresenter : IOutputPort<GetAccountTransferHistoryResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get;}
        /// <summary>
        /// 
        /// </summary>
        public GetAccountTransferHistoryPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetAccountTransferHistoryResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response.Success ? response.Entities : response.Message);
        }
    }
}
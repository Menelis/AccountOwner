using System.Net;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Api.Presenters.AccountPresenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAllAccountsPresenter : IOutputPort<GetAllAccountsResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// ////
        /// </summary>
        public GetAllAccountsPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetAllAccountsResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response.Success ? response.Entities : response.Message);
        }
    }
}
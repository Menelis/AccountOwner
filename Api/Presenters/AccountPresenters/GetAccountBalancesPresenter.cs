using System.Net;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Api.Presenters.AccountPresenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAccountBalancesPresenter : IOutputPort<GetAccountBalancesResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public GetAccountBalancesPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetAccountBalancesResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response.Success ? response.Entity : response.Message);
        }
    }
}
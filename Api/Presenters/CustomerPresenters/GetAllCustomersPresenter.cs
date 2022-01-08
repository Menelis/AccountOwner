using System.Net;
using Core.Dto.UseCaseResponses.CustomerResponses;
using Core.Interfaces;

namespace Api.Presenters.CustomerPresenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAllCustomersPresenter : IOutputPort<GetAllCustomersResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public GetAllCustomersPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetAllCustomersResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response.Success ? response.Entities : response.Message);
        }
    }
}
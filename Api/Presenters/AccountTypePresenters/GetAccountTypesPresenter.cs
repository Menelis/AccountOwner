using System.Net;
using Core.Dto.UseCaseResponses.AccountTypeResponses;
using Core.Interfaces;

namespace Api.Presenters.AccountTypePresenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAccountTypesPresenter : IOutputPort<GetAllAccountTypesResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public GetAccountTypesPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetAllAccountTypesResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response.Success ? response.Entities : response.Message);
        }
    }
} 
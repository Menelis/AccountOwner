using System.Net;
using Core.Dto.UseCaseResponses.TransactionTypeResponses;
using Core.Interfaces;

namespace Api.Presenters.TransactionTypePresenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAllTransactionTypesPresenter : IOutputPort<GetAllTransactionTypesResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public GetAllTransactionTypesPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(GetAllTransactionTypesResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response.Success ? response.Entities : response.Message);
        }
    }
}
using System.Net;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Api.Presenters.AccountPresenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CreateAccountPresenter : IOutputPort<CreateAccountResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// 
        /// </summary>
        public CreateAccountPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public void Handle(CreateAccountResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = Serialization.JsonSerializer.SerializeObject(response);
        }
    }
}
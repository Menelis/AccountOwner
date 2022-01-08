using System.Threading.Tasks;

namespace Core.Interfaces
{
     /// <summary>
    /// Interface responsible for handling requests and responses
    /// </summary>
    /// <typeparam name="TUseCaseRequest">Input Request</typeparam>
    /// <typeparam name="TUseCaseResponse">Output Response</typeparam>
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse>
        where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }
}
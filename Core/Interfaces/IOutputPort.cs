namespace Core.Interfaces
{
    /// <summary>
    /// Interface responsible for output from requests
    /// </summary>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);         
    }
}
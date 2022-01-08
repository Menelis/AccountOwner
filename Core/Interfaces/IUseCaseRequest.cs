namespace Core.Interfaces
{
    /// <summary>
    /// Every use Case Request will be sent here and the output will be expected after process
    /// </summary>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IUseCaseRequest<out TUseCaseResponse> {}
}
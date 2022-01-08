using System.Collections.Generic;

namespace Core.Dto
{
    public interface ITEntityResponse<T>
    {
        T Entity { get; }
    }
    public interface ITEntitiesResponse<T>
    {
        IEnumerable<T> Entities { get; }
    }
}
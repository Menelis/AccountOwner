using Core.Entities.Base;

namespace Core.Entities
{
    public class TransactionType : NameEntity
    {
        public TransactionType(){}
        public TransactionType(string name, int id)
        {
            Name = name;
            Id = id;
        }     
    }
}
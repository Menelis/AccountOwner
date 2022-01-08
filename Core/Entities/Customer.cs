using Core.Entities.Base;

namespace Core.Entities
{
    public class Customer: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(){}
        public Customer(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
    }
}
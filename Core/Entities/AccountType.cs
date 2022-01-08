using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class AccountType : NameEntity
    {
        public AccountType(){}
        public AccountType(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
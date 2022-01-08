using System;
using System.Text.Json.Serialization;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Account : BaseEntity
    {
        public int AccountTypeId { get; set;}
        [JsonIgnore]
        public AccountType AccountType { get; set;}
        public int CustomerId { get; set;}
        [JsonIgnore]
        public Customer Customer { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public decimal  Balance { get; set; }
        public string AccountNumber { get; set; }
    }
}
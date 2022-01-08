using System;
using System.Text.Json.Serialization;
using Core.Entities.Base;

namespace Core.Entities
{
    public class AccountTransaction : NameEntity
    { 
        public int AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        public int TransactionTypeId { get; set; }
        [JsonIgnore]
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
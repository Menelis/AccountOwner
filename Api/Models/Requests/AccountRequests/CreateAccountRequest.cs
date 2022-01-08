namespace Api.Models.Requests.AccountRequests
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAccountRequest 
    {
        /// <summary>
        /// Account Type Id
        /// </summary>
        /// <value></value>
        public int AccountTypeId { get; set;}
        /// <summary>
        /// Customer Id
        /// </summary>
        /// <value></value>
        public int CustomerId { get; set;}
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public decimal DepositAmount { get; set;}
    }
}
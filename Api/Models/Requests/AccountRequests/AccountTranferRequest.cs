namespace Api.Models.Requests.AccountRequests
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountTranferRequest
    {
        /// <summary>
        /// Account Number where the amount will be transfered from
        /// </summary>
        /// <value></value>
        public string SourceAccountNumber { get; set;}
        /// <summary>
        /// Account Number where amount will be sent to
        /// </summary>
        /// <value></value>
        public string DestinationAccountNumber { get; set;}
        /// <summary>
        /// Amount that will be transfered
        /// </summary>
        /// <value></value>
        public decimal Amount { get; set;}
    }
}
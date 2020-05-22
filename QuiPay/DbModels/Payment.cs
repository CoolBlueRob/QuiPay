using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace QuiPay.DbModels
{
    public enum PaymentState
    {
        Waiting, Accepted, Declined
    }

    public class Payment
    {
        [Key]
        public int ID { get; set; }

        public PaymentState TransactionState { get; set; }

        public int FromAccountID { get; set; }

        public int ToAccountID { get; set; }

        public DateTime WhenProposed { get; set; }

        public DateTime WhenAccepted { get; set; }

        public DateTime WhenDeclined { get; set; }

        public Currency Amount { get; set; }

        public int RefundPaymentID { get; set; }
    }
}

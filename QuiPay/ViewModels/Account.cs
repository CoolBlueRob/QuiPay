using System;
using System.Collections.Generic;

namespace QuiPay.ViewModels
{
    public enum AccountState
    {
        Pending, Active, Suspicious, Suspended
    };

    public class Account
    {
        public int ID { get; set; }

        public AccountState AccountState { get; set; }

        public Currency Balance { get; set; }

        public int MemberID { get; set; }

        public int CurrencyID { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}

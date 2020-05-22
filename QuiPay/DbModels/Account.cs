using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuiPay.DbModels
{
    public enum State
    {
        Pending, Active, Suspicious, Suspended
    };

    public class Account
    {
        [Key]
        public int ID { get; set; }

        public State State { get; set; }

        public int MemberID { get; set; }

        public int CurrencyID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.DbModels
{
    public enum BankNoteState
    {
        Unprinted, Printed, Suspended
    }

    public class BankNote
    {
        [Key]
        public int ID { get; set; }

        public BankNoteState BankNoteState { get; set; }

        public int Printed { get; set; }

        public Currency Value { get; set; }
    }
}

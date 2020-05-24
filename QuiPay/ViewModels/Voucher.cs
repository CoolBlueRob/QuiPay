using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.ViewModels
{
    public enum BankNoteState
    {
        Unprinted, Printed, Suspended
    }

    public class BankNote
    {
        public int ID { get; set; }

        public BankNoteState BankNoteState { get; set; }

        public int Printed { get; set; }

        public Currency Value { get; set; }
    }
}

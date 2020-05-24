using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.ViewModels
{
    public enum BankNoteAccountLutState
    {
        Current, Historic
    }

    public class BankNoteAccountLut
    {
        public int ID { get; set; }

        public BankNoteAccountLutState BankNoteAccountLutState { get; set; }

        public int BankNoteID { get; set; }

        public int AccountID { get; set; }

        public virtual BankNote BankNote { get; set;}

        public virtual Account Account { get; set;}
    }
}
    
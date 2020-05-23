﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.DbModels
{
    public enum BankNoteAccountLutState
    {
        Current, Historic
    }

    public class BankNoteAccountLut
    {
        [Key]
        public int ID { get; set; }

        public BankNoteAccountLutState BankNoteAccountLutState { get; set; }

        public int BankNoteID { get; set; }

        public int AccountID { get; set; }

        public virtual BankNote {get; set;}

        public virtual Account {get; set;}
    }
}
    
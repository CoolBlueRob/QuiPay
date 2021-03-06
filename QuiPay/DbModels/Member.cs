﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.DbModels
{
    public enum MemberState
    {
        Pending, Approved, Suspicious, Suspended
    };

    public class Member
    {
        [Key]
        public int ID { get; set; }

        public MemberState MemberState { get; set; }

        public DateTime WhenCreated { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<MemberDetail> MemberDetails { get; set; }
    }
}

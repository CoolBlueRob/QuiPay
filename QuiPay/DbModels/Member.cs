using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.DbModels
{
    public class Member
    {
        [Key]
        public int ID { get; set; }

        public State State { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<MemberDetails> MemberDetails { get; set; }
    }
}

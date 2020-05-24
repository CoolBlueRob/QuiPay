using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.ViewModels
{
    public enum MemberState
    {
        Pending, Active, Suspicious, Suspended
    };

    public class Member
    {
        public int ID { get; set; }

        public MemberState MemberState { get; set; }

        public DateTime WhenCreated { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<MemberDetails> MemberDetails { get; set; }
    }
}

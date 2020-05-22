using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuiPay.DbModels;

namespace QuiPay.Data
{
    public class DbInitializer
    {
        public static void Initialize(QuiPayContext context)
        {
            context.Database.EnsureCreated();

            //if (context.MemberState.Any())
            //{
            //    return;
            //}

            //var memberStates = new MemberState[]
            //{
            //    new MemberState{Description="Pending"},
            //    new MemberState{Description="Approved"},
            //    new MemberState{Description="Suspended"},
            //    new MemberState{Description="Declined"}
            //};
            //context.MemberState.AddRange(memberStates);
            //context.SaveChanges();

            //var accountStates = new AccountState[]
            //{
            //    new AccountState{Description="Pending"},
            //    new AccountState{Description="Approved"},
            //    new AccountState{Description="Suspended"},
            //    new AccountState{Description="Declined"}
            //};
            //context.AccountState.AddRange(accountStates);
            context.SaveChanges();
        }
    }
}

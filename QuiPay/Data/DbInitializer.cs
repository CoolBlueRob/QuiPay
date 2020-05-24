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

            if (context.MemberDetail.Any())
            {
                return;
            }

            var members = new Member[]
            {
                new Member
                {
                    MemberState = MemberState.Approved,
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                },

                new Member
                {
                    MemberState = MemberState.Approved,
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                },

                new Member
                {
                    MemberState = MemberState.Approved,
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                }
            };
            context.Member.AddRange(members);
            context.SaveChanges();

            var memberDetails = new MemberDetail[]
            {
                new MemberDetail{ MemberDetailsState = MemberDetailsState.Approved,
                    Title = "Mr",
                    FirstName = "Rob",
                    LastName = "Smith",
                    Address1 = "Home",
                    Address2 = "Home Road",
                    City = "Home Town",
                    State = "Home County",
                    CountryCode = "UK",
                    ZipCode = "Home Zip",
                    Email = "rob@coolbluesoftware.com",
                    Phone = "07817 716237",
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                    MemberID = 1
                },

                new MemberDetail{ MemberDetailsState = MemberDetailsState.Approved,
                    Title = "Mr",
                    FirstName = "John",
                    LastName = "Jones",
                    Address1 = "5",
                    Address2 = "Any Road",
                    City = "Any Town",
                    State = "Any County",
                    CountryCode = "UK",
                    ZipCode = "Any Zip",
                    Email = "rob@coolbluesoftware.com",
                    Phone = "07817 716237",
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                    MemberID = 2
                },

                new MemberDetail{ MemberDetailsState = MemberDetailsState.Approved,
                    Title = "Mr",
                    FirstName = "Bill",
                    LastName = "Gates",
                    Address1 = "1",
                    Address2 = "Bill Road",
                    City = "Bill Town",
                    State = "Bill County",
                    CountryCode = "USA",
                    ZipCode = "Bill Zip",
                    Email = "rob@coolbluesoftware.com",
                    Phone = "07817 716237",
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                    MemberID = 3
                }
            };

            context.MemberDetail.AddRange(memberDetails);
            context.SaveChanges();
        }
    }
}

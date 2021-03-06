﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.ViewModels
{
    public enum MemberDetailsState
    {
        Pending, Active, Suspicious, Suspended
    };

    public class MemberDetails
    {
        public int ID { get; set; }

        public MemberDetailsState MemberDetailsState { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string CountryCode { get; set; }

        public string ZipCode { get; set; }

        public DateTime WhenCreated { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int MemberID { get; set; }
  
        public virtual Member Member { get; set; }
    }
}

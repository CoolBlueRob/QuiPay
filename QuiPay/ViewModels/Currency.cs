using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.ViewModels
{
    public enum CurrencyState
    {
        Pending, Active, Suspicious, Suspended
    };

    public class Currency
    {
        public int ID { get; set; }

        public CurrencyState CurrencyState { get; set; }

        public string Name { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.DbModels
{
    public class Currency
    {
        [Key]
        public int ID { get; set; }

        public State State { get; set; }

        public string Name { get; set; }
    }
}

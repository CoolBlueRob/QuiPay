﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPay.DbModels
{
    public class ExchangeRate
    {
        [Key]
        public int ID { get; set; }
    }
}

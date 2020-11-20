﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CmApp.Contracts.Entities
{
    public class Summary
    {
        public int Id { get; set; }
        public decimal BoughtPrice { get; set; }
        public decimal? SoldPrice { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsSold { get; set; } = false;

        public virtual Car Car { get; set; }
    }
}

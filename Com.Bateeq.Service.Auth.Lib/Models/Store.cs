using Com.Bateeq.Service.Auth.Lib.Models;
using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Bateeq.Service.Auth.Lib.Models
{
    public class Store : StandardEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public float MonthlyTotalCost { get; set; }
        public string Name { get; set; }
        public string OnlineOffline { get; set; }
        public DateTimeOffset OpenedDate { get; set; }
        public string Pic { get; set; }
        public string Phone { get; set; }
        public float SalesCapital { get; set; }
        public string SalesCategory { get; set; }
        public float SalesTarget { get; set; }
        public string Status { get; set; }
        public string StoreArea { get; set; }
        public string StoreCategory { get; set; }
        public string StoreWide { get; set; }
        public string Uid { get; set; }


        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}

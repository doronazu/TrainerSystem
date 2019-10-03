using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Trainer
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MembershipTypeCreateDate { get; set; }

        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        public string Name { get; set; }
        public int Sex { get; set; }

        public Shop Shop { get; set; }
        public int ShopId { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Package> Packages { get; set; }
        public List<AppFile> Files { get; set; }
    }
}
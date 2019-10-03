using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public List<ReceiptProduct> Products { get; set; }

    }
    public class ReceiptProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }
        public string Note { get; set; }
        public short Discount { get; set; }
        public double Price { get; set; }

    }
}
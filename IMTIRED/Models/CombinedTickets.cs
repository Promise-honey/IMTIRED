using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IMTIRED.Services;
using IMTIRED.Models;
using System.Threading.Tasks;
using IMTIRED.Utilities;
using Microsoft.AspNetCore.Components;

namespace IMTIRED.Models
{
    public class CombinedTicketsModel
    {
        // Ticket properties
        public int StudentTickets { get; set; }
        public int ToddlerTickets { get; set; }
        public int FreeTickets { get; set; }
        public int FamilySuite { get; set; }
        public int HoneymoonSuite { get; set; }
        public int ZooDeluxePackage { get; set; }
        public int ZooFamilyPackage { get; set; }
        public int ZooHoneymoonPackage { get; set; }

        // Additional properties (if required)
        public int AdultTickets { get; set; }
        public int ChildTickets { get; set; }
        public int StandardRoom { get; set; }
        public int DeluxeRoom { get; set; }
        public int ZooStandardPackage { get; set; }

        // Method to calculate total cost
        public decimal CalculateTotal()
        {
            decimal total = 0;
            total += AdultTickets * 31.50m;
            total += ChildTickets * 24.00m;
            total += StandardRoom * 120.00m;
            total += DeluxeRoom * 160.00m;
            total += ZooStandardPackage * 150.00m;

            return total;
        }
    }
}

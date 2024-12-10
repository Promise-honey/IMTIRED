using System.Text;
using System.Security.Cryptography;
using IMTIRED.Models;
using IMTIRED.Services;

namespace IMTIRED.Utilities
{
    public class UserSession
    {
        public List<BasketItem> Basket { get; set; }  // Change this to List<BasketItem>

        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public UserSession()
        {
            Basket = new List<BasketItem>(); // Initialize the basket with BasketItem objects
        }
    }
}


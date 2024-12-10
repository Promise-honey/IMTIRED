using IMTIRED.Models;
using System.Collections.Generic;

namespace IMTIRED.Services
{
    public class BasketService
    {
        private readonly List<BasketItem> _basketItems;

        public BasketService()
        {
            _basketItems = new List<BasketItem>();
        }

        public void AddTicketToBasket(Ticketbooking ticket)
        {
            _basketItems.Add(new BasketItem
            {
                ItemType = "Ticket",
                ItemName = $"Ticket ({ticket.AdultTickets} Adults, {ticket.ChildTickets} Children, etc.)",
                Price = CalculateTicketPrice(ticket)
            });
        }

        public void AddRoomToBasket(Room room, int nights)
        {
            _basketItems.Add(new BasketItem
            {
                ItemType = "Room",
                ItemName = $"{room.RoomType} Room",
                Price = CalculateRoomPrice(room, nights)
            });
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in _basketItems)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }

        private decimal CalculateTicketPrice(Ticketbooking ticket)
        {
            // Example pricing logic: Adjust prices based on the number of tickets
            decimal pricePerAdult = 20.00m;  // Example price per adult ticket
            decimal pricePerChild = 10.00m;  // Example price per child ticket

            return (ticket.AdultTickets * pricePerAdult) + (ticket.ChildTickets * pricePerChild);
        }

        private decimal CalculateRoomPrice(Room room, int nights)
        {
            // Example room price calculation (you can update this with real prices)
            decimal roomPricePerNight = room.RoomType switch
            {
                "Standard" => 100.00m,
                "Deluxe" => 150.00m,
                "FamilySuite" => 200.00m,
                "HoneymoonSuite" => 250.00m,
                _ => 0.00m,
            };

            return roomPricePerNight * nights;
        }

        public List<BasketItem> GetBasketItems()
        {
            return _basketItems;
        }
    }

    public class BasketItem
    {
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}

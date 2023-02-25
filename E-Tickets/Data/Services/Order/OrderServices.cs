using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data.Services
{
    public class OrderServices:IOrderServices
    {
        private readonly AppDbContext context;
        public OrderServices(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await context.OrderItems.AddAsync(orderItem);
            }
            await context.SaveChangesAsync();
        }
    }
}

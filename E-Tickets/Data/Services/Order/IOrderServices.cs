using E_Tickets.Data.Base;
using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public interface IOrderServices
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}

using eTickets.Models;

namespace eTickets.Data.Services.Abstract
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}

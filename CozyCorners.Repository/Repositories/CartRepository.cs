using CozyCorners.Core.Models.Order;
using CozyCorners.Core.Repositories.Contract;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CozyCorners.Repository.Repositories
{
	public class CartRepository : ICartRepository
	{
        private readonly IDatabase _database;
        public CartRepository(IConnectionMultiplexer redis)
        {
				_database=redis.GetDatabase();
        }
        public async Task<bool> DeleteCartAsync(string BasketId)
		{
			return await _database.KeyDeleteAsync(BasketId);
		}

		public async Task<CustomerCart?> GetCustomerCartAsync(string BasketId)
		{
			var basket =await _database.StringGetAsync(BasketId);
			return basket.IsNullOrEmpty ?  null :JsonSerializer.Deserialize<CustomerCart?>(basket);
		}

		public async Task<CustomerCart?> UpdateBasketAsync(CustomerCart cart)
		{
			var createdOrUpdated = await _database.StringSetAsync(cart.Id,JsonSerializer.Serialize(cart),TimeSpan.FromDays(3));
			if (!createdOrUpdated) return null;
			return await GetCustomerCartAsync(cart.Id);
		}
        public  int GetCustomerCartItemsAsync(string BasketId)
        {
            var basket =  _database.StringGet(BasketId);
			
            return basket.IsNullOrEmpty ? 0 :JsonSerializer.Deserialize<CustomerCart?>(basket).CartItems.Count();
        }

    }
}

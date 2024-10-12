using CozyCorners.Core.Models.Identity;
using CozyCorners.Core.Models.Order;
using CozyCorners.Core.Repositories.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.ContentModel;


namespace CozyCorners.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<AppUser> _userManager;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository, UserManager<AppUser> userManager)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken] // Validate the anti-forgery token
        public async Task<ActionResult> AddCart(int ProductId, int? quantity)
        {
            var product = await _productRepository.GetById(ProductId);

            if (product == null)
            {
                return NotFound(); // Handle product not found
            }

            var cartItem = new CartItem();
            if (quantity == null)
            {

                cartItem = new CartItem()
                {
                    Id = ProductId,
                    ImageUrl = product.PhotoPath,
                    ProductName = product.Name,
                    Price = product.Price,
                    Category = product.Category.Name,
                    Quantity = 1
                };

            }
            else
            {
                cartItem = new CartItem()
                {
                    Id = ProductId,
                    ImageUrl = product.PhotoPath,
                    ProductName = product.Name,
                    Price = product.Price,
                    Category = product.Category.Name,
                    Quantity = quantity
                };

            }
            var userId = _userManager.GetUserId(User);
            var cart = await _cartRepository.GetCustomerCartAsync(userId) ?? new CustomerCart { Id = userId, CartItems = new List<CartItem>() };

            cart.CartItems.Add(cartItem);

            await _cartRepository.UpdateBasketAsync(cart);
            TempData["Message"] = $"This Item Added To Cart !";

            return RedirectToAction("GetCart", "Cart", new { id = userId });
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCart?>> GetCart(string? id)
        {

            if (id == null) return View("CatNotFound");
          
                var basket = await _cartRepository.GetCustomerCartAsync(id);
            if (basket is not null)
                return View(basket);
            else
                return View("CatNotFound");


        }

        [HttpDelete]
        public async Task DeleteCartItem(string cartid, int productid)
        {

            var cart = await _cartRepository.GetCustomerCartAsync(cartid);
            var itemToRemove = cart.CartItems.FirstOrDefault(item => item.Id == productid);
            if (itemToRemove != null)
            {
                cart.CartItems.Remove(itemToRemove);
            }
          
            // Serialize the modified basket back to JSON
            var updatedBasketData =await  _cartRepository.UpdateBasketAsync(cart);
            if (cart.CartItems.Count() ==0)
            {
                await _cartRepository.DeleteCartAsync(cartid);
            }


        }
    }
}

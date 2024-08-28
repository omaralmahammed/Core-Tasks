using Day5_BackEnd.DTO;
using Day5_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day5_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CartController(MyDbContext db)
        {
            _db = db;
        }

        [HttpPost("AddUserCart")]
        public IActionResult addUserToCart(Cart cart)
        {   
            var allCarts = _db.Carts.ToList();

            foreach (var userCart in allCarts)
            {
                if (userCart.UserId == cart.UserId)
                {
                    return Ok("User had cart before!");
                }
                else
                {
                    _db.Carts.Add(cart);
                    _db.SaveChanges();
                    return Ok("Cart added Successfully");
                }
            }
            return Ok();
           
        }

        [HttpGet("getAllCarts")]
        public IActionResult getAllCarts()
        {
            var carts = _db.Carts.ToList();

            return Ok(carts);
        }


        [HttpGet("getAllItems")]
        public IActionResult getAllItems()
        {
            var cartItem = _db.CartItems.Select(
             x => new cartItemResponseDTO
             {
                 CartItemId = x.CartItemId,
                 CartId = x.CartId,
                 Quantity = x.Quantity,
                 Product = new productDTO
                 {
                     ProductId = x.Product.ProductId,
                     ProductName = x.Product.ProductName,
                     Price = x.Product.Price,
                 }
             });

            return Ok(cartItem);
        }


        [HttpGet("getUserItems/{id}")]
        public IActionResult getUserItems(int id)
        {

            var user = _db.Carts.FirstOrDefault( x => x.UserId == id);

            var cartItem = _db.CartItems.Where( y => y.CartId == user.CartId).Select(
             x => new cartItemResponseDTO
             {
                 CartItemId = x.CartItemId,
                 CartId = x.CartId,
                 Quantity = x.Quantity,
                 Product = new productDTO
                 {
                     ProductId = x.Product.ProductId,
                     ProductName = x.Product.ProductName,
                     Price = x.Product.Price,
                 }
             });

            return Ok(cartItem);
        }



        [HttpPost("addCartItem")]
        public IActionResult addCartItem([FromBody] addCartItemRequestDTO cart)
        {
            var data = new CartItem
            {
                CartId = cart.CartId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,
            };

            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok();
        }


        //[HttpPost ("addCartItem/{id}")]
        //public IActionResult addCartItem([FromBody] addCartItemRequestDTO cart, int id)
        //{

        //    var user = _db.Carts.FirstOrDefault(x => x.UserId == id);

        //    var data = new CartItem
        //    {
        //        CartId = user.CartId,
        //        Quantity = cart.Quantity,
        //        ProductId = cart.ProductId,
        //    };

        //    _db.CartItems.Add(data);
        //    _db.SaveChanges();
        //    return Ok();
        //}
    }
}

using Day5_BackEnd.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task5.DTO;
using Task5.Models;

namespace Task5.Controllers
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

        [HttpGet("getAllItemsInCart")]
        public IActionResult getAllItemsInCart()
        {
            var allItemsInCart = _db.CartItems.Select(
             x => new cartResponseDTO
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
             }).ToList();

            return Ok(allItemsInCart);
        }

        [HttpPut("updateQuantity/{id:int}")]
        public IActionResult updateQuantity(int id, [FromBody] int quantityValue)
        {
            var findItem = _db.CartItems.Find(id);

            findItem.Quantity = quantityValue;

            _db.CartItems.Update(findItem);
            _db.SaveChanges();
            return Ok("Quantity was updated");
        }

        [HttpDelete("deleteItemInCart/{id}")]
        public IActionResult deleteItemInCart(int id)
        {
            var findItem = _db.CartItems.Find(id);


            _db.CartItems.Remove(findItem);
            _db.SaveChanges();
            return Ok("Item was Deleted");
        }
    }
}

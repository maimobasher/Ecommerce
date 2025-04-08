using Ecommerce.Data.Data;
using Ecommerce.Data.Model;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Services.OrderItemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null) return NotFound();

            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemDto orderItemDto)
        {
            if (orderItemDto == null) return BadRequest("Invalid order item data.");

            await _orderItemService.AddOrderItemAsync(orderItemDto);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItemDto.Id }, orderItemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, [FromBody] OrderItemDto orderItemDto)
        {
            if (orderItemDto == null) return BadRequest("Invalid order item data.");

            await _orderItemService.UpdateOrderItemAsync(id, orderItemDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _orderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }

    }
}
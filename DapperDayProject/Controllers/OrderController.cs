using DapperDayProject.Dtos.OrderDtos;
using DapperDayProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DapperDayProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    public async Task<IActionResult> OrderList()
        {
            var values = await _orderService.GetAllOrderAsync();
            return View(values);

        }
        public async Task<IActionResult> OrderListWithCustomer() 
        { 
            var values = await _orderService.GetOrderWithCustomerasync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _orderService.CreateOrderAsync(createOrderDto);
            return RedirectToAction("OrderList");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction("OrderList");
        }
        [HttpGet]
        public async Task<IActionResult>UpdateOrder(int id)
        {
           var value = await _orderService.GetOrderByIdAsync(id);
            return View(value);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _orderService.UpdateOrderAsync(updateOrderDto);
            return RedirectToAction("OrderList");
        }
    }
}

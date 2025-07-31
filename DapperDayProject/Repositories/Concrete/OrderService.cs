using Dapper;
using DapperDayProject.Context;
using DapperDayProject.Dtos.OrderDtos;
using DapperDayProject.Repositories.Abstract;

namespace DapperDayProject.Repositories.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly DapperContext _context;
        public OrderService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            string query = "insert into TblOrder (ProductName,ProductPrice,ProductCount,CustomerId) values (@p1,@p2,@p3,@p4)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", createOrderDto.ProductName);
            parameters.Add("@p2", createOrderDto.ProductPrice);
            parameters.Add("@p3", createOrderDto.ProductCount);
            parameters.Add("@p4", createOrderDto.CustomerId);

            var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, parameters);
        }

        public async Task DeleteOrderAsync(int id)
        {
            string query = "DELETE FROM TblOrder WHERE OrderId = @orderId";

            var parameters = new DynamicParameters();
            parameters.Add("@orderId", id);

            var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var query = "Select * From TblOrder";
            var connection =_context.CreateConnection();
            var values= await connection.QueryAsync<ResultOrderDto>(query);
            return values.ToList();
        }

        public async Task<GetOrderByIdDto> GetOrderByIdAsync(int id)
        {
            var query = "Select * From TblOrder Where OrderId=@orderId";
            var parameters= new DynamicParameters();
            parameters.Add("@OrderId", id);
            var connection= _context.CreateConnection();
            var values=await connection.QueryFirstAsync<GetOrderByIdDto>(query);
            return values;
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            string query = @"UPDATE TblOrder 
                     SET ProductName = @p1,
                         ProductPrice = @p2,
                         ProductCount = @p3,
                         CustomerId = @p4
                     WHERE OrderId = @p5";

            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", updateOrderDto.ProductName);
            parameters.Add("@ProductPrice", updateOrderDto.ProductPrice);
            parameters.Add("@ProductCount", updateOrderDto.ProductCount);
            parameters.Add("@CustomerId", updateOrderDto.CustomerId);
            parameters.Add("@OrderId", updateOrderDto.OrderId);

            var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, parameters);
        }
    }
}

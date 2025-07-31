using DapperDayProject.Dtos.CustomerDtos;

namespace DapperDayProject.Repositories.Concrete
{
    public interface ICustomerService
    {
        Task CreateCustomer(CreateCustomerDto createCustomerDto);
        Task DeleteCustomer(int customerId);
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task<GetCustomerByIdDto> GetCustomerById(int id);
    }
}
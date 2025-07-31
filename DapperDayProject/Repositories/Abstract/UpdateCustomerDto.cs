namespace DapperDayProject.Repositories.Abstract
{
    public class UpdateCustomerDto
    {
        public object? CustomerName { get; internal set; }
        public object? CustomerSurname { get; internal set; }
        public object? CustomerBalance { get; internal set; }
        public object? CustomerId { get; internal set; }
    }
}
using Test11.Models;

namespace Test11.IRepository
{
    public interface ICustomers
    {
        Task<List<Customers>> GetCustomers();
        Task<Customers> InsertCustomers(Customers lead);
        Task<Customers> UpdateCustomers(Customers lead);
    }
}

using Microsoft.EntityFrameworkCore;
using Test11.Context;
using Test11.IRepository;
using Test11.Models;

namespace Test11.Repository
{
    public class CustomersRepository : ICustomers
    {
        SampleContext db;
        public CustomersRepository(SampleContext _db)
        {
            db = _db;
        }
        public async Task<List<Customers>> GetCustomers()
        {
            try
            {
                if (db != null)
                {
                    var query = (from a in db.Customers
                                 select a);
                    return await query.ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Customers>InsertCustomers(Customers lead)
        {
            try
            {
                Customers obj = new Customers()
                {
                    Edges = lead.Edges

                };
                var result = await db.Customers.AddAsync(obj);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Customers> UpdateCustomers(Customers lead)
        {
            try
            {
                var result = await db.Customers.FirstOrDefaultAsync(x=>x.Edges==lead.Edges);
                if(result!=null)
                {
                    result.Edges = lead.Edges;
                    await db.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

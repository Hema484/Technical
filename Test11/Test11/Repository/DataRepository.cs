using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Test11.Context;
using Test11.IRepository;
using Test11.Models;

namespace Test11.Repository
{
    public class DataRepository :IData
    {
        SampleContext db;
        public DataRepository(SampleContext _db)
        {
            db = _db;
        }
        public async Task<List<Data>>GetData()
        {
            try
            {
                if (db != null)
                {
                    var query = (from a in db.Data
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

        private Task fetch(char v)
        {
            throw new NotImplementedException();
        }

        public async Task<Data>InsertData(Data lead)
        {
            try
            {
                Data obj = new Data()
                {
                    Customers = lead.Customers
                };
                var result = await db.Data.AddAsync(obj);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Data> UpdateData(Data lead)
        {
            try
            {
                var result = await db.Data.FirstOrDefaultAsync(x => x.Customers == lead.Customers);
                if (result != null)
                {
                    result.Customers = lead.Customers;
                    await db.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

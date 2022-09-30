using Microsoft.EntityFrameworkCore;
using Test11.Context;
using Test11.IRepository;
using Test11.Models;

namespace Test11.Repository
{
    public class EdgesRepository :IEdges
    {
        SampleContext db;
        public EdgesRepository(SampleContext _db)
        {
            db = _db;
        }
        public async Task<List<Edges>> GetEdges()
        {
            try
            {
                if (db != null)
                {
                    var query = (from a in db.Edges
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
        public async Task<Edges>InsertEdges(Edges lead)
        {
            try
            {
                Edges obj = new Edges()
                {
                    Cursor=lead.Cursor,
                    Node = lead.Node
                };
                var result = await db.Edges.AddAsync(obj);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Edges>UpdateEdges(Edges lead)
        {
            try
            {
                var result = await db.Edges.FirstOrDefaultAsync(x=>x.Cursor==lead.Cursor);
                if(result!=null)
                {
                    result.Cursor = lead.Cursor;
                    result.Node = lead.Node;
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

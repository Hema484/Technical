using Microsoft.EntityFrameworkCore;
using Test11.Context;
using Test11.IRepository;
using Test11.Models;

namespace Test11.Repository
{
    public class NodeRepository : INode
    {
        SampleContext db;
        
        public NodeRepository(SampleContext _db)
        {
            db = _db;
            
        }
        public async Task<List<Node>> GetNode()
        {
            try
            {
                if (db != null)
                {
                    var query = (from a in db.Node
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
        public async Task<Node>InsertNode(Node lead)
        {
            try
            {
                Node obj = new Node()
                {
                    dbId=lead.dbId,
                    description=lead.description,
                };
                var result = await db.Node.AddAsync(obj);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Node> UpdateNode(Node lead)
        {
            try
            {
                var result = await db.Node.FirstOrDefaultAsync(x => x.dbId == lead.dbId);
                if(result!=null)
                {
                    result.dbId = lead.dbId;
                    result.description = lead.description;
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

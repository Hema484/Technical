using Test11.Models;

namespace Test11.IRepository
{
    public interface IEdges
    {
        Task<List<Edges>> GetEdges();
        Task<Edges> InsertEdges(Edges lead);
        Task<Edges> UpdateEdges(Edges lead);
    }
}

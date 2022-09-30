using Test11.Models;

namespace Test11.IRepository
{
    public interface INode
    {
        Task<List<Node>> GetNode();
        Task<Node> InsertNode(Node lead);
        Task<Node> UpdateNode(Node lead);
    }
}

using Test11.Models;

namespace Test11.IRepository
{
    public interface IData
    {
        Task<List<Data>> GetData();
        Task<Data> InsertData(Data lead);
        Task<Data> UpdateData(Data lead);
    }
}

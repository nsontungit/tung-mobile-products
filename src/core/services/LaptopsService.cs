using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core.services
{
    public interface ILaptopsService
    {
        Task GetOne(int id);
        Task GetMany();
        Task CreateOne();
        Task CreateMany();
        Task UpdateOne(int id);
        Task UpdateMany();
        Task DeleteOne(int id);
        Task DeleteMany();
    }
    public class LaptopsService
    {

    }
}

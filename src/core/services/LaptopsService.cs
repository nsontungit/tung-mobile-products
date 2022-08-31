using AutoMapper;
using core.models;
using entities.main;
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
        Task CreateOne(LaptopDto laptopDto);
        Task CreateMany();
        Task UpdateOne(int id);
        Task UpdateMany();
        Task DeleteOne(int id);
        Task DeleteMany();
    }
    public class LaptopsService : ILaptopsService
    {
        readonly productsContext _context;
        readonly IMapper _mapper;
        public LaptopsService(productsContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task CreateMany()
        {
            throw new NotImplementedException();
        }

        public async Task CreateOne(LaptopDto laptopDto)
        {
            var laptop = _mapper.Map<Laptops>(laptopDto);
            _context.Laptops.Add(laptop);
            await _context.SaveChangesAsync();
        }

        public Task DeleteMany()
        {
            throw new NotImplementedException();
        }

        public Task DeleteOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetMany()
        {
            throw new NotImplementedException();
        }

        public Task GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMany()
        {
            throw new NotImplementedException();
        }

        public Task UpdateOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}

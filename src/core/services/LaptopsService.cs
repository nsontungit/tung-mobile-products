using AutoMapper;
using core.models;
using core.utils;
using entities.main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.services
{
    public interface ILaptopsService
    {
        Task GetOne(int id);
        Task<PagingResponse<Laptop>> GetLaptopsByPage(int pageSize, int pageNumber);
        Task<Laptop[]> GetAll();
        Task GetMany();
        Task CreateOne(LaptopDto laptopDto);
        Task CreateMany();
        Task UpdateOne(int id, LaptopDto model);
        Task UpdateMany();
        Task DeleteOne(int id);
        Task DeleteMany();
        Task<Option[]> GetLaptopOptions(string type);
        Task<Option[]> GetLaptopBrandOptions();
        Task<Option[]> GetAllOptions();
    }
    public class LaptopsService : ILaptopsService
    {
        readonly productsContext _context;
        readonly IMapper _mapper;
        private const string tableName = "laptop";
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
            var laptop = _mapper.Map<Laptop>(laptopDto);
            laptop = laptop.Normalize();
            _context.Laptop.Add(laptop);
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

        public Task<Laptop[]> GetAll()
        {
            var laptops = _context.Laptop.ToArray();
            return Task.FromResult(laptops);
        }

        public Task GetMany()
        {
            throw new NotImplementedException();
        }

        public Task GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Option[]> GetLaptopOptions(string type)
        {
            var options = await _context.Option
                .Where(o => o.Type == type && o.Table == tableName)
                .ToArrayAsync();
            return options;
        }

        public Task UpdateMany()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOne(int id, LaptopDto model)
        {
            var laptopDb = await _context.Laptop.FindAsync(id);
            if (laptopDb == null)
                throw new Exception("Not found laptop");
            laptopDb = Converter.OverrideObject<LaptopDto, Laptop>(model, laptopDb);
            var now = DateTime.Now;
            laptopDb.LastUpdate = now;
            _context.Laptop.Update(laptopDb);
            _context.SaveChanges();
        }

        public async Task<Option[]> GetAllOptions()
        {
            var options = await _context.Option
                .Where(o => o.Table == tableName)
                .ToArrayAsync();
            return options;
        }

        public async Task<Option[]> GetLaptopBrandOptions()
        {
            var options = await _context.Option
                .Where(o => o.Table == "brand" && o.Type == "laptop-brand")
                .ToArrayAsync();
            return options;
        }

        public async Task<PagingResponse<Laptop>> GetLaptopsByPage(int pageSize, int pageNumber)
        {
            var totalRowsTask = _context.Laptop.CountAsync();
            var laptopsTask = _context.Laptop
                .OrderByDescending(e => e.Created)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToArrayAsync();

            await Task.WhenAll(totalRowsTask, laptopsTask);

            var laptops = await laptopsTask;
            var totalRows = await totalRowsTask;
            var totalPages = MathF.Floor((float)totalRows / pageSize);
            return new PagingResponse<Laptop>()
            {
                Data = laptops,
                TotalPages = (int)totalPages,
                TotalRows = totalRows
            };
        }
    }
}

using HomeWorkDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWorkDAL
{
    public class LaptopInDbRepository : ILaptopRepository
    {
        private readonly EFCoreContext _dbContext;

        public LaptopInDbRepository(EFCoreContext efContext)
        {
            _dbContext = efContext;
        }

        public Guid Add(LaptopDTO laptop)
        {
            laptop.Id = Guid.NewGuid();
            _dbContext.Laptops.Add(laptop);

            _dbContext.SaveChanges();
            return laptop.Id;
        }

        public LaptopDTO DeleteByID(Guid id)
        {
            var dbLaptop = GetById(id);

            _dbContext.Laptops.Remove(dbLaptop);
            return dbLaptop;
        }

        public IEnumerable<LaptopDTO> GetAllLaptops()
        {
            return _dbContext.Laptops.ToList();
        }

        public LaptopDTO GetById(Guid id)
        {
            return _dbContext.Laptops.FirstOrDefault(x => x.Id == id);
        }

        public LaptopDTO GetByMultiple(int ram, int ssd, string model)
        {
            return _dbContext.Laptops.FirstOrDefault(x => x.Ram == ram && x.Ssd == ssd && x.Model == model);
        }

        public IEnumerable<LaptopDTO> GetRangeByRam(int minRam, int maxRam)
        {
            return _dbContext.Laptops.Where(x => minRam <= x.Ram && x.Ram <= maxRam);
        }

        public bool UpdateLaptop(LaptopDTO laptop)
        {
            _dbContext.Laptops.Update(laptop);
            var result = _dbContext.SaveChanges();
            
            return result != 0;
        }
    }
}

using HomeWorkDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkDAL
{
    public class LaptopListRepository : ILaptopRepository
    {
        private static List<LaptopDTO> _laptops;

        static LaptopListRepository()
        {
            _laptops = new List<LaptopDTO>();
        }

        public Guid Add(LaptopDTO laptop)
        {
            laptop.Id = Guid.NewGuid();
            _laptops.Add(laptop);

            return laptop.Id;
        }

        public IEnumerable<LaptopDTO> GetAllLaptops()
        {
            return _laptops;
        }

        public LaptopDTO GetByMultiple(int ram, int ssd, string model)
        {
            return _laptops.FirstOrDefault(x => x.Ram == ram && x.Ssd == ssd && x.Model == model);
        }

        public LaptopDTO GetById(Guid id)
        {
            return _laptops.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<LaptopDTO> GetRangeByRam(int minRam, int maxRam)
        {
            return _laptops.Where(x => minRam <= x.Ram && x.Ram <= maxRam);
        }

        public LaptopDTO DeleteByID(Guid id)
        {
            var dbLaptop = GetById(id);

            _laptops.Remove(dbLaptop);
            return dbLaptop;
        }

        public bool UpdateLaptop(LaptopDTO laptop)
        {
            var dbLaptop = GetById(laptop.Id);

            var index = _laptops.IndexOf(dbLaptop);
            _laptops[index] = laptop;

            return true;
        }
    }
}

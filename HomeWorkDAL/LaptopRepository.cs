using HomeWorkDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkDAL
{
    public class LaptopRepository
    {
        private static List<LaptopDTO> _laptops;

        static LaptopRepository()
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

            if(dbLaptop != null)
            {
                _laptops.Remove(dbLaptop);
                return dbLaptop;
            }

            return new LaptopDTO();
        }

        public bool UpdateLaptop(LaptopDTO laptop)
        {
            var dbLaptop = GetById(laptop.Id);

            if(dbLaptop != null)
            {
                var index = _laptops.IndexOf(dbLaptop);
                _laptops[index] = laptop;
            }

            return dbLaptop != null;
        }
    }
}

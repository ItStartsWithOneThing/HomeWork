using HomeWorkDAL.Entities;
using System;
using System.Collections.Generic;

namespace HomeWorkDAL
{
    public interface ILaptopRepository
    {
        Guid Add(LaptopDTO laptop);
        LaptopDTO DeleteByID(Guid id);
        IEnumerable<LaptopDTO> GetAllLaptops();
        LaptopDTO GetById(Guid id);
        LaptopDTO GetByMultiple(int ram, int ssd, string model);
        IEnumerable<LaptopDTO> GetRangeByRam(int minRam, int maxRam);
        bool UpdateLaptop(LaptopDTO laptop);
    }
}
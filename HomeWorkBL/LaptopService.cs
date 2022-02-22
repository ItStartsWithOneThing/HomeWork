using AutoMapper;
using HomeWork.Models;
using HomeWorkDAL;
using HomeWorkDAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeWorkBL
{
    public class LaptopService
    {
        private LaptopRepository _laptopRepository;
        private IMapper _mapper;

        public LaptopService(IMapper mapper, LaptopRepository laptopRepository)
        {
            _mapper = mapper;
            _laptopRepository = laptopRepository;
        }

        public Guid AddLaptop(Laptop laptop)
        {
            if (laptop.Price != 0)
            {
                laptop.Description = "В продаже";
            }
            else
            {
                laptop.Description = "Цена формируется";
            }

            var dbLaptop = _mapper.Map<LaptopDTO>(laptop);
            return _laptopRepository.Add(dbLaptop);
        }

        public IEnumerable<Laptop> GetAllLaptops()
        {
            var dbItems = _laptopRepository.GetAllLaptops();

            if(dbItems != null)
            {
                return _mapper.Map<IEnumerable<Laptop>>(dbItems);
            }

            return new List<Laptop>();  
        }

        public Laptop GetLaptopById(Guid id)
        {
            var dbLaptop = _laptopRepository.GetById(id);

            if (dbLaptop != null)
            {
                return _mapper.Map<Laptop>(dbLaptop);
            }

            return new Laptop();
        }

        public IEnumerable<Laptop> GetRangeByRam(int minRam, int maxRam)
        {
            var dbItems = _laptopRepository.GetRangeByRam(minRam, maxRam);

            if(dbItems != null)
            {
                return _mapper.Map<IEnumerable<Laptop>>(dbItems);
            }

            return new List<Laptop>();
        }

        public Laptop GetLaptopByMultiple(int ram, int ssd, string model)
        {
            var dbLaptop = _laptopRepository.GetByMultiple(ram, ssd, model);

            if(dbLaptop != null)
            {
                return _mapper.Map<Laptop>(dbLaptop);
            }

            return new Laptop();
        }

        public Laptop DeleteLaptopById(Guid id)
        {
            var dbLaptop = _laptopRepository.DeleteByID(id);

            if(dbLaptop != null)
            {
                return _mapper.Map<Laptop>(dbLaptop);
            }

            return new Laptop();
        }
        
        public bool UpdateLaptop(Laptop laptop)
        {
            var dbLaptop = _mapper.Map<LaptopDTO>(laptop);
            return _laptopRepository.UpdateLaptop(dbLaptop);
        }
    }
}

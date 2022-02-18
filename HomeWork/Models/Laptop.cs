using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Models
{
    public class Laptop
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [MinLength(2)]
        [MaxLength(28)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(4, 64, ErrorMessage = "Объем RAM должен быть в диапазоне 4-64Гб")]
        public int Ram { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(128, 1000, ErrorMessage = "Объем SSD должен быть в диапазоне 128-1000Гб")]
        public int Ssd { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(11, 18, ErrorMessage = "Диагональ дисплея должна быть в диапазоне 11-18'")]
        public double Display { get; set; }

        public string Description { get; set; }
    }
}

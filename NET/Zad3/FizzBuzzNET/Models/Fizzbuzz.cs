using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzNET.Models
{
    public class Fizzbuzz
    {
        [Range(1, 1000)]
        [Required]
        public int Liczba { get; set; }

        public string Wynik { get; set; }
        public DateTime Data { get; set; }
    }
}

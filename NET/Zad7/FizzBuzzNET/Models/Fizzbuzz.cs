using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzNET.Models
{
    public class Fizzbuzz
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Liczba { get; set; }

        public string Wynik { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public void Fibuz(Fizzbuzz fizzbuzz)
        {
            if (fizzbuzz.Liczba % 3 == 0 && fizzbuzz.Liczba % 5 == 0)
            {
                fizzbuzz.Wynik = "Otrzymano: FizzBuzz";
            }
            else if (fizzbuzz.Liczba % 3 == 0)
            {
                fizzbuzz.Wynik = "Otrzymano: Fizz";
            }
            else if (fizzbuzz.Liczba % 5 == 0)
            {
                fizzbuzz.Wynik = "Otrzymano: Buzz";
            }
            else
            {
                fizzbuzz.Wynik = "Liczba: " + fizzbuzz.Liczba + " nie spełnia kryteriów Fizz/Buzz";
            }
        }
    }
}

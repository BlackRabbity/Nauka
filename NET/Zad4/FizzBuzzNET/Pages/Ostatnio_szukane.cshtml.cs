using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzNET.Data;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FizzBuzzNET.Pages
{
    public class Ostatnio_szukaneModel : PageModel
    {
        private readonly FizzbuzzContext _context;
        public Ostatnio_szukaneModel(FizzbuzzContext context)
        {
            _context = context;
        }
        public Fizzbuzz fizzbuzz { get; set; }
        public IList<Fizzbuzz> Fizzbuzzes { get; set; }
        public void OnGet()
        {
            var Wynik = HttpContext.Session.GetString("Wynik");
            if(Wynik != null)
            {
                fizzbuzz = JsonConvert.DeserializeObject<Fizzbuzz>(Wynik);
            };
            var wyswietl = (from Fizzbuzz
                            in _context.Fizzbuzz
                            orderby Fizzbuzz.Data descending
                            select Fizzbuzz).Take(10);
            Fizzbuzzes = wyswietl.ToList();
        }
    }
}

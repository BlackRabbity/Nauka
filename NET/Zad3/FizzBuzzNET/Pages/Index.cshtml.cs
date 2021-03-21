using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public Fizzbuzz fizzbuzz { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            } else
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
                } else
                {
                    fizzbuzz.Wynik = "Liczba: " + fizzbuzz.Liczba + " nie spełnia kryteriów Fizz/Buzz";
                }
                fizzbuzz.Data = DateTime.Now;
                HttpContext.Session.SetString("Wynik", JsonConvert.SerializeObject(fizzbuzz));
                return Page();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FizzBuzzNET.Pages
{
    public class Ostatnio_szukaneModel : PageModel
    {
        public Fizzbuzz fizzbuzz { get; set; }
        public void OnGet()
        {
            var Wynik = HttpContext.Session.GetString("Wynik");
            if(Wynik != null)
            {
                fizzbuzz = JsonConvert.DeserializeObject<Fizzbuzz>(Wynik);
            };
        }
    }
}

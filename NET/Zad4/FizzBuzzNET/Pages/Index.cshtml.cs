using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzNET.Data;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzbuzzContext _context;
        public IndexModel(ILogger<IndexModel> logger, FizzbuzzContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Fizzbuzz> Fizzbuzzes { get; set; }
        [BindProperty]
        public Fizzbuzz fizzbuzz { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                fizzbuzz.Fibuz(fizzbuzz);
                fizzbuzz.Data = DateTime.Now;
                _context.Fizzbuzz.Add(fizzbuzz);
                _context.SaveChanges();
                HttpContext.Session.SetString("Wynik", JsonConvert.SerializeObject(fizzbuzz));
                return Page();
            }
        }
    }
}

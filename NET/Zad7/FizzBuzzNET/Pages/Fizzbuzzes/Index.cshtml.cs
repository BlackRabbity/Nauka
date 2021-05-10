using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzNET.Data;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzzNET.Pages.Fizzbuzzes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzNET.Data.FizzbuzzContext _context;
        public int i=0;
        public IndexModel(FizzBuzzNET.Data.FizzbuzzContext context)
        {
            _context = context;
        }

        public IList<Fizzbuzz> Fizzbuzz { get; set; }

        public async Task OnGetAsync()
        {
            var wyswietl = (from Fizzbuzz
                in _context.Fizzbuzz
                            orderby Fizzbuzz.Data descending
                            select Fizzbuzz).Take(20);
            Fizzbuzz = await wyswietl.ToListAsync();
        }
    }
}

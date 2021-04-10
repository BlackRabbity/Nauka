using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzNET.Data;
using FizzBuzzNET.Models;

namespace FizzBuzzNET.Pages.Fizzbuzzes
{
    public class DetailsModel : PageModel
    {
        private readonly FizzBuzzNET.Data.FizzbuzzContext _context;

        public DetailsModel(FizzBuzzNET.Data.FizzbuzzContext context)
        {
            _context = context;
        }

        public Fizzbuzz Fizzbuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fizzbuzz = await _context.Fizzbuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (Fizzbuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

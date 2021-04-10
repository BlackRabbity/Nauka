using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizzBuzzNET.Data;
using FizzBuzzNET.Models;

namespace FizzBuzzNET.Pages.Fizzbuzzes
{
    public class CreateModel : PageModel
    {
        private readonly FizzBuzzNET.Data.FizzbuzzContext _context;

        public CreateModel(FizzBuzzNET.Data.FizzbuzzContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fizzbuzz Fizzbuzz { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fizzbuzz.Add(Fizzbuzz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

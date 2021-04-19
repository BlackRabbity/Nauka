using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Zad5_Net.Data;
using Zad5_Net.Models;

namespace Zad5_Net.Pages
{
    public class Pobrane_bazaModel : PageModel
    {
        private readonly ILogger<Pobrane_bazaModel> _logger;
        private readonly ProductsContext _context;

        public Pobrane_bazaModel(ILogger<Pobrane_bazaModel> logger, ProductsContext context) 
        { 
            _logger = logger;
            _context = context; 
        }
        public IList<Product> Product { get; set; }
        public void OnGet()
        {
            Product = _context.Product.ToList();
        }
    }
}


using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Zad5_Net.Models;
using Zad5_Net.Services;

namespace Zad5_Net.Pages
{
    public class Pobrane_plikModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Pobrane_plikModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<Product> Products { get; private set; }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}

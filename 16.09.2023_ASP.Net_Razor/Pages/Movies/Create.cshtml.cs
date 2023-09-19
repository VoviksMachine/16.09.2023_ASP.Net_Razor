using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _16._09._2023_ASP.Net_Razor.Data;
using _16._09._2023_ASP.Net_Razor.Models;

namespace _16._09._2023_ASP.Net_Razor.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly _16._09._2023_ASP.Net_Razor.Data._16_09_2023_ASPNet_RazorContext _context;

        public CreateModel(_16._09._2023_ASP.Net_Razor.Data._16_09_2023_ASPNet_RazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Movie == null || Movie == null)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

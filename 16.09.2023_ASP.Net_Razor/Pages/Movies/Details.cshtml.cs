using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _16._09._2023_ASP.Net_Razor.Data;
using _16._09._2023_ASP.Net_Razor.Models;

namespace _16._09._2023_ASP.Net_Razor.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly _16._09._2023_ASP.Net_Razor.Data._16_09_2023_ASPNet_RazorContext _context;

        public DetailsModel(_16._09._2023_ASP.Net_Razor.Data._16_09_2023_ASPNet_RazorContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }
    }
}

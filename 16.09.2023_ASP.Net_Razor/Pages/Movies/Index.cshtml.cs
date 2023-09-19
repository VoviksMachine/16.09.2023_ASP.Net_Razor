using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _16._09._2023_ASP.Net_Razor.Data;
using _16._09._2023_ASP.Net_Razor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _16._09._2023_ASP.Net_Razor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly _16._09._2023_ASP.Net_Razor.Data._16_09_2023_ASPNet_RazorContext _context;

        public IndexModel(_16._09._2023_ASP.Net_Razor.Data._16_09_2023_ASPNet_RazorContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }


    }
}

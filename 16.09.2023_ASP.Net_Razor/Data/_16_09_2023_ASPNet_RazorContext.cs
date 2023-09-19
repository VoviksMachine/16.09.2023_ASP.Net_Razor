using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _16._09._2023_ASP.Net_Razor.Models;

namespace _16._09._2023_ASP.Net_Razor.Data
{
    public class _16_09_2023_ASPNet_RazorContext : DbContext
    {
        public _16_09_2023_ASPNet_RazorContext (DbContextOptions<_16_09_2023_ASPNet_RazorContext> options)
            : base(options)
        {
        }

        public DbSet<_16._09._2023_ASP.Net_Razor.Models.Movie> Movie { get; set; } = default!;
    }
}

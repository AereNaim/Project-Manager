using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P1.Data;
using P1.Models;

namespace P1
{
    public class DetailsBug : PageModel
    {
        private readonly P1.Data.ApplicationDbContext _context;

        public DetailsBug(P1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Bug Bug { get; set; }
        public IList<Project> Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bug = await _context.Bug.FirstOrDefaultAsync(m => m.ID == id);

            if (Bug == null || !(Bug.User == User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return NotFound();
            }
            return Page();
        }
    }
}

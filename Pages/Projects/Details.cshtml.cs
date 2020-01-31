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
    public class DetailsModel : PageModel
    {
        private readonly P1.Data.ApplicationDbContext _context;

        public DetailsModel(P1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.FirstOrDefaultAsync(m => m.ID == id);

            if (Project == null || !(Project.User == User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return NotFound();
            }
            return Page();
        }
    }
}

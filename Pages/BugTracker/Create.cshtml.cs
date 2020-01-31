using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P1.Data;
using P1.Models;

namespace P1
{
    public class CreateBug : PageModel
    {
        private readonly P1.Data.ApplicationDbContext _context;

        public CreateBug(P1.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Project> Project { get; set; }
        public IActionResult OnGet()
        {
            Project = _context.Project.Where(q => q.User == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return Page();
        }

        [BindProperty]
        public Bug Bug { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Bug.User = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Bug.Add(Bug);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

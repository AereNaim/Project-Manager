using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P1.Data;
using P1.Models;

namespace P1
{
    public class EditFeedback : PageModel
    {
        
        private readonly P1.Data.ApplicationDbContext _context;
        
        public EditFeedback(P1.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Project> Project { get; set; }

        
        [BindProperty]
        public Feedback Feedback { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Feedback = await _context.Feedback.FirstOrDefaultAsync(m => m.ID == id);

            if (Feedback == null || !(Feedback.User == User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return NotFound();
            }
            Project = await _context.Project.Where(q => q.User == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();

            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Feedback).State = EntityState.Modified;

            try
            {
                Feedback.User = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(Feedback.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedback.Any(e => e.ID == id);
        }

        
    }
}

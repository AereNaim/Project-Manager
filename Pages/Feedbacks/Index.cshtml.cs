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
    public class IndexFeedback : PageModel
    {
        private readonly P1.Data.ApplicationDbContext _context;

        public IndexFeedback(P1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Feedback> Feedback { get;set; }
        public IList<Project> Project { get; set; }

        public async Task OnGetAsync()
        {
            Feedback = await _context.Feedback.Where(q => q.User == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
        }
    }
}

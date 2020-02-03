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
    public class IndexModel : PageModel
    {
        private readonly P1.Data.ApplicationDbContext _context;

        public IndexModel(P1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync()
        {
            // userID is the current logged in user's id from identity service
            // And Project is the projects list retrieved from the database where project user string equals userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Project = await _context.Project.Where(q => q.User == userId).ToListAsync();
        }
    }
}

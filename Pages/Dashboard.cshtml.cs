using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P1.Models;

namespace P1
{
    public class DashboardModel : PageModel
    {
        private readonly P1.Data.ApplicationDbContext _context;

        public DashboardModel(P1.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Project> Project { get; set; }
        public IList<Feedback> Feedback { get; set; }
        public IList<Bug> Bug { get; set; }
        public void OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Project = _context.Project.Where(q => q.User == userId).ToList();
            Feedback = _context.Feedback.Where(q => q.User == userId).ToList();
            Bug = _context.Bug.Where(q => q.User == userId).ToList();
            ViewData["ProjectsNum"] = Project.Count;
            ViewData["FeedsNum"] = Feedback.Count;
            ViewData["BugsNum"] = Bug.Count;

        }
    }
}
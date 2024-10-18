using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSEUniversity.Web.Data;
using MSEUniversity.Web.Models;

namespace MSEUniversity.Web.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly MSEUniversity.Web.Data.SchoolContext _context;

        public IndexModel(MSEUniversity.Web.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
               .Include(c => c.Department)
               .AsNoTracking()
               .ToListAsync();
        }
    }
}

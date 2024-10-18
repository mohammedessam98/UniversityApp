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
    public class DetailsModel : PageModel
    {
        private readonly MSEUniversity.Web.Data.SchoolContext _context;

        public DetailsModel(MSEUniversity.Web.Data.SchoolContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

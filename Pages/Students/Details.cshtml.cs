﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MSEUniversity.Web.Data;
using MSEUniversity.Web.Models;

namespace MSEUniversity.Web.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly MSEUniversity.Web.Data.SchoolContext _context;

        public DetailsModel(MSEUniversity.Web.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.Include(s => s.Enrollments)
                   .ThenInclude(e => e.Course)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(m => m.ID == id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

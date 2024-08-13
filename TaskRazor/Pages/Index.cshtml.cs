using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagerLibrary.Models;
using TaskRazor.Data;

namespace TaskRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaskRazor.Data.TaskRazorContext _context;

        public IndexModel(TaskRazor.Data.TaskRazorContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TaskItem = await _context.TaskItems.ToListAsync();
        }
    }
}

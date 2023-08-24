using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskBoardWebApp.Infrastructure.Components
{
    public class TaskCategoryViewComponent: ViewComponent
    {
        private readonly DataContext _context;

        public TaskCategoryViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}

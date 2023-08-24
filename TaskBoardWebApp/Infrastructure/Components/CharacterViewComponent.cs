using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskBoardWebApp.Infrastructure.Components
{
    public class CharacterViewComponent: ViewComponent
    {
        private readonly DataContext _context;

        public CharacterViewComponent(DataContext context)
        {
            _context = context;
        }   
        
        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Characters.ToListAsync());
    }
}

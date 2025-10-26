using OCCUWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OCCUWebsite.Pages.Persons;

public class DetailsModel : PageModel
{
    private readonly OCCUWebsite.Data.PersonContext _context;

    public DetailsModel(OCCUWebsite.Data.PersonContext context)
    {
        _context = context;
    }

    public Person Person { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Person = await _context.Persons
         //   .Include(s => s.Enrollments)
           // .ThenInclude(e => e.Course)
            .AsNoTracking()
           .FirstOrDefaultAsync(m => m.ID == id);

        if (Person == null)
      {
          return NotFound();
        }
        return Page();
    }
}

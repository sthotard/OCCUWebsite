using OCCUWebsite.Data;
using OCCUWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OCCUWebsite.Pages.Persons;

public class DeleteModel : PageModel
{
    private readonly PersonContext _context;
    private readonly ILogger<DeleteModel> _logger;

    public DeleteModel(PersonContext context,
                       ILogger<DeleteModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty]
    public Person Person { get; set; }
    public string ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        Person = await _context.Persons
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

        if (Person == null)
        {
            return NotFound();
        }

        if (saveChangesError.GetValueOrDefault())
        {
            ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var Person = await _context.Persons.FindAsync(id);

        if (Person == null)
        {
            return NotFound();
        }

        try
        {
            _context.Persons.Remove(Person);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, ErrorMessage);

            return RedirectToAction("./Delete",
                                 new { id, saveChangesError = true });
        }
    }
}

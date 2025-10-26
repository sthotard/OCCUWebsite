using OCCUWebsite.Data;
using OCCUWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OCCUWebsite.Pages.Persons;

public class EditModel : PageModel
{
    private readonly PersonContext _context;

    public EditModel(PersonContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Person Person { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Person = await _context.Persons.FindAsync(id);

        if (Person == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var PersonToUpdate = await _context.Persons.FindAsync(id);

        if (PersonToUpdate == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync<Person>(
            PersonToUpdate,
            "Person",
            s => s.FirstName, s => s.LastName, s => s.NickName, s => s.Other, s => s.StartDate))
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        return Page();
    }

    private bool PersonExists(int id)
    {
        return _context.Persons.Any(e => e.ID == id);
    }
}

using OCCUWebsite.Data;
using OCCUWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OCCUWebsite.Pages.Persons;

public class CreateModel : PageModel
{
    private readonly PersonContext _context;

    public CreateModel(PersonContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Person Person { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        var emptyPerson = new Person();

        if (await TryUpdateModelAsync<Person>(
            emptyPerson,
            "Person",   // Prefix for form value.
            s => s.FirstName, s => s.LastName, s => s.NickName, s => s.Other, s => s.StartDate))
        {
            _context.Persons.Add(emptyPerson);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        return Page();
    }
}
